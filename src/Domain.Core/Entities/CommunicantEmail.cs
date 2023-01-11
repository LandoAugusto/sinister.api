using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class CommunicantEmail : IIdentityEntity
    {

        public CommunicantEmail(int communicantId, int emailTypeId, string email, bool sendAutomatic, int inclusionUserId)
        {
            CommunicantId = communicantId;
            EmailTypeId = emailTypeId;
            Email = email;
            InclusionUserId = inclusionUserId;
        }
        public CommunicantEmail(int emailTypeId, string email, bool sendAutomatic, int inclusionUserId)
        {
            EmailTypeId = emailTypeId;
            Email = email;
            InclusionUserId = inclusionUserId;
        }

        public int Id { get; set; }
        public int CommunicantId { get; set; }
        public int EmailTypeId { get; set; }
        public string Email { get; set; }
        public bool SendAutomatic { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public virtual Communicant Communicant { get; set; } = null!;
        public virtual EmailType EmailType { get; set; } = null!;
    }
}
