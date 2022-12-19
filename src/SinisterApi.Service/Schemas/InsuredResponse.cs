namespace SinisterApi.Service.Schemas
{
    public class InsuredResponse
    {
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public long? DocumentNumber { get; set; }
        public PersonTypeResponse? PersonType { get; set; }
        public SegmentTypeResponse? SegmentType { get; set; }
        public IList<AddressResponse>? Addressess { get; set; }
    }
}
