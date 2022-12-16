namespace SinisterApi.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public string  ExternalId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}
