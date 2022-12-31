using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class CommunicantTypeRepository : DomainRepository<CommunicantType>, ICommunicantTypeRepository
    {
        public CommunicantTypeRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<CommunicantType>> GetAllAsync()
        {
            IQueryable<CommunicantType> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }   
}
