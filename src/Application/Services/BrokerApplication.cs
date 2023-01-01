using Application.DTO.Broker;
using Application.Interfaces;
using Application.Mappers;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class BrokerApplication : IBrokerApplication
    {
        private readonly IBrokerService _brokerService;
        public BrokerApplication(IBrokerService brokerService) =>
            _brokerService = brokerService;

        public async Task<BrokerResponseDto> GetBrokerAsync(int brokerUserId) =>
            BrokerMap.Map(await _brokerService.GetBrokerAsync(brokerUserId));
    }
}
