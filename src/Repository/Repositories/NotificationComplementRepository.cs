using Domain.Core.Entities;
using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Repositories.Standard;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    internal class NotificationComplementRepository : DomainRepository<NotificationComplement>, INotificationComplementRepository
    {
        public NotificationComplementRepository(SinisterDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<NotificationComplement>> GetAllAsync()
        {
            IQueryable<NotificationComplement> query = await Task.FromResult(GenerateQuery(filter: null,
                                                                                orderBy: (item => item.OrderBy(y => y.Id))));
            return query.AsEnumerable();
        }
    }
}



