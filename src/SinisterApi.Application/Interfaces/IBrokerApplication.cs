using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface IBrokerApplication
    {
        Task<BrokerModel> GetBrokerAsync(int brokerUserId);
    }
}
