using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    internal class OccurrenceRepository : DomainRepository<Occurrence>, IOccurrenceRepository
    {
        public OccurrenceRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Occurrence>> GetAllAsync()
        {
            IQueryable<Occurrence> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Id))));
            return query.AsEnumerable();
        }

        public async Task<Occurrence> GetByIdAsync(int notificationId)
        {
            IQueryable<Occurrence> query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (item => item.NotificationId.Equals(notificationId)),
                            orderBy: (item => item.OrderBy(y => y.Id)),
                            includeProperties: source =>
                                    source
                                    .Include(x => x.OccurenceAddress)
                                    .Include(x => x.OccurencePhone)));

            return query.FirstOrDefault();
        }
    }
}


