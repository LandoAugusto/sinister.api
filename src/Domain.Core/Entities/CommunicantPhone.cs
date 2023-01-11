using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class CommunicantPhone : IIdentityEntity
    {

        public CommunicantPhone(int communicantId, int phoneTypeId, string ddd, string phone, int inclusionUserId)
        {
            CommunicantId = communicantId;
            PhoneTypeId = phoneTypeId;
            Ddd = ddd;
            Phone = phone;
            InclusionUserId = inclusionUserId;
        }
        public CommunicantPhone(int phoneTypeId, string ddd, string phone, int inclusionUserId)
        {
            PhoneTypeId = phoneTypeId;
            Ddd = ddd;
            Phone = phone;
            InclusionUserId = inclusionUserId;
        }

        public int Id { get; set; }
        public int CommunicantId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public virtual Communicant Communicant { get; set; } = null!;
        public virtual PhoneType PhoneType { get; set; } = null!;
    }
}
