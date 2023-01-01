using Application.DTO.Broker;
using Application.DTO.Bussiness;
using Application.DTO.Common;
using Application.DTO.Insured;
using Application.DTO.Product;
using Application.DTO.User;

namespace Application.DTO.Proposal
{
    public class ProposalResponseDto
    {
        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public DomainResponseDto Status { get; set; }
        public BusinessResponseDto Business { get; set; }
        public ProductResponseDto Product { get; set; }
        public BrokerResponseDto Broker { get; set; }     
        public InsuredResponseDto Insured { get; set; }    
        public string? AttachedTextContents { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }
        public UserResponseDto InclusionUser { get; set; }
        public UserResponseDto LastChangeUser { get; set; }
    }
}
