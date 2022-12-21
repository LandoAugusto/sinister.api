using SinisterApi.Domain.Models.Product;

namespace SinisterApi.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductModel>> ListProductAsync();
    }
}
