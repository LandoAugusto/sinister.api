using Application.DTO.Product;

namespace Application.Interfaces
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductResponseDto>> ListProductAsync();
    }
}
