using Application.DTO.Notification;
using SinisterApi.DTO.Notification;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<ListNotificationResponseDto>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);


        #region Communicant

        Task<int> SaveCommunicantAsync(SaveCommunicantRequestDto request, int userId);
        Task<GetCommunicantResponseDto> GetCommunicantAsync(int notificationId);

        #endregion

    }
}
