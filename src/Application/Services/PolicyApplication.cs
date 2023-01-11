using Application.DTO.Policy;
using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Domain.Core.Extensions;
using Integration.BMG.Interfaces;
using Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class PolicyApplication : IPolicyApplication
    {
        private readonly IPolicyService _policyService;
        private readonly IPolicyRepository _policyRepository;
        private readonly IInsuredRepository _insuredRepository;
        private readonly INotificationApplication _notificationApplication;
        public PolicyApplication(IPolicyService policyService, INotificationApplication notificationApplication, IInsuredRepository insuredRepository, IPolicyRepository policyRepository) =>
            (_policyService, _notificationApplication, _insuredRepository, _policyRepository) = (policyService, notificationApplication, insuredRepository, policyRepository);

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

        public async Task<int> UpdatePolicyInsuredAsync(int id, int notificationId, UpdatePolicyInsuredRequestDto request)
        {
            var insured = await _insuredRepository.GetByIdAsync(id);

            insured.InsuredAddress.Clear();
            insured.InsuredPhone.Clear();
            foreach (var itemAddr in request.Address)
            {
                insured.InsuredAddress.Add(new InsuredAddress()
                {
                    InsuredId = insured.InsuredId,
                    ZipCode = itemAddr.ZipCode,
                    StreetName = itemAddr.StreetName,
                    StateName = itemAddr.StateName,
                    StateInitials = itemAddr.StateInitials,
                    Number = itemAddr.Number,
                    Complement = itemAddr.Complement,
                    District = itemAddr.District,
                    City = itemAddr.City,
                    InclusionUserId = 1,
                });
            }
            foreach (var itemPhone in request.Phone)
            {
                insured.InsuredPhone.Add(new InsuredPhone()
                {
                    InsuredId = insured.InsuredId,
                    PhoneTypeId = itemPhone.PhoneTypeId,
                    Ddd = itemPhone.Ddd,
                    Phone = itemPhone.Phone,
                    InclusionUserId = 1,
                });
            }
            var response = await _insuredRepository.UpdateAsync(insured);
            await _notificationApplication.UpdateStageNotificationAscync(notificationId, PhaseEnum.AdditionalInformation);

            return response;
        }
    }
}
