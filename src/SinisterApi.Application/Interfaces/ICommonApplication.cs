using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<IEnumerable<PeriodTypeModel>> ListPeriodTypeAsync();
        Task<IEnumerable<CommunicantTypeModel>>ListCommunicantTypeAsync();
        Task<IEnumerable<StatusSinisterModel>> ListStatusSinisterAsync();
        Task<IEnumerable<SituationSinisterModel>> ListSituationSinisterAsync();
    }
}
