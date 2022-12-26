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
                //PolicyDate = proposal.PolicyDate,
                StartOfTerm = proposal.StartOfTerm,
                EndOfTerm = proposal.EndOfTerm,
                //InsuredAmount = proposal.InsuredAmount,
                //MaximumWarrantyLimit = proposal.MaximumWarrantyLimit,
                //TariffPremium = proposal.TariffPremium,
                //NetPremium = proposal.NetPremium,
                IsInformedPremium = proposal.IsInformedPremium,
                HasMaximumWarrantyLimit = proposal.HasMaximumWarrantyLimit,
                Product = new(proposal.Product.Id.Value, proposal.Product.Name, null),
                Business = new()
                {
                    Id = proposal.Business.Id,
                    Name = proposal.Business.Name,
                    SusepCode = proposal.Business.SusepCode,
                },
                Status = new()
                {
                    Id = proposal.Status.Id,
                    Name = proposal.Status.Name
                },
                Insured = new()
                {
                    PersonId = proposal.Insured.PersonId,
                    Name = proposal.Insured.Name,
                    DocumentNumber = proposal.Insured.DocumentNumber,
                },
                Broker = new()
                {
                    Name = proposal.Broker.Name,
                    DocumentNumber = proposal.Broker.DocumentNumber,
                    PersonId = proposal.Broker.PersonId,
                    SusepCode = proposal.Broker.SusepCode,
                },
                InclusionUser = new()
                {
                    Id = proposal.InclusionUser.Id,
                    Name = proposal.InclusionUser.Name,
                },
                LastChangeUser = new()
                {
                    Id = proposal.LastChangeUser.Id,
                    Name = proposal.LastChangeUser.Name,
                }
            };
        }
    }
}
