using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class AdditionalInformation : IIdentityEntity
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public bool IsContentious { get; set; }
        public DateTime? DateProcess { get; set; }
        public int? ProcessType { get; set; }
        public int? ProcessNumber{ get; set; }
        public bool IsPoliceReport { get; set; }
        public string PoliceReportNumber { get; set; }
        public bool IsThird { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
