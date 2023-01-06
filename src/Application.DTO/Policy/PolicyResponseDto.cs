using Application.DTO.Broker;
using Application.DTO.Bussiness;
using Application.DTO.Common;
using Application.DTO.Insured;
using Application.DTO.Product;
using Application.DTO.User;

namespace Application.DTO.Policy
{
    public class PolicyResponseDto
    {
        public PolicyResponseDto(int id, int proposalNumber, int policyId, string endorsementId, long policyNumber, DateTime proposalDate, DateTime policyDate, DateTime startOfTerm, DateTime endOfTerm, int item = 0)
        {
            Id = id;
            ProposalNumber = proposalNumber;
            PolicyId = policyId;
            EndorsementId = endorsementId;
            PolicyNumber = policyNumber;
            ProposalDate = proposalDate;
            PolicyDate = policyDate;
            StartOfTerm = startOfTerm;
            EndOfTerm = endOfTerm;
            Item = item;            
        }

        public int Id { get; set; }
        public int ProposalNumber { get; set; }
        public int PolicyId { get; set; }        
        public string EndorsementId { get; set; }
        public long PolicyNumber { get; set; }
        public DateTime ProposalDate { get; set; }
        public DateTime PolicyDate { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime EndOfTerm { get; set; }
        public int Item { get; set; }
        public DomainResponseDto Status { get; set; }
        public BusinessResponseDto Business { get; set; }
        public ProductResponseDto Product { get; set; }
        public BrokerResponseDto Broker { get; set; }
        public InsuredResponseDto Insured { get; set; }
        public UserResponseDto InclusionUser { get; set; }
        public UserResponseDto LastChangeUser { get; set; }
    }
}
