using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static class BrokerMap
    {
        public static BrokerModel Map(BrokerResponse response)
        {
            return new(response.PersonId, response.DocumentNumber, response.Name, response.SusepCode);
        }
    }
}
