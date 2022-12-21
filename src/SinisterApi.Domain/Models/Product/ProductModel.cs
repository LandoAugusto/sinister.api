namespace SinisterApi.Domain.Models.Product
{
    public class ProductModel
    {
        public ProductModel(int? id, string? name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
