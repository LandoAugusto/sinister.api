using Application.DTO.Common;

namespace Application.DTO.Policy
{
    public class UpdatePolicyInsuredRequestDto
    {
        public List<AddressResquestDto> Address { get; set; } = new List<AddressResquestDto>();

        public List<PhoneRequestDto> Phone { get; set; } = new List<PhoneRequestDto>();
    }
}

