using SinisterApi.Domain.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IPolicyService
    {
        Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
