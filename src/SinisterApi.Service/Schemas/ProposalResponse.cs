namespace SinisterApi.Service.Schemas
{
    internal class GetBusinnesProposalResponseModel
    {
        public bool Sucess { get; set; }
        public ProposalResponse Data { get; set; }
    }

    internal class ProposalResponse
    {
        public ProposalResponse()
        {
            this.Status = new StatusResponse();
            this.Business = new BusinessResponse();
            this.Product = new ProductResponse();
            this.Broker = new BrokerResponse();
            this.Taker = new TakerResponse();
            this.Insured = new InsuredResponse();
            //this.Billing = new ProposalBilling();
            //this.Warranty = new ProposalWarranty();

            //this.InsuredObject = new InsuredObject();
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
        //public ProposalBilling Billing { get; set; }
        //public ProposalWarranty Warranty { get; set; }

        //public InsuredObject InsuredObject { get; set; }
        public string? AttachedTextContents { get; set; }
        public bool IsInformedPremium { get; set; }
        public bool HasMaximumWarrantyLimit { get; set; }
        public UserResponse InclusionUser { get; set; }
        public UserResponse LastChangeUser { get; set; }

        //public IList<ProposalInstallment>? Installments { get; set; }
        //public IList<ProposalCoBroker>? CoBrokers { get; set; }
        //public IList<ProposalItem>? Items { get; set; }
        //public IList<ProposalCoInsurance>? CoInsurance { get; set; }

    }
}