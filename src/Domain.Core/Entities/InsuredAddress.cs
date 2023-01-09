using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class InsuredAddress : IIdentityEntity
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string City { get; set; }
    }
}
