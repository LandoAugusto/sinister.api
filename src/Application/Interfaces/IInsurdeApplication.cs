using Application.DTO.Insured;

namespace Application.Interfaces
{
    public interface IInsurdeApplication
    {
        Task<InsuredResponseDto> GetInsuredAsync(int insuredPersonId);
        Task<List<InsuredResponseDto>> ListInsuredAsync(string name, string documentNumber);
    }
}
