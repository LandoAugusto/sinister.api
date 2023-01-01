using Application.DTO.Notification;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<NotificationResponseDto>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
