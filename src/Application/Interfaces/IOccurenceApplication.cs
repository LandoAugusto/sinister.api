using Application.DTO.Occurence;

namespace Application.Interfaces
{
    public interface IOccurenceApplication
    {
        Task<GetOccurenceResponseDto?> GetOccurrenceAsync(int notificaitonId);
        Task<int> UpdateSaveOccurrenceAsync(int userId, UpdateSaveOccurenceRequestDto request);
    }
}
