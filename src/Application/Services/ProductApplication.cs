using Application.DTO.Product;
using Application.Interfaces;
using Infrastructure.Data.Repository.Interfaces.Repositories;


namespace Application.Services
{
    internal class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository) =>
            _productRepository = productRepository;


        public async Task<IEnumerable<ProductResponseDto>> ListProductAsync()
        {
            var list = await _productRepository.GetAllAsync();

            if (!list.Any()) return null;

            var result = new List<ProductResponseDto>();
            foreach (var item in list)
                result.Add(new ProductResponseDto(int.Parse(item.ExternalId), item.Name, item.ImageUrl));

            return result;
        }

    }
}
