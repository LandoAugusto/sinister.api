using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Product : IIdentityEntity
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string  ExternalId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
