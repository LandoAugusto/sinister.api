using SinisterApi.Domain.Models.Common;

namespace SinisterApi.Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<PeriodTypeModel> ListPeriodTypeAsync();
        Task<CommunicantTypeModel> ListCommunicantTypeAsync();
        Task<StatusSinisterModel> ListStatusSinisterAsync();
       
    }
}
