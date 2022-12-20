using SinisterApi.Domain.Models.Policy;

namespace SinisterApi.Service.Interfaces
{
    public interface IPolicyService
    {
        Task<PolicyModel> GetPolicyAsync(int policyId);
    }
}
