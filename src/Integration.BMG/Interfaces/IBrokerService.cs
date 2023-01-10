using Application.DTO.Broker;
using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IBrokerService
    {
        Task<BrokerResponseDto> GetBrokerAsync(int brokerUserId);
    }
}
