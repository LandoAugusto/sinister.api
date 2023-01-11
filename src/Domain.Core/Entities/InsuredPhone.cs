using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class InsuredPhone : IIdentityEntity
    {
        public int Id { get; set; }
        public int InsuredId { get; set; }
        public int PhoneTypeId { get; set; }
        public string? Ddd { get; set; }
        public string? Phone { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public virtual Insured Insured { get; set; } = null!;
        public virtual PhoneType PhoneType { get; set; } = null!;
    }
}
