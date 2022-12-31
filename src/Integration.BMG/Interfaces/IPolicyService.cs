using Domain.Core.Models;

namespace Integration.BMG.Interfaces
{
    public interface IPolicyService
    {
        Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
