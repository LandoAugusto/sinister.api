using Application.DTO.Common;

namespace Application.DTO.Occurence
{
    internal class GetOccurenceResponseDto
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string DateOccurence { get; set; }
        public string TimeOccurrence { get; set; }
        public string DescriptonOccurence { get; set; }
        public string DescriptionDamage { get; set; }
        public decimal? Damage { get; set; }
        public string Comments { get; set; }
        public bool IsRiskLocation { get; set; }
        public IEnumerable<PhoneResponseDto> Phone { get; set; }        
        public IEnumerable<AddressResponseDto> Address { get; set; }
    }
}
