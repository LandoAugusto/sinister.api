using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<NotificationModel>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
