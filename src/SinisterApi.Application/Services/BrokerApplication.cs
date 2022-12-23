using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
{
    internal class BrokerApplication : IBrokerApplication
    {
        private readonly IBrokerService _brokerService;
        public BrokerApplication(IBrokerService brokerService) =>
            _brokerService = brokerService;

        public async Task<BrokerModel> GetBrokerAsync(int brokerUserId)
        {
            return await _brokerService.GetBrokerAsync(brokerUserId);
        }
    }
}
