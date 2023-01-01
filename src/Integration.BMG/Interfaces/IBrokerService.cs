using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IBrokerService
    {
        Task<BrokerResponse> GetBrokerAsync(int brokerUserId);
    }
}
