using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Policy : IIdentityEntity
    {
        public int Id { get; set; }
        public int ProposalNumber { get; set; }
        public int? PolicyIdReference { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? PolicyDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
