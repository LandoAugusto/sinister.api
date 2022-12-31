using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductModel>> ListProductAsync();
    }
}
