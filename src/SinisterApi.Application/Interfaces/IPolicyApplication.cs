using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface IPolicyApplication
    {
        Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
