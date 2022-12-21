using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
{
    internal class InsurdeApplication : IInsurdeApplication
    {
        private readonly IInsuredService _insuredService;
        public InsurdeApplication(IInsuredService insuredService) =>
            _insuredService = insuredService;

        public async Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber)
        {
            return await _insuredService.ListInsuredAsync(name, documentNumber);
        }

        public async Task<InsuredModel> GetInsuredAsync(int insuredPersonId)
        {
            return await _insuredService.GetInsuredAsync(insuredPersonId);
        }
    }
}
