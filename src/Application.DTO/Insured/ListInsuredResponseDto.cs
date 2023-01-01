using Application.DTO.Common;

namespace Application.DTO.Insured
{
    public class ListInsuredResponseDto
    {
        public ListInsuredResponseDto(int? personId, string? name, long? documentNumber, List<AddressResponseDto> address)
        {
            this.PersonId = personId;
            this.Name = name;
            this.DocumentNumber = documentNumber;
            this.Address = address;
        }
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public long? DocumentNumber { get; set; }
        public List<AddressResponseDto> Address { get; set; } = new List<AddressResponseDto>();
    }
}
