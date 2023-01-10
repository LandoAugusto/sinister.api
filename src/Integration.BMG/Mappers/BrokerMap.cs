using Application.DTO.Broker;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappers
{
    internal static class BrokerMap
    {
        public static BrokerResponseDto Map(BrokerResponse response)
        {
            if (response == null)
                return null;

            return new(response.PersonId, response.DocumentNumber, response.Name, response.SusepCode);
        }
    }
}
