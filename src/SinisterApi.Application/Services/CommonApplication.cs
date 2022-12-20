using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models.Common;

namespace SinisterApi.Application.Services
{
    internal class CommonApplication : ICommonApplication
    {
        public async Task<PeriodTypeModel> ListPeriodTypeAsync()
        {
            return null;
        }

        public async Task<CommunicantTypeModel> ListCommunicantTypeAsync()
        {
            return null;
        }

        public async Task<StatusSinisterModel> ListStatusSinisterAsync()
        {
            return null;
        }
    }
}
