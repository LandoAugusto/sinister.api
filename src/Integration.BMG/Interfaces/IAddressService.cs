using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IAddressService
    {
        Task<ZipCodeReponse> GetZipCodeAsync(int zipCode);
    }
}
