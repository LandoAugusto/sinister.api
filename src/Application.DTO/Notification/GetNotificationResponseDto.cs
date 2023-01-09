﻿namespace Application.DTO.Notification
{
    public class GetNotificationResponseDto
    {
        public GetNotificationResponseDto(int id, int policyId, int stage, DateTime dateNotification)
        {
            Id = id;
            PolicyId = policyId;
            Stage = stage;
            DateNotification = dateNotification;
        }

        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int Stage { get; set; }
        public DateTime DateNotification { get; set; }
    }
}
