using Application.DTO.Common;

namespace Application.DTO.Occurence
{
    public class SaveOccurenceRequestDto
    {
        public string DateOccurence { get; set; }
        public string TimeOccurrence { get; set; }
        public string DescriptonOccurence { get; set; }
        public string DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public string Comments { get; set; }
        public PhoneResponseDto Phone { get; set; }
        public bool IsRiskLocation { get; set; }
        public AddressResponseDto AddressRiskLocation { get; set; }
    }
}
