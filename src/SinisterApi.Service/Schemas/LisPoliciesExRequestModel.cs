namespace SinisterApi.Service.Schemas
{
    public class ListPoliciesExRequestModel
    {
        public ListPoliciesExRequestModel()
        {
            BrokerUsersIds = new List<int>();
        }
        public IList<int> BrokerUsersIds { get; set; }
        public int? InsuranceTypeId { get; set; }
        public int? PolicyId { get; set; }
        public long? PolicyNumber { get; set; }
        public long? PreviousPolicyNumber { get; set; }
        public int? ProposalNumber { get; set; }
        public int? BusinessId { get; set; }
        public int? ProductId { get; set; }
        public int? TakerPersonId { get; set; }
        public int? InsuredPersonId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public bool? SearchAllPolicies { get; set; }

    }
}
