using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductModel>> ListProductAsync();
    }
}
