namespace SinisterApi.Domain.Models
{
    public class ProposalModel
    {
        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public DomainModel Status { get; set; }
        public BusinessModel Business { get; set; }
        public ProductModel Product { get; set; }
        public BrokerModel Broker { get; set; }
        //public TakerModel Taker { get; set; }
        public InsuredModel Insured { get; set; }
        //public ProposalBilling Billing { get; set; }
        //public ProposalWarranty Warranty { get; set; }

        //public InsuredObject InsuredObject { get; set; }
        public string? AttachedTextContents { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }
        public UserModel InclusionUser { get; set; }
        public UserModel LastChangeUser { get; set; }
    }
}
