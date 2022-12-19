using SinisterApi.Domain.Models.Policy;

namespace SinisterApi.Application.Interfaces
{
    public interface IPolicyApplication
    {
        Task<PolicyModel> GetPolicyAsync(int policyId);
    }
}
