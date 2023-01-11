using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    internal class InsuredRepository : DomainRepository<Insured>, IInsuredRepository
    {
        public InsuredRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Insured>> GetAllAsync()
        {
            IQueryable<Insured> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }

        public override async Task<Insured> GetByIdAsync(object id)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (item => item.Id.Equals(id)),
                            orderBy: (item => item.OrderBy(y => y.Id)),
                            includeProperties: source =>
                                    source
                                    .Include(x => x.InsuredAddress)
                                    .Include(x => x.InsuredPhone)));

            return query.FirstOrDefault();
        }
    }
}
