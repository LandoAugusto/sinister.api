using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class PersonAddress : IIdentityEntity
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
