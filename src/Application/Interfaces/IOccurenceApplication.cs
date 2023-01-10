using Application.DTO.Occurence;

namespace Application.Interfaces
{
    public interface IOccurenceApplication
    {
        Task<int> SaveOccurrenceAsync(int userId, SaveOccurenceRequestDto request);
    }
}
