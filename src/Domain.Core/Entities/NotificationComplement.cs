using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class NotificationComplement : IIdentityEntity
    {
        public NotificationComplement(int notificationId, bool isContentious, string? processNumber, DateTime? processDate, int? processTypeId, bool isPoliceReport, string? policeReportNumber, bool isThird, bool isProvedor)
        {
            NotificationId = notificationId;
            IsContentious = isContentious;
            ProcessNumber = processNumber;
            ProcessDate = processDate;
            ProcessTypeId = processTypeId;
            IsPoliceReport = isPoliceReport;
            PoliceReportNumber = policeReportNumber;
            IsThird = isThird;
            IsProvedor = isProvedor;
        }

        public int Id { get; set; }
        public int NotificationId { get; set; }
        public bool IsContentious { get; set; }
        public string? ProcessNumber { get; set; }
        public DateTime? ProcessDate { get; set; }
        public int? ProcessTypeId { get; set; }
        public bool IsPoliceReport { get; set; }
        public string? PoliceReportNumber { get; set; }
        public bool IsThird { get; set; }
        public bool IsProvedor { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public virtual ProcessType ProcessType { get; set; } = null!;
    }
}
