using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class EmailTypeRepository : DomainRepository<EmailType>, IEmailTypeRepository
    {
        public EmailTypeRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<EmailType>> GetAllAsync()
        {
            IQueryable<EmailType> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }
    }
}


   
