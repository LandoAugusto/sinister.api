using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<ZipCodeModel> GetZipCodeAsync(int zipCode);
        Task<IEnumerable<PeriodTypeModel>> ListPeriodTypeAsync();
        Task<IEnumerable<CommunicantTypeModel>>ListCommunicantTypeAsync();
        Task<IEnumerable<StatusModel>> ListStatusAsync();
        Task<IEnumerable<SituationModel>> ListSituationAsync();
    }
}
