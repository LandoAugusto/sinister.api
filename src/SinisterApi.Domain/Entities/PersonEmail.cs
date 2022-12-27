using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class PersonEmail : IIdentityEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EmailType { get; set; }
        public string Email { get; set; }
        public bool SendAutomatic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
