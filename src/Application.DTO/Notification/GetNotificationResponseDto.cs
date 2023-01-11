namespace Application.DTO.Notification
{
    public class GetNotificationResponseDto
    {
        public GetNotificationResponseDto(int id, int policyId, int stage, DateTime dateNotification)
        {
            Id = id;
            PolicyId = policyId;
            Phase = stage;
            DateNotification = dateNotification;
        }

        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int Phase { get; set; }
        public DateTime DateNotification { get; set; }
    }
}
