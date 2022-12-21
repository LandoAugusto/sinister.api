using SinisterApi.Domain.Entities.Interfaces;

namespace SinisterApi.Repository.Interfaces.Repositories.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
