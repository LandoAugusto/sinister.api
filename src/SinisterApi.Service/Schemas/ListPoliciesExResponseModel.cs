namespace SinisterApi.Service.Schemas
{
    public class ListPoliciesExResponseModel
    {
        public bool Sucess { get; set; }
        public List<PoliciesExResponseModel> Data { get; set; }
    }

    public class PoliciesExResponseModel
    {
        public PoliciesExResponseModel()
        {
            Status = new();
            Business = new();
            Product = new();
            Coverage = new();
            Broker = new();
            Taker = new();
            Insured = new();
        }
        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? PolicyDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public StatusResponse Status { get; set; }
        public BusinessResponse Business { get; set; }
        public Product Product { get; set; }
        public CoverageResponse Coverage { get; set; }
        public BrokerResponse Broker { get; set; }
        public TakerResponse Taker { get; set; }
        public InsuredResponse Insured { get; set; }
        public decimal? InsuredAmount { get; set; }
        public decimal? MaximumWarrantyLimit { get; set; }
        public decimal? TariffPremium { get; set; }
        public decimal? NetPremium { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }

    }
}
