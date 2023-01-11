using Application.DTO.Insured;

namespace Application.Interfaces
{
    public interface IInsuredApplication
    {
        Task<InsuredResponseDto?> GetByIdAsync(int insuredPersonId);
        Task<List<InsuredResponseDto>?> ListInsuredAsync(string name, string documentNumber);
    }
}
