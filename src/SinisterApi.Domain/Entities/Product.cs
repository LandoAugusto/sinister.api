namespace SinisterApi.Domain.Entities
{
    public class Product 
    {
        public int ProductId { get; set; }
        public DateTime CreatedDt { get; set; }
        public string Description { get; set; }
        public string  ExternalId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}
