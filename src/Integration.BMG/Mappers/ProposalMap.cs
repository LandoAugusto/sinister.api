using Application.DTO.Proposal;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappers
{
    internal static class ProposalMap
    {
        public static ProposalResponseDto Map(ProposalResponse response)
        {
            return new ProposalResponseDto()
            {
                ProposalNumber = response.ProposalNumber,
                PolicyId = response.PolicyId,
                EndorsementId = response.EndorsementId,
                PolicyNumber = response.PolicyNumber,
                ProposalDate = response.ProposalDate,
                StartOfTerm = response.StartOfTerm,
                EndOfTerm = response.EndOfTerm,
                IsInformedPremium = response.IsInformedPremium,
                HasMaximumWarrantyLimit = response.HasMaximumWarrantyLimit,
                Product = new(response.Product.Id, response.Product.Name, null),
                Business = new(response.Business.Id, response.Business.SusepCode, response.Business.Name),
                Insured = new(response.Insured.PersonId, response.Insured.Name, response.Insured.DocumentNumber, AddressMap.Map(response.Insured.Addressess)),
                Broker = new(response.Broker.PersonId, response.Broker.DocumentNumber, response.Broker.Name, response.Broker.SusepCode),
                Status = new(response.Status.Id, response.Status.Name),
                InclusionUser = new(response.InclusionUser.Id, response.InclusionUser.Name),
                LastChangeUser = new(response.LastChangeUser.Id, response.LastChangeUser.Name)
            };
        }
    }
}
