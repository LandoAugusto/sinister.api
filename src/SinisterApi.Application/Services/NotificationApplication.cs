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
                var proposal = await _policyService.ListPolicyAsync(policyId, null, null, null);
                if (proposal == null)
                    throw new BusinessException("Proposta não encontrada!");

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
