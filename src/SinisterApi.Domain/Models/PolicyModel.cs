namespace SinisterApi.Domain.Models
{
    public class PolicyModel
    {
        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? PolicyDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public StatusModel Status { get; set; }
        //public BusinessResponse Business { get; set; }
        public ProductModel Product { get; set; }
        //public CoverageResponse Coverage { get; set; }
        public BrokerModel Broker { get; set; }
        //public TakerResponse Taker { get; set; }
        public InsuredModel Insured { get; set; }
        public decimal? InsuredAmount { get; set; }
        public decimal? MaximumWarrantyLimit { get; set; }
        public decimal? TariffPremium { get; set; }
        public decimal? NetPremium { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }
        public Dictionary<string, string> Items { get; set; }

    }
}
