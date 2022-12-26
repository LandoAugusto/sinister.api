using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static class PolicyMap
    {
        public static List<PolicyModel> Map(List<PolicyResponse> response)
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
                    Business = new()
                    {
                        Id = policy.Business.Id,
                        Name = policy.Business.Name,
                        SusepCode = policy.Business.SusepCode,
                    },                  
                    Insured = InsuredMap.Map(policy.Insured),
                    Broker = BrokerMap.Map(policy.Broker),
                    Status = new(policy.Status.Id, policy.Status.Name),
                    Product = new(policy.Product.Id.Value, policy.Product.Name, null),
                    InclusionUser = new(policy.InclusionUser.Id, policy.InclusionUser.Name),
                    LastChangeUser = new(policy.LastChangeUser.Id, policy.LastChangeUser.Name)
                });
            }
            return result;
        }
    }
}
