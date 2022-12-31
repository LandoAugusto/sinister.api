using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
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
        public virtual CommunicantPhone CommunicantPhone { get; set; }

    }
}
