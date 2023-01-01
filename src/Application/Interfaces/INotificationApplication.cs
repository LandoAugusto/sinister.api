using Application.DTO.Notification;
using SinisterApi.DTO.Notification;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<NotificationResponseDto>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
        Task<int> SaveCommunicantAsync(SaveCommunicantRequestDto request, int userId);
    }
}
