namespace SinisterApi.DTO.Sinister
{
    public class ListSinisterNotificationRequestModel
    {
        public int? InsuredPersonId { get; set; }
        public int? StipulatorPersonId { get; set; }
        public int? PolicyId { get; set; }
        public int? ProtocolNumber { get; set; }
        public int? SinisterId { get; set; }
        public int? ProductId { get; set; }
        public int? StatuSinisterId { get; set; }
        public int? PeriodTypeId { get; set; }
        public DateTime? DateInitial { get; set; }
        public DateTime? DateEnd { get; set; }

    }
}
