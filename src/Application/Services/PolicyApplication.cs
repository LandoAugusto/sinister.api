using Application.Interfaces;
using Domain.Core.Extensions;
using Domain.Core.Models;
using SinisterApi.Service.Interfaces;

namespace Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;

        public PolicyApplication(IPolicyService policyService) =>
            _policyService = policyService;

        public async Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            var policys = await _policyService.ListPolicyAsync(policyId, insuredPersonId, stipulatorPersonId, certificate);

            if (policys.IsAny<PolicyModel>())
            {

            }
            return policys;
        }
    }
}
