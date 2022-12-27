using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static class ProposalMap
    {
        public static ProposalModel Map(ProposalResponse proposal)
        {
            return new ProposalModel()
            {
                ProposalNumber = proposal.ProposalNumber,
                PolicyId = proposal.PolicyId,
                EndorsementId = proposal.EndorsementId,
                PolicyNumber = proposal.PolicyNumber,
                ProposalDate = proposal.ProposalDate,
                StartOfTerm = proposal.StartOfTerm,
                EndOfTerm = proposal.EndOfTerm,
                IsInformedPremium = proposal.IsInformedPremium,
                HasMaximumWarrantyLimit = proposal.HasMaximumWarrantyLimit,
                Product = new(proposal.Product.Id.Value, proposal.Product.Name, null),
                Business = new()
                {
                    Id = proposal.Business.Id,
                    Name = proposal.Business.Name,
                    SusepCode = proposal.Business.SusepCode,
                },
                Insured = new(
                 proposal.Insured.PersonId,
                 proposal.Insured.Name,
                 proposal.Insured.DocumentNumber),
                Broker = new()
                {
                    Name = proposal.Broker.Name,
                    DocumentNumber = proposal.Broker.DocumentNumber,
                    PersonId = proposal.Broker.PersonId,
                    SusepCode = proposal.Broker.SusepCode,
                },
                Status = new(proposal.Status.Id, proposal.Status.Name),
                InclusionUser = new(proposal.InclusionUser.Id, proposal.InclusionUser.Name),
                LastChangeUser = new(proposal.LastChangeUser.Id, proposal.LastChangeUser.Name)
            };
        }
    }
}
