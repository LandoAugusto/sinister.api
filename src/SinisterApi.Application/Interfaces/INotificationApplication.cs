using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<NotificationModel>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
