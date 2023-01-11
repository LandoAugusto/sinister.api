using Application.DTO.Common;

namespace Application.DTO.Communicant
{
    public class UpdateSaveCommunicantRequestDto
    {
        public int NotificationId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmailRequestDto> Email { get; set; }
        public IEnumerable<PhoneRequestDto> Phone { get; set; }

    }
}
