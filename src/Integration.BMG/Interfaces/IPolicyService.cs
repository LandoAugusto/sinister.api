using Application.DTO.Policy;

namespace Integration.BMG.Interfaces
{
    public interface IPolicyService
    {
        Task<IList<PolicyResponseDto>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
