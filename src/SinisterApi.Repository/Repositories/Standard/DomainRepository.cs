using Microsoft.EntityFrameworkCore;
using SinisterApi.Domain.Entities.Interfaces;
using SinisterApi.Repository.Interfaces.Repositories.Standard;

namespace SinisterApi.Repository.Repositories.Standard
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                              IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
