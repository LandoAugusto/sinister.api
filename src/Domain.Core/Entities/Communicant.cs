using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Communicant : IIdentityEntity
    {
        public Communicant(int notificationId, int CommunicantTypeId, string name, int inclusionUserId)
        {
            this.NotificationId = notificationId;
            this.CommunicantTypeId = CommunicantTypeId;
            this.Name = name;
            this.InclusionUserId = inclusionUserId;
        }
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public virtual Notification Notification { get; set; } = null!;
        public virtual CommunicantType CommunicantType { get; set; } = null!;
        public virtual ICollection<CommunicantEmail> CommunicantEmail { get; set; } = new HashSet<CommunicantEmail>();
        public virtual ICollection<CommunicantPhone> CommunicantPhone { get; set; } = new HashSet<CommunicantPhone>();

    }
}
