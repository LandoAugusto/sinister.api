using Domain.Core.Models;

namespace Integration.BMG.Interfaces
{
    public interface IAddressService
    {
        Task<ZipCodeModel> GetZipCodeAsync(int zipCode);
    }
}
