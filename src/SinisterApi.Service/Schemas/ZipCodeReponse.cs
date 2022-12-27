namespace SinisterApi.Service.Schemas
{

    internal class GetZipCodeResponseModel
    {
        public bool Sucess { get; set; }
        public ZipCodeReponse Data { get; set; }
    }
    internal class ZipCodeReponse
    {   
        public int? ZipCode { get; set; }
        public string? StreetName { get; set; }        
        public string? District { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
        public string? StateInitials { get; set; }
        public string? StateName { get; set; }
    }
}
