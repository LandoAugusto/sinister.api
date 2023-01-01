using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Domain.Core.Extensions;
using Domain.Core.Infrastructure.Exceptions;
using Integration.BMG.Interfaces;
using Application.DTO.Notification;
using SinisterApi.DTO.Notification;
using Infrastructure.Data.Repository.Interfaces.Repositories;

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

        public async Task<IEnumerable<NotificationResponseDto>> ListNotificationAsync()
        {
            var list = await _notificationRepository.GetAllAsync();
            if (!list.IsAny<Notification>()) return null;

            var result = new List<NotificationResponseDto>();
            foreach (var item in list)
                result.Add(new NotificationResponseDto(item.Id, item.PolicyId, item.Stage, item.DateNotification));

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
                        Item = 1,
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
                foreach(var email in request.Email)
                {
                    entity.CommunicantEmails.Add(new CommunicantEmail()
                    {
                        Email = email.Email,
                        EmailTypeId = email.EmailTypeId,
                        InclusionUserId = userId
                    }); 
                }

                foreach (var phone in request.Phone)
                {
                    entity.CommunicantPhones.Add(new CommunicantPhone()
                    {
                        Ddd = phone.Ddd,
                        PhoneTypeId = phone.PhoneTypeId,
                        Phone = phone.Phone,
                        InclusionUserId = userId
                    }); 
                }

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
