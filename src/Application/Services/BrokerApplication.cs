using Application.DTO.Broker;
using Application.Interfaces;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class BrokerApplication : IBrokerApplication
    {
        private readonly IBrokerService _brokerService;
        public BrokerApplication(IBrokerService brokerService) =>
            _brokerService = brokerService;

        public async Task<BrokerResponseDto?> GetBrokerAsync(int brokerUserId)
        {
            var response =  await _brokerService.GetBrokerAsync(brokerUserId);
            if (response == null) return null;

            return response;
        }
    }
}
