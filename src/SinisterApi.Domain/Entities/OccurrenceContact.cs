using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class OccurrenceContact : IIdentityEntity
    {
        public int Id { get; set; }
        public int OccurenceId { get; set; }
        public string Name { get; set; }
        public int PhoneType { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
    }
}
