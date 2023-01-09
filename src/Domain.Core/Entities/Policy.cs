using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Policy : IIdentityEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string EndorsementId { get; set; } = null!;
        public int ProposalNumber { get; set; }
        public DateTime ProposalDate { get; set; }
        public int PolicyId { get; set; }
        public long PolicyNumber { get; set; }
        public DateTime PolicyDate { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime EndOfTerm { get; set; }
        public int Item { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Insured> Insureds { get; set; } = new HashSet<Insured>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();

    }
}
