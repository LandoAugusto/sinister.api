using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Domain.Entities
{
    public class Occurrence : IIdentityEntity
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public DateTime DateOccurrence { get; set; }
        public string Description { get; set; }
        public string DescriptionDamageCaused { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public OccurrenceAddress OccurrenceAddress { get; set; }
        public List<OccurrenceContact> OccurrenceContact { get; set; }
        public List<Notification> Notification { get; set; }
    }
}
