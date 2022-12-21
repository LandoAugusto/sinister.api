using SinisterApi.Domain.Entities;
using SinisterApi.Repository.Interfaces.Repositories.Standard;

namespace SinisterApi.Repository.Interfaces.Repositories
{
    public interface IProductRepository : IDomainRepository<Product>
    {
    }
}
