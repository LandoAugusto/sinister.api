using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static class BrokerMap
    {
        public static BrokerModel Map(BrokerResponse response)
        {
            return new()
            {
                Name = response.Name,
                DocumentNumber = response.DocumentNumber,
                PersonId = response.PersonId,
                SusepCode = response.SusepCode,
            };
        }
    }
}
