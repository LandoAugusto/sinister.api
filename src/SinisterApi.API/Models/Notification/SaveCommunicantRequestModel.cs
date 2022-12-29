using SinisterApi.API.Models.Common;

namespace SinisterApi.API.Models.Notification
{
    public class SaveCommunicantRequestModel
    {
        public int NotificationIdId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmailRequestModel> Email { get; set; }
        public IEnumerable<PhoneRequestModel> Phone { get; set; }

    }
}
