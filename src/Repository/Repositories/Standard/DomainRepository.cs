using Microsoft.EntityFrameworkCore;
using Domain.Core.Entities.Interfaces;
using Repository.Interfaces.Repositories.Standard;

namespace Infrastructure.Data.Repository.Repositories.Standard
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                              IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
