using SinisterApi.Domain.Entities;
using SinisterApi.Repository.Contexts;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Repository.Repositories.Standard;

namespace SinisterApi.Repository.Repositories
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


