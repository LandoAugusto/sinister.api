using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class CommunicantRepository : DomainRepository<Communicant>, ICommunicantRepository
    {
        public CommunicantRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Communicant>> GetAllAsync()
        {
            IQueryable<Communicant> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Name))));
            return query.AsEnumerable();
        }

        public async Task<Communicant> GetByIdAsync(int notificationId)
        {            
            IQueryable<Communicant> query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (item => item.NotificationId.Equals(notificationId)),
                            orderBy: (item => item.OrderBy(y => y.Name)),
                            includeProperties: source =>
                                    source
                                    .Include(x => x.CommunicantEmail)
                                    .Include(x => x.CommunicantPhone)));

            return query.FirstOrDefault();
        }
    }
}


