using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Communicant : IIdentityEntity
    {
        public int Id { get; set; }
        public int CommunicantTypeId { get; set; }
        public int NotificationId { get; set; }
        public int PersonId { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Person Person { get; set; }
    }
}
