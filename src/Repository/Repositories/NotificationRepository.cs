using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories.Standard;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Repositories
{
    internal class NotificationRepository : DomainRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Notification>> GetAllAsync()
        {
            IQueryable<Notification> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Id))));
            return query.AsEnumerable();
        }
    }
}
