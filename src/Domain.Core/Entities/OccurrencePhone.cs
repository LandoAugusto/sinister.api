using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class OccurrencePhone : IIdentityEntity
    {
        public OccurrencePhone( string name, int phoneTypeId, string ddd, string phone, int inclusionUserId)
        {   
            Name = name;
            PhoneTypeId = phoneTypeId;
            Ddd = ddd;
            Phone = phone;
            InclusionUserId = inclusionUserId;
        }

        public int Id { get; set; }
        public int OccurrenceId { get; set; }
        public string Name { get; set; }
        public int PhoneTypeId { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public virtual Occurrence Occurence { get; set; } = null!;
    }
}
