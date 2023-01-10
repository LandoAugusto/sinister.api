using Application.DTO.Notification;
using Domain.Core.Eums;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<GetNotificationResponseDto?> GetNotificationAscync(int notificationId);
        Task<IEnumerable<ListNotificationResponseDto>?> ListNotificationAsync();
        Task UpdateStageNotificationAscync(int notificationId, PhaseEnum phase);
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
