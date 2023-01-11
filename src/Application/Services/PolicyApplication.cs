using Application.DTO.Policy;
using Application.Interfaces;
using Domain.Core.Extensions;
using Integration.BMG.Interfaces;
using Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;
        private readonly IPolicyRepository _policyRepository;
        private readonly INotificationApplication _notificationApplication;
        public PolicyApplication(IPolicyService policyService, INotificationApplication notificationApplication, IPolicyRepository policyRepository) =>
            (_policyService, _notificationApplication, _policyRepository) = (policyService, notificationApplication, policyRepository);

        public async Task<IList<ListPolicyResponseDto>?> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            var list = await _policyService.ListPolicyAsync(policyId, insuredPersonId, stipulatorPersonId, certificate);
            if (!list.IsAny<ListPolicyResponseDto>()) return null;

            return list;
        }

        public async Task<GetPolicyInsuredResponseDto?> GetPolicyInsuredAsync(int notificationId)
        {
            var notification = await _notificationApplication.GetNotificationAscync(notificationId);
            var policy = await _policyRepository.GetByIdAsync(notification.PolicyId);
            return new GetPolicyInsuredResponseDto(policy.Insured.Id, policy.Insured.InsuredId, policy.Insured.DocumentType, policy.Insured.Document, policy.Insured.Name);
        }
    }
}
