using SinisterApi.DTO.Common;

namespace SinisterApi.DTO.Notification
{
    public class SaveCommunicantRequestModel
    {
        public int NotificationIdId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmailDTO> Email { get; set; }
        public IEnumerable<PhoneDto> Phone { get; set; }

    }
}
