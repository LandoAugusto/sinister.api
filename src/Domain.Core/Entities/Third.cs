using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Third : IIdentityEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int NotificationId { get; set; }
        public bool IsHaveInsurance { get; set; }
        public int? InsuranceId { get; set; }
        public int PolicyNumber { get; set; }        
    }
}
