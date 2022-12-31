using Domain.Core.Models;

namespace Integration.BMG.Interfaces
{
    public interface IBrokerService
    {
        Task<BrokerModel> GetBrokerAsync(int brokerUserId);
    }
}
