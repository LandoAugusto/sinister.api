using Domain.Core.Models;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappper
{
    internal static class ZipCodeMap
    {
        public static ZipCodeModel Map(ZipCodeReponse response)
        {
            return new ZipCodeModel()
            {
                StreetName = response.StreetName,
                StateName = response.StateName,
                CityName = response.CityName,
                District = response.District,
                StateInitials = response.StateInitials
            };
        }
    }
}
