using Application.DTO.Policy;
using Integration.BMG.Schemas;

namespace Application.Mappers
{
    internal static class PolicyMap
    {
        public static List<PolicyResponseDto> Map(IList<PolicyResponse> response)
        {
            var result = new List<PolicyResponseDto>();

            foreach (var policy in response)
            {
                result.Add(new PolicyResponseDto()
                {
                    ProposalNumber = policy.ProposalNumber,
                    PolicyId = policy.PolicyId,
                    EndorsementId = policy.EndorsementId,
                    PolicyNumber = policy.PolicyNumber,
                    ProposalDate = policy.ProposalDate,
                    PolicyDate = policy.PolicyDate,
                    StartOfTerm = policy.StartOfTerm,
                    EndOfTerm = policy.EndOfTerm,
                    Broker = BrokerMap.Map(policy.Broker),
                    Status = new(policy.Status.Id, policy.Status.Name),
                    Product = new(policy.Product.Id, policy.Product.Name, null),
                    Business = new(policy.Business.Id, policy.Business.SusepCode, policy.Business.Name),
                    InclusionUser = new(policy.InclusionUser.Id, policy.InclusionUser.Name),
                    LastChangeUser = new(policy.LastChangeUser.Id, policy.LastChangeUser.Name),
                    Insured = new(policy.Insured.PersonId, policy.Insured.Name, policy.Insured.DocumentNumber, AddressMap.Map(policy.Insured.Addressess)),
                });
            }
            return result;
        }
    }
}
