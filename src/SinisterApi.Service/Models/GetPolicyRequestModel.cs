namespace SinisterApi.Service.Models
{
    internal class GetPolicyRequestModel
    {
        public int? PolicyId { get; set; }
        public int? Proposal { get; set; }
        public int Susep { get; set; }
        public int? TakerId { get; set; }
        public string? ProductId { get; set; }
        public int? InsuredId { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
