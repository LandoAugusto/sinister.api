namespace Integration.BMG.Schemas
{
    internal class GetBusinnesProposalResponseModel
    {
        public bool Sucess { get; set; }
        public ProposalResponse Data { get; set; }
    }

    public class ProposalResponse
    {
        public ProposalResponse()
        {
            this.Status = new StatusResponse();
            this.Business = new BusinessResponse();
            this.Product = new ProductResponse();
            this.Broker = new BrokerResponse();
            this.Taker = new TakerResponse();
            this.Insured = new InsuredResponse();
            this.InclusionUser = new UserResponse();
            this.LastChangeUser = new UserResponse();
        }

        public int ProposalNumber { get; set; }
        public int? PolicyId { get; set; }
        public int? EndorsementId { get; set; }
        public long? PolicyNumber { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public StatusResponse Status { get; set; }
        public BusinessResponse Business { get; set; }
        public ProductResponse Product { get; set; }
        public BrokerResponse Broker { get; set; }
        public TakerResponse Taker { get; set; }
        public InsuredResponse Insured { get; set; }
        public string? AttachedTextContents { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }
        public UserResponse InclusionUser { get; set; }
        public UserResponse LastChangeUser { get; set; }

    }
}