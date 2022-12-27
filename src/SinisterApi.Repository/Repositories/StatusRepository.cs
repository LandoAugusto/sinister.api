using SinisterApi.Domain.Entities;
using SinisterApi.Repository.Contexts;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Repository.Repositories.Standard;

namespace SinisterApi.Repository.Repositories
{
    internal class StatusRepository : DomainRepository<Status>, IStatusRepository
    {
        public StatusRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Status>> GetAllAsync()
        {
            IQueryable<Status> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}