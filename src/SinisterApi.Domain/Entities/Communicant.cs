using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Communicant : IIdentityEntity
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual CommunicantType CommunicantType { get; set; } = null!;
        public virtual ICollection<CommunicantEmail> CommunicantEmails { get; set; }
        public virtual ICollection<CommunicantPhone> CommunicantPhones { get; set; }

    }
}
