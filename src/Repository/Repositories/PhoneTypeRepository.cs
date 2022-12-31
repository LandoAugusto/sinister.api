using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class PhoneTypeRepository : DomainRepository<PhoneType>, IPhoneTypeRepository
    {
        public PhoneTypeRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<PhoneType>> GetAllAsync()
        {
            IQueryable<PhoneType> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}


