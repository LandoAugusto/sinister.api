using Application.Interfaces;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Domain.Core.Models;

namespace Application.Services
{
    internal class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository) =>
            _productRepository = productRepository;


        public async Task<IEnumerable<ProductModel>> ListProductAsync()
        {
            var list = await _productRepository.GetAllAsync();

            if (!list.Any()) return null;

            var result = new List<ProductModel>();
            foreach (var item in list)
                result.Add(new ProductModel(int.Parse(item.ExternalId), item.Name, item.ImageUrl));

            return result;
        }

    }
}
