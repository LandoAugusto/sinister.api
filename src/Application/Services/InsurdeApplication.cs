using Application.DTO.Insured;
using Application.Interfaces;
using Application.Mappers;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class InsurdeApplication : IInsurdeApplication
    {
        private readonly IInsuredService _insuredService;
        public InsurdeApplication(IInsuredService insuredService) =>
            _insuredService = insuredService;

        public async Task<List<InsuredResponseDto>> ListInsuredAsync(string name, string documentNumber)
        {
            return InsuredMap.Map(await _insuredService.ListInsuredAsync(name, documentNumber));
        }
        public async Task<InsuredResponseDto> GetInsuredAsync(int insuredPersonId)
        {
            return InsuredMap.Map(await _insuredService.GetInsuredAsync(insuredPersonId));
        }
    }
}
