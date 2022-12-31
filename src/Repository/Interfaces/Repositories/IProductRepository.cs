using Domain.Core.Entities;
using Repository.Interfaces.Repositories.Standard;

namespace Infrastructure.Data.Repository.Interfaces.Repositories
{
    public interface IProductRepository : IDomainRepository<Product>
    {
    }
}
