using Application.DTO.Communicant;

namespace Application.Interfaces
{
    public interface ICommunicantApplication
    {
        Task<GetCommunicantResponseDto> GetCommunicantAsync(int notificationId);

        Task<int> SaveCommunicantAsync(SaveCommunicantRequestDto request, int userId);
    }
}
