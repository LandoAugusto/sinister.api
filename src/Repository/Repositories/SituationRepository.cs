using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Infrastructure.Data.Repository.Interfaces.Repositories;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class SituationRepository : DomainRepository<Situation>, ISituationRepository
    {
        public SituationRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Situation>> GetAllAsync()
        {
            IQueryable<Situation> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}