using Application.DTO.Policy;

namespace Application.Interfaces
{
    public interface IPolicyApplication
    {
        Task<IList<PolicyResponseDto>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
    }
}
