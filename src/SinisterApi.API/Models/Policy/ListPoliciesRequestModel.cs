namespace SinisterApi.API.Models.Policy
{
    public class ListPoliciesRequestModel
    {
        public int? InsuredPersonId { get; set; }
        public int? StipulatorPersonId { get; set; }
        public int? PolicyId { get; set; }
        public int? Certificate { get; set; }
    }
}
