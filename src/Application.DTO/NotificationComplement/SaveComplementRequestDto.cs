namespace Application.DTO.NotificationComplement
{
    public class SaveComplementRequestDto
    {
        public int NotificationId { get; set; }
        public bool IsContentious { get; set; }
        public string? ProcessNumber { get; set; }
        public DateTime? ProcessDate { get; set; }
        public int? ProcessTypeId { get; set; }
        public bool IsPoliceReport { get; set; }
        public string? PoliceReportNumber { get; set; }
        public bool IsThird { get; set; }
        public bool IsProvedor { get; set; }
    }
}
