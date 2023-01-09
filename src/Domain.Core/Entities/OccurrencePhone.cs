using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class OccurrencePhone : IIdentityEntity
    {
        public int Id { get; set; }
        public int OccurenceId { get; set; }
        public string Name { get; set; }
        public int PhoneType { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Occurrence Occurence { get; set; } = null!;
    }
}
