using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Occurrence : IIdentityEntity
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string DateOccurence { get; set; } = null!;
        public string TimeOccurrence { get; set; } = null!;
        public string DescriptonOccurence { get; set; } = null!;
        public string? DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public bool? IsRiskLocation { get; set; }
        public string? Comments { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Notification Notification { get; set; } = null!;
        public virtual ICollection<OccurrenceAddrress> OccurenceAddress { get; set; }
        public virtual ICollection<OccurrencePhone> OccurencePhone { get; set; }
    }
}
