using SinisterApi.Application.Interfaces;
using SinisterApi.Repository.Interfaces.Repositories;

namespace SinisterApi.Application.Services
{
    internal class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository) => 
            _productRepository = productRepository;


     
        
    }
}
