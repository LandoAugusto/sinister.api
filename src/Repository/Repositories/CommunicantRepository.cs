using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class CommunicantRepository : DomainRepository<Communicant>, ICommunicantRepository
    {
        public CommunicantRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Communicant>> GetAllAsync()
        {
            IQueryable<Communicant> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}


