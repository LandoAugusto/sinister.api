﻿
using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Entities;
using SinisterApi.Domain.Extensions;
using SinisterApi.Domain.Infrastructure.Exceptions;
using SinisterApi.Domain.Models;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
{
    internal class NotificationApplication : INotificationApplication
    {
        private readonly IPolicyService _policyService;
        private readonly INotificationRepository _notificationRepository;
        public NotificationApplication(IPolicyService policyService, INotificationRepository notificationRepository) =>
            (_policyService, _notificationRepository) = (policyService, notificationRepository);

        public async Task<IEnumerable<NotificationModel>> ListNotificationAsync()
        {
            var list = await _notificationRepository.GetAllAsync();
            if (!list.IsAny<Notification>()) return null;

            var result = new List<NotificationModel>();
            foreach (var item in list)
                result.Add(new NotificationModel(item.Id, item.PolicyId, item.Stage, item.DateNotification));

            return result;
        }

        public async Task<int> SaveNotificationAsync(int policyId, int codeItem)
        {
            try
            {
                var list = await _policyService.ListPolicyAsync(policyId, null, null, null);
                if (!list.IsAny())
                    throw new BusinessException("Apolice não encontrada!");

                var policy = list.FirstOrDefault();
                var result = await _notificationRepository.AddAsync(new Notification()
                {
                    Stage = 1,
                    StatusId = 1,
                    SituationId = 1,              
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
    }
}
