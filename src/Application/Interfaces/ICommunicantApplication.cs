using Application.DTO.Communicant;

namespace Application.Interfaces
{
    public interface ICommunicantApplication
    {
        Task<GetCommunicantResponseDto> GetCommunicantAsync(int notificationId);

        Task<int> UpdateSaveCommunicantAsync(UpdateSaveCommunicantRequestDto request, int userId);
    }
}
