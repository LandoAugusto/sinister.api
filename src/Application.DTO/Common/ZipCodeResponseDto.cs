namespace Application.DTO.Common
{
    public class ZipCodeResponseDto
    {
        public ZipCodeResponseDto(string? streetName, string? district, string? cityName, string? stateInitials, string? stateName)
        {
            StreetName = streetName;
            District = district;
            CityName = cityName;
            StateInitials = stateInitials;
            StateName = stateName;
        }

        public string? StreetName { get; set; }
        public string? District { get; set; }
        public string? CityName { get; set; }
        public string? StateInitials { get; set; }
        public string? StateName { get; set; }
    }
}
