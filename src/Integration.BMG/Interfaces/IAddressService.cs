using Application.DTO.Common;

namespace Integration.BMG.Interfaces
{
    public interface IAddressService
    {
        Task<ZipCodeResponseDto> GetZipCodeAsync(int zipCode);
    }
}
