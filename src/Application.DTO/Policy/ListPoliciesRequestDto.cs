namespace Application.DTO.Policy
{
    public class ListPoliciesRequestDto
    {
        public int? InsuredPersonId { get; set; }
        public int? StipulatorPersonId { get; set; }
        public int? PolicyId { get; set; }
        public int? Certificate { get; set; }
    }
}
