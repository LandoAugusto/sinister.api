using SinisterApi.Domain.Entities;
using SinisterApi.Repository.Contexts;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Repository.Repositories.Standard;

namespace SinisterApi.Repository.Repositories
{
    internal class SituationSinisterRepository : DomainRepository<SituationSinister>, ISituationSinisterRepository
    {
        public SituationSinisterRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<SituationSinister>> GetAllAsync()
        {
            IQueryable<SituationSinister> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}