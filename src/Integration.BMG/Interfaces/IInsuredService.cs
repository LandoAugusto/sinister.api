using Application.DTO.Insured;
using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IInsuredService
    {
        Task<InsuredResponseDto> GetByIdAsync(int insuredPersonId);

        Task<List<InsuredResponseDto>> ListInsuredAsync(string name, string documentNumber);
    }
}
