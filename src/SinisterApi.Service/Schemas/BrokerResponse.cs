namespace SinisterApi.Service.Schemas
{
    internal class GetBrokerResponseModel
    {
        public bool Sucess { get; set; }
        public BrokerResponse Data { get; set; }
    }
    internal class BrokerResponse
    {
        public int? PersonId { get; set; }
        public long? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public string? SusepCode { get; set; }
        public int? UserId { get; set; }
        public PersonTypeResponse PersonType { get; set; }
        public AddressResponse Address { get; set; }
    }
}
