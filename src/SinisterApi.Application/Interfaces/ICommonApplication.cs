using SinisterApi.Domain.Models.Common;

namespace SinisterApi.Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<IEnumerable<PeriodTypeModel>> ListPeriodTypeAsync();
        Task<IEnumerable<CommunicantTypeModel>>ListCommunicantTypeAsync();
        Task<IEnumerable<StatusSinisterModel>> ListStatusSinisterAsync();
       
    }
}
