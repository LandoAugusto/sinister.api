using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Occurrence : IIdentityEntity
    {

        public Occurrence()
        {

        }
        public Occurrence(int notificationId, string dateOccurence, string timeOccurrence, string descriptonOccurence, string? descriptionDamage, decimal? damage, bool isRiskLocation, string? comments, int inclusionUserId)
        {
            this.NotificationId = notificationId;
            this.DateOccurrence = dateOccurence;
            this.TimeOccurrence = timeOccurrence;
            this.DescriptonOccurrence = descriptonOccurence;
            this.DescriptionDamage = descriptionDamage;
            this.Damage = damage;
            this.IsRiskLocation = isRiskLocation;
            this.Comments = comments;
            this.InclusionUserId = inclusionUserId;
        }

        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string DateOccurrence { get; set; } = null!;
        public string TimeOccurrence { get; set; } = null!;
        public string DescriptonOccurrence { get; set; } = null!;
        public string? DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public bool IsRiskLocation { get; set; }
        public string? Comments { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public virtual Notification Notification { get; set; } = null!;
        public virtual ICollection<OccurrenceAddress> OccurenceAddress { get; set; } = new HashSet<OccurrenceAddress>();
        public virtual ICollection<OccurrencePhone> OccurencePhone { get; set; } = new HashSet<OccurrencePhone>();
    }
}
