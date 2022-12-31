using Domain.Core.Models;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappper
{
    internal static class BrokerMap
    {
        public static BrokerModel Map(BrokerResponse response)
        {
            return new(response.PersonId, response.DocumentNumber, response.Name, response.SusepCode);
        }
    }
}
