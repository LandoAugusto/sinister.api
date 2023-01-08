using Application.DTO.Common;

namespace Application.DTO.Communicant
{
    public class GetCommunicantResponseDto
    {

        public GetCommunicantResponseDto(int id, int notificationId, int communicantTypeId, string name, int inclusionUserId, DateTime createdDate)
        {
            Id = id;
            NotificationId = notificationId;
            CommunicantTypeId = communicantTypeId;
            Name = name;
            Name = name;
            InclusionUserId = inclusionUserId;
            CreatedDate = createdDate;
        }
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<EmailResponseDto> Email { get; set; } = new List<EmailResponseDto> { };
        public List<PhoneResponseDto> Phone { get; set; } = new List<PhoneResponseDto> { };
    }
}
