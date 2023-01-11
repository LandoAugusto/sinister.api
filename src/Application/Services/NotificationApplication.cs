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

namespace Application.Services
{
    internal class NotificationApplication : INotificationApplication
    {
        private readonly IPolicyService _policyService;
        private readonly INotificationRepository _notificationRepository;
        public NotificationApplication(
            IPolicyService policyService,
            INotificationRepository notificationRepository) =>
            (_policyService, _notificationRepository) = (policyService, notificationRepository);

        public async Task<GetNotificationResponseDto?> GetNotificationAscync(int notificationId)
        {
            var entity = await _notificationRepository.GetByIdAsync(notificationId);
            if (entity == null) return null;

            return new(entity.Id, entity.PolicyId, entity.PhaseId, entity.DateNotification); ;
        }
        public async Task<IEnumerable<ListNotificationResponseDto>?> ListNotificationAsync()
        {
            var list = await _notificationRepository.ListNotificationAsync();
            if (!list.IsAny<Notification>()) return null;

            var result = new List<ListNotificationResponseDto>();
            foreach (var item in list)
            {
                var notification = new ListNotificationResponseDto(item.Id, item.PolicyId, item.PhaseId, item.DateNotification)
                {
                    Situation = new DomainResponseDto(item.Situation.Id, item.Situation.Name),
                    Status = new DomainResponseDto(item.Status.Id, item.Status.Name),
                    Policy = new ListPolicyResponseDto(item.Policy.Id, item.Policy.ProposalNumber, item.Policy.PolicyId, item.Policy.EndorsementId, item.Policy.PolicyNumber, item.Policy.ProposalDate, item.Policy.PolicyDate, item.Policy.StartOfTerm, item.Policy.EndOfTerm.Date, item.Policy.Item)
                    {
                        Product = new(item.Policy.Product.Id, item.Policy.Product.Name, item.Policy.Product.ImageUrl),
                        InclusionUser = new(item.Policy.InclusionUserId, null),
                    }
                };

                result.Add(notification);
            }
            return result;
        }
        public async Task UpdateStageNotificationAscync(int notificationId, PhaseEnum phase)
        {
            var entity = await _notificationRepository.GetByIdAsync(notificationId);
            if (entity == null)
                throw new BusinessException("Erro ao atualizar status do aviso");

            entity.PhaseId = (int)phase;
            await _notificationRepository.UpdateAsync(entity);
        }
        public async Task<int> SaveNotificationAsync(int policyId, int codeItem)
        {
            try
            {
                var list = await _policyService.ListPolicyAsync(policyId, null, null, null);
                if (!list.IsAny())
                    throw new BusinessException("Apolice não encontrada!");

                var policy = list.First();
                var notification = new Notification()
                {
                    PhaseId = (int)PhaseEnum.Communicant,
                    StatusId = (int)StatusNotificationEnum.Incompleto,
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
                };

                notification.Policy.Insured = new Insured()
                {
                    DocumentType = 1,
                    InsuredId = policy.Insured.PersonId.Value,
                    Name = policy.Insured.Name,
                    Document = policy.Insured.DocumentNumber.ToString(),
                    InclusionUserId = 1,
                };

                var result = await _notificationRepository.AddAsync(notification);
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
