using Application.DTO.Common;
using Application.DTO.Policy;

namespace Application.DTO.Notification
{
    public class ListNotificationResponseDto
    {
        public ListNotificationResponseDto(int id, int policyId, int stage, DateTime dateNotification)
        {
            this.Id = id;      
            this.PolicyId = policyId;
            this.Stage = stage;
            this.DateNotification = dateNotification;
        }

        public int Id { get; set; }

        public int PolicyId { get; set; }
        public int Stage { get; set; }
        public DateTime DateNotification { get; set; }
        public DomainResponseDto Situation { get; set; }
        public DomainResponseDto Status { get; set; }
        public ListPolicyResponseDto Policy { get; set; }
    }
}
