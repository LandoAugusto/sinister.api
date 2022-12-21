using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models.Policy;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;

        public PolicyApplication(IPolicyService policyService) =>
            _policyService = policyService;

        public async Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            return await _policyService.ListPolicyAsync(policyId, insuredPersonId, stipulatorPersonId, certificate);
        }
    }
}
