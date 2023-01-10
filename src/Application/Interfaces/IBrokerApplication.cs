using Application.DTO.Broker;

namespace Application.Interfaces
{
    public interface IBrokerApplication
    {
        Task<BrokerResponseDto?> GetBrokerAsync(int brokerUserId);
    }
}
    