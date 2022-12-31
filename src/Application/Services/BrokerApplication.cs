using Application.Interfaces;
using Domain.Core.Models;
using SinisterApi.Service.Interfaces;

namespace Application.Services
{
    internal class BrokerApplication : IBrokerApplication
    {
        private readonly IBrokerService _brokerService;
        public BrokerApplication(IBrokerService brokerService) =>
            _brokerService = brokerService;

        public async Task<BrokerModel> GetBrokerAsync(int brokerUserId) =>
             await _brokerService.GetBrokerAsync(brokerUserId);
    }
}
