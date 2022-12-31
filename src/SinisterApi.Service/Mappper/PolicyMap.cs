using Domain.Core.Models;
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
