using SinisterApi.Domain.Models.Policy;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static class PolicyMap
    {
        public static List<PolicyModel> Map(List<PoliciesExResponseModel> response)
        {
            var result = new List<PolicyModel>();

            foreach (var policy in response)
            {
                result.Add(new PolicyModel()
                {
                    ProposalNumber = policy.ProposalNumber,
                    PolicyId = policy.PolicyId,
                    EndorsementId = policy.EndorsementId,
                    PolicyNumber = policy.PolicyNumber,
                    ProposalDate = policy.ProposalDate,
                    PolicyDate = policy.PolicyDate,
                    StartOfTerm = policy.StartOfTerm,
                    EndOfTerm = policy.EndOfTerm,
                    InsuredAmount = policy.InsuredAmount,
                    MaximumWarrantyLimit = policy.MaximumWarrantyLimit,
                    TariffPremium = policy.TariffPremium,
                    NetPremium = policy.NetPremium,
                    IsInformedPremium = policy.IsInformedPremium,
                    HasMaximumWarrantyLimit = policy.HasMaximumWarrantyLimit,
                    Insured = new()
                    {
                        PersonId = policy.Insured.PersonId,
                        Name = policy.Insured.Name,
                        DocumentNumber = policy.Insured.DocumentNumber
                    }
                });
            }
            return result;
        }
    }
}
