using Application.DTO.Policy;
using Application.Interfaces;
using Domain.Core.Extensions;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;

        public PolicyApplication(IPolicyService policyService) =>
            _policyService = policyService;

        public async Task<IList<PolicyResponseDto>?> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            var list = await _policyService.ListPolicyAsync(policyId, insuredPersonId, stipulatorPersonId, certificate);
            if (!list.IsAny<PolicyResponseDto>()) return null;

            return list;
        }
    }
}
