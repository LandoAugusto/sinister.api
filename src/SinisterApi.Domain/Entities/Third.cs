using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Third : IIdentityEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int NotificationId { get; set; }
        public bool IsHaveInsurance { get; set; }
        public int? InsuranceId { get; set; }
        public int PolicyNumber { get; set; }
        public Person Person { get; set; }
    }
}
