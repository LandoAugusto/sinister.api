using Application.DTO.NotificationComplement;

namespace Application.Interfaces
{
    public interface INotificationComplementApplication
    {
        Task<int> UpdateSaveComplementAsync(int userId, UpdateSaveComplementRequestDto request);
    }
}
