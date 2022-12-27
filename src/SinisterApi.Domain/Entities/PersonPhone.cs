using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class PersonPhone : IIdentityEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PhoneType { get; set; }
        public string DDD { get; set; }
        public string Number { get; set; }
    }
    }
