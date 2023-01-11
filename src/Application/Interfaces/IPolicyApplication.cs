using Application.DTO.Policy;

namespace Application.Interfaces
{
    public interface IPolicyApplication
    {
        Task<IList<ListPolicyResponseDto>?> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate);
        Task<GetPolicyInsuredResponseDto?> GetPolicyInsuredAsync(int notificationId);
        Task<int> UpdatePolicyInsuredAsync(int id, int notificationId, UpdatePolicyInsuredRequestDto request);
    }
}
