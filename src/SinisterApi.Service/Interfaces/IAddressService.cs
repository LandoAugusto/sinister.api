using Domain.Core.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IAddressService
    {
        Task<ZipCodeModel> GetZipCodeAsync(int zipCode);
    }
}
