using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    internal class PolicyRepository : DomainRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Policy>> GetAllAsync()
        {
            IQueryable<Policy> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Id))));
            return query.AsEnumerable();
        }

        public override async Task<Policy> GetByIdAsync(object id)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (item => item.Id.Equals(id)),
                            orderBy: (item => item.OrderBy(y => y.Id)),
                            includeProperties: source =>
                                    source
                                    .Include(x => x.Insured)
                                    .ThenInclude(x => x.InsuredAddress)
                                    .Include(x => x.Insured)
                                    .ThenInclude(x => x.InsuredPhone)));

            return query.FirstOrDefault();
        }
    }
}


