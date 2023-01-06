using Application.DTO.Common;
using Application.DTO.Notification;
using Application.DTO.Policy;
using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Domain.Core.Extensions;
using Domain.Core.Infrastructure.Exceptions;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Integration.BMG.Interfaces;
using SinisterApi.DTO.Notification;

namespace Application.Services
{
    internal class NotificationApplication : INotificationApplication
    {
        private readonly IPolicyService _policyService;
        private readonly INotificationRepository _notificationRepository;
        private readonly ICommunicantRepository _communicantRepository;
        public NotificationApplication(
            IPolicyService policyService,
            ICommunicantRepository communicantRepository,
            INotificationRepository notificationRepository) =>
            (_policyService, _communicantRepository, _notificationRepository) = (policyService, communicantRepository, notificationRepository);

        public async Task<IEnumerable<ListNotificationResponseDto>> ListNotificationAsync()
        {
            var list = await _notificationRepository.ListNotificationAsync();
            if (!list.IsAny<Notification>()) return null;

            var result = new List<ListNotificationResponseDto>();
            foreach (var item in list)
            {
                var notification = new ListNotificationResponseDto(item.Id, item.PolicyId, item.Stage, item.DateNotification)
                {
                    Situation = new DomainResponseDto(item.Situation.Id, item.Situation.Name),
                    Status = new DomainResponseDto(item.Status.Id, item.Status.Name),
                    Policy = new PolicyResponseDto(item.Policy.Id, item.Policy.ProposalNumber, item.Policy.PolicyId, item.Policy.EndorsementId, item.Policy.PolicyNumber, item.Policy.ProposalDate, item.Policy.PolicyDate, item.Policy.StartOfTerm, item.Policy.EndOfTerm.Date, item.Policy.Item)
                    {
                        Product = new(item.Policy.Product.Id, item.Policy.Product.Name, item.Policy.Product.ImageUrl),
                        InclusionUser = new(item.Policy.InclusionUserId, null),
                    }
                };

                result.Add(notification);
            }
            return result;
        }

        public async Task<GetCommunicantResponseDto> GetCommunicantAsync(int notificationId)
        {
            var entity = await _communicantRepository.GetByIdAsync(notificationId);
            if (entity is null) return null;

            var result = new GetCommunicantResponseDto(
                entity.Id, entity.NotificationId, entity.CommunicantTypeId, entity.Name, entity.InclusionUserId, entity.CreatedDate);

            foreach (var item in entity.CommunicantEmails)
                result.Email.Add(new EmailResponseDto(
                    item.Id, item.EmailTypeId, item.Email, item.CreatedDate));

            foreach (var item in entity.CommunicantPhones)
                result.Phone.Add(new PhoneResponseDto(
                    item.Id, item.PhoneTypeId, item.Ddd, item.Phone, item.CreatedDate));

            return result;
        }


        public async Task<int> SaveNotificationAsync(int policyId, int codeItem)
        {
            try
            {
                var list = await _policyService.ListPolicyAsync(policyId, null, null, null);
                if (!list.IsAny())
                    throw new BusinessException("Apolice não encontrada!");

                var policy = list.First();
                var result = await _notificationRepository.AddAsync(new Notification()
                {
                    Stage = 1,
                    StatusId = (int)StatusEnum.Incompleto,
                    SituationId = (int)SituationEnum.Aberto,
                    InclusionUserId = 1,
                    Policy = new Policy()
                    {
                        ProductId = 1,
                        PolicyId = policy.PolicyId,
                        EndorsementId = policy.EndorsementId,
                        ProposalNumber = policy.ProposalNumber,
                        PolicyNumber = policy.PolicyNumber,
                        ProposalDate = policy.ProposalDate,
                        Item = codeItem,
                        PolicyDate = policy.PolicyDate,
                        StartOfTerm = policy.StartOfTerm,
                        EndOfTerm = policy.EndOfTerm,
                        InclusionUserId = 1,
                    }
                });

                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveCommunicantAsync(SaveCommunicantRequestDto request, int userId)
        {
            try
            {
                var entity = new Communicant(request.NotificationIdId, request.CommunicantTypeId, request.Name, userId);
                foreach (var email in request.Email)
                    entity.CommunicantEmails.Add(new CommunicantEmail(default, default, email.EmailTypeId, email.Email, userId));

                foreach (var phone in request.Phone)
                    entity.CommunicantPhones.Add(new CommunicantPhone(default, default, phone.PhoneTypeId, phone.Ddd, phone.Phone, userId));

                var result = await _communicantRepository.AddAsync(entity);

                return result.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
