using Application.DTO.Common;

namespace Application.DTO.Occurence
{
    public class GetOccurenceResponseDto
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string DateOccurence { get; set; }
        public string TimeOccurrence { get; set; }
        public string DescriptonOccurrence { get; set; }
        public string? DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public string? Comments { get; set; }
        public bool IsRiskLocation { get; set; }
        public List<OccurencePhoneResponseDto> Phone { get; set; } = new List<OccurencePhoneResponseDto>();
        public List<AddressResponseDto> Address { get; set; } = new List<AddressResponseDto>();
    }


    public class OccurencePhoneResponseDto
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int PhoneTypeId { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }        
    }
}
