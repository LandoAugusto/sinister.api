using Application.DTO.Occurence;

namespace Application.Interfaces
{
    public interface IOccurenceApplication
    {
        Task<GetOccurenceResponseDto?> GetOccurrenceAsync(int notificaitonId);
        Task<int> SaveOccurrenceAsync(int userId, SaveOccurenceRequestDto request);
    }
}
