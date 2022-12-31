using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<ZipCodeModel> GetZipCodeAsync(int zipCode);
        Task<IEnumerable<DomainModel>> ListPeriodTypeAsync();
        Task<IEnumerable<DomainModel>>ListCommunicantTypeAsync();
        Task<IEnumerable<DomainModel>> ListStatusAsync();
        Task<IEnumerable<DomainModel>> ListSituationAsync();
        Task<IEnumerable<DomainModel>> ListPhoneTypeAsync();
        Task<IEnumerable<DomainModel>> ListEmailTypeAsync();
    }
}
