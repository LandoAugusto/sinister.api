namespace SinisterApi.Domain.Models
{
    public class NotificationModel
    {
        public NotificationModel(int id, int policyId, int stage, DateTime? dateNotification)
        {
            Id = id;
            PolicyId = policyId;
            Stage = stage;
            DateNotification = dateNotification;
        }

        public int Id { get; set; }
        public int PolicyId { get; set; }
        public DomainModel Situation { get; set; }
        public DomainModel Status { get; set; }
        public int Stage { get; set; }
        public DateTime? DateNotification { get; set; }
    }
}
