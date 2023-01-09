using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class InsuredEmail : IIdentityEntity
    {   
        public int Id { get; set; }
        public int InsuredId { get; set; }
        public int EmailTypeId { get; set; }
        public string? Email { get; set; }
        public bool SendAutomatic { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual EmailType EmailType { get; set; } = null!;
        public virtual Insured Insured { get; set; } = null!;

    }
}
