using Domain.Core.Entities;
using Domain.Core.Eums;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class SituationRepository : DomainRepository<Situation>, ISituationRepository
    {
        public SituationRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Situation>> GetAllAsync()
        {
            IQueryable<Situation> query = await Task.FromResult(GenerateQuery(filter: (x => x.Active.Equals((int)StatusEnum.Active)),
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}