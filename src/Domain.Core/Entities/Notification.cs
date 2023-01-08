using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Notification : IIdentityEntity
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int SituationId { get; set; }
        public int StatusId { get; set; }
        public int Stage { get; set; }
        public DateTime DateNotification { get; set; } = DateTime.Now;
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public virtual Policy Policy { get; set; } = null!;
        public virtual Situation Situation { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<Communicant> Communicants { get; set; }
    }
}
