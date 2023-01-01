namespace Application.DTO.Product
{
    public class ProductResponseDto
    {
        public ProductResponseDto(int? id, string? name, string imageUrl)
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
