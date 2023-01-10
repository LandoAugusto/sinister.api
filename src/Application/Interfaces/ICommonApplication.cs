using Application.DTO.Common;

namespace Application.Interfaces
{
    public interface ICommonApplication
    {
        Task<ZipCodeResponseDto> GetZipCodeAsync(int zipCode);
        Task<IEnumerable<DomainResponseDto>> ListPeriodTypeAsync();
        Task<IEnumerable<DomainResponseDto>>ListCommunicantTypeAsync();
        Task<IEnumerable<DomainResponseDto>> ListStatusAsync();
        Task<IEnumerable<DomainResponseDto>> ListSituationAsync();
        Task<IEnumerable<DomainResponseDto>> ListPhoneTypeAsync();
        Task<IEnumerable<DomainResponseDto>> ListEmailTypeAsync();
        Task<IEnumerable<DomainResponseDto>> ListProcessTypeAsync();
    }
}
