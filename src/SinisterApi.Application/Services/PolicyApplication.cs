using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models.Policy;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Models;

namespace SinisterApi.Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;

        public PolicyApplication(IPolicyService policyService) =>
            _policyService = policyService;

        public async Task<PolicyModel> GetPolicyAsync(int policyId)
        {
         return  await _policyService.GetPolicyAsync(policyId);
        }
    }
}
