using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class EmailType : IIdentityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<CommunicantEmail> CommunicantEmail { get; set; }
        public virtual ICollection<InsuredEmail> InsuredEmail { get; set; }
    }
}
