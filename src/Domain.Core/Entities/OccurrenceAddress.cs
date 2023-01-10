using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class OccurrenceAddress : IIdentityEntity
    {

        public OccurrenceAddress(string zipCode, string? streetName, string stateName, string stateInitials, string? number, string? complement, string? district, string? city, int inclusionUserId)
        {
            this.ZipCode = zipCode;
            this.StreetName = streetName;
            this.StateName = stateName;
            this.StateInitials = stateInitials;
            this.Number = number;
            this.Complement = complement;
            this.District = district;
            this.City = city;
            this.InclusionUserId = inclusionUserId;      
        }

        public int Id { get; set; }
        public int OccurrenceId { get; set; }
        public string ZipCode { get; set; } = null!;
        public string? StreetName { get; set; }
        public string StateName { get; set; } = null!;
        public string StateInitials { get; set; } = null!;
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }      
        public virtual Occurrence Occurence { get; set; } = null!;
    }
}
