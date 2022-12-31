﻿using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class CommunicantPhone : IIdentityEntity
    {
        public int Id { get; set; }
        public int CommunicantId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
