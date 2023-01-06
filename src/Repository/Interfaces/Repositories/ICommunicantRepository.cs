using Repository.Interfaces.Repositories.Standard;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Interfaces.Repositories
{
    public interface ICommunicantRepository : IDomainRepository<Communicant>
    {
        Task<Communicant> GetByIdAsync(int notificationId);
    }
}
