using Domain.Core.Entities;
using Domain.Core.Eums;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Repositories.Standard;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    internal class ProcessTypeRepository : DomainRepository<ProcessType>, IProcessTypeRepository
    {
        public ProcessTypeRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<ProcessType>> GetAllAsync()
        {
            IQueryable<ProcessType> query = await Task.FromResult(GenerateQuery(filter: (x => x.Active.Equals((int)StatusEnum.Active)),
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}
