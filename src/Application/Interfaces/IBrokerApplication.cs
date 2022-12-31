using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface IBrokerApplication
    {
        Task<BrokerModel> GetBrokerAsync(int brokerUserId);
    }
}
