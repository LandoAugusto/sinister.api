using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Notification : IIdentityEntity
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int SituationId { get; set; }
        public int StatusId { get; set; }
        public int Stage { get; set; }
        public DateTime? DateNotification { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Occurrence Occurrence { get; set; }
    }
}
