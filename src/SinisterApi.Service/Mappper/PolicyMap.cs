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
                    Status = new()
                    {
                        Id = policy.Status.Id,
                        Name = policy.Status.Name
                    },
                    Insured = InsuredMap.Map(policy.Insured),
                    Broker = BrokerMap.Map(policy.Broker),
                    InclusionUser = new()
                    {
                        Id = policy.InclusionUser.Id,
                        Name = policy.InclusionUser.Name,
                    },
                    LastChangeUser = new()
                    {
                        Id = policy.LastChangeUser.Id,
                        Name = policy.LastChangeUser.Name,
                    }
                }); ; 
            }
            return result;
        }
    }
}
