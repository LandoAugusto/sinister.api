namespace SinisterApi.Service.Schemas
{
    internal class ListInsuredResponseResponseModel
    {
        public bool Sucess { get; set; }
        public List<InsuredResponse> Data { get; set; }
    }

    internal class GetInsuredResponseResponseModel
    {
        public bool Sucess { get; set; }
        public InsuredResponse Data { get; set; }
    }

    internal class InsuredResponse
    {
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public long? DocumentNumber { get; set; }
        public PersonTypeResponse? PersonType { get; set; }
        public SegmentTypeResponse? SegmentType { get; set; }
        public List<AddressResponse>? Addressess { get; set; }
    }
}
