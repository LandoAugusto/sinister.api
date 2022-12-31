﻿using Application.Interfaces;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Domain.Core.Extensions;
using Domain.Core.Infrastructure.Exceptions;
using Domain.Core.Models;
using Integration.BMG.Interfaces;

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
            (_policyService, _communicantRepository, _notificationRepository) = (policyService, communicantRepository,notificationRepository);

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

                var policy = list.First();
                var result = await _notificationRepository.AddAsync(new Notification()
                {
                    Stage = 1,
                    StatusId = StatusEnum.Incompleto,
                    SituationId = SituationEnum.Aberto,              
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

        public async Task<int> SaveNotificationAsync(Communicant entity)
        {
            try
            {


                return 1;
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
