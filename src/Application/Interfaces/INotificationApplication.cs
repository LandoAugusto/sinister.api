using Application.DTO.Notification;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<GetNotificationResponseDto> GetNotificationAscync(int notificationId);
        Task<IEnumerable<ListNotificationResponseDto>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
