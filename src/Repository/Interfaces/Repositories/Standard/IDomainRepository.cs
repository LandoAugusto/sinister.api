using Domain.Core.Entities.Interfaces;

namespace Repository.Interfaces.Repositories.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
