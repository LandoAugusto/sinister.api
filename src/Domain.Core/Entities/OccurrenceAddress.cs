using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class OccurrenceAddrress : IIdentityEntity
    {
        public int Id { get; set; }
        public int OccurenceId { get; set; }
        public string ZipCode { get; set; } = null!;
        public string? StreetName { get; set; }
        public string StateName { get; set; } = null!;
        public string StateInitials { get; set; } = null!;
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }      
        public virtual Occurrence Occurence { get; set; } = null!;
    }
}
