using Application.DTO.Policy;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappers
{
    internal static class PolicyMap
    {
        public static List<ListPolicyResponseDto> Map(IList<PolicyResponse> response)
        {
            var result = new List<ListPolicyResponseDto>();

            foreach (var item in response)
            {
                var policy = new ListPolicyResponseDto(default, item.ProposalNumber, item.PolicyId, item.EndorsementId, item.PolicyNumber, item.ProposalDate, item.PolicyDate, item.StartOfTerm, item.EndOfTerm)
                {
                    Broker = BrokerMap.Map(item.Broker),
                    Status = new(item.Status.Id, item.Status.Name),
                    Product = new(item.Product.Id, item.Product.Name),
                    Business = new(item.Business.Id, item.Business.SusepCode, item.Business.Name),
                    InclusionUser = new(item.InclusionUser.Id, item.InclusionUser.Name),
                    LastChangeUser = new(item.LastChangeUser.Id, item.LastChangeUser.Name),
                    Insured = new(item.Insured.PersonId, item.Insured.Name, item.Insured.DocumentNumber, AddressMap.Map(item.Insured.Addressess))
                };
                result.Add(policy);
            }
            return result;
        }
    }
}
