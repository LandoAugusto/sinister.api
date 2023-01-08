namespace Application.DTO.Notification
{
    public class ListNotificationRequestDto
    {
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }                
        public int? Status { get; set; }
        public int? Situatioon { get; set; }
        public int? ProductId { get; set; }        
    }
}
