using Application.DTO.Insured;
using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IInsuredService
    {
        Task<InsuredResponseDto> GetInsuredAsync(int insuredPersonId);

        Task<List<InsuredResponseDto>> ListInsuredAsync(string name, string documentNumber);
    }
}
