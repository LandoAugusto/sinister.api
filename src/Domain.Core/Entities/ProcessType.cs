using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class ProcessType : IIdentityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<NotificationComplement> NotificationComplement { get; set; } = new HashSet<NotificationComplement>();
    }
}
