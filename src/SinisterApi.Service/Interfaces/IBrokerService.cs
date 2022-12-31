using Domain.Core.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IBrokerService
    {
        Task<BrokerModel> GetBrokerAsync(int brokerUserId);
    }
}
