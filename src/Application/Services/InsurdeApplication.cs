using Application.DTO.Insured;
using Application.Interfaces;
using Domain.Core.Extensions;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class InsurdeApplication : IInsurdeApplication
    {
        private readonly IInsuredService _insuredService;
        public InsurdeApplication(IInsuredService insuredService) =>
            _insuredService = insuredService;

        public async Task<List<InsuredResponseDto>?> ListInsuredAsync(string name, string documentNumber)
        {
            var list = await _insuredService.ListInsuredAsync(name, documentNumber);
            if (!list.IsAny<InsuredResponseDto>()) return null;

            return list;

        }
        public async Task<InsuredResponseDto?> GetInsuredAsync(int insuredPersonId)
        {
            var response = await _insuredService.GetInsuredAsync(insuredPersonId);
            if (response == null) return null;

            return response;
        }
    }
}
