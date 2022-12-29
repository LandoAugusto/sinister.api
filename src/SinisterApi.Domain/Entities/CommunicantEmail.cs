using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class CommunicantEmail : IIdentityEntity
    {
        public int Id { get; set; }
        public int CommunicantId { get; set; }
        public int EmailTypeId { get; set; }
        public string Email { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
