using Application.DTO.NotificationComplement;

namespace Application.Interfaces
{
    public interface INotificationComplementApplication
    {
        Task<int> SaveNotificationComplementAsync(SaveComplementRequestDto request);
    }
}
