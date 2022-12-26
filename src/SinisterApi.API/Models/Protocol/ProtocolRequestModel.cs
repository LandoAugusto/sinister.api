using SinisterApi.Domain.Models;

namespace SinisterApi.API.Models.Protocol
{
    public class ProtocolRequestModel
    {
        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime ProposalDate { get; set; }
        public DateTime PolicyDate { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime EndOfTerm { get; set; }
        public StatusModel Status { get; set; }
        public BusinessModel Business { get; set; }
        public ProductModel Product { get; set; }
        
    }
}
