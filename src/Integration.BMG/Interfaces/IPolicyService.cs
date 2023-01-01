using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IPolicyService
    {
        Task<IList<PolicyResponse>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
