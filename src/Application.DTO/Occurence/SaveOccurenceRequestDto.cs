using Application.DTO.Common;

namespace Application.DTO.Occurence
{
    public class SaveOccurenceRequestDto
    {
        public int NotificationId { get; set; }
        public string DateOccurence { get; set; }
        public string TimeOccurrence { get; set; }
        public string DescriptonOccurence { get; set; }
        public string DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public string Comments { get; set; }
        public IEnumerable<PhoneRequestDto> Phone { get; set; }
        public bool IsRiskLocation { get; set; }
        public IEnumerable<AddressResquestDto> Address { get; set; }
    }
}
