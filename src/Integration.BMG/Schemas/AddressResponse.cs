namespace Integration.BMG.Schemas
{

 

    internal class AddressResponse
    {
        public int? Id { get; set; }
        public AddressTypeResponse AddressType { get; set; }
        public int? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public CityResponse City { get; set; }
        public bool IsMainAddress { get; set; }
    }
}
