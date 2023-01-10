using Application.DTO.Common;
using Domain.Core.Extensions;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappers
{
    internal static class AddressMap
    {
        public static List<AddressResponseDto> Map(List<AddressResponse> listAddress)
        {
            var list = new List<AddressResponseDto>();
            if (listAddress.IsAny())
            {
                foreach (var address in listAddress)
                {
                    list.Add(new AddressResponseDto()
                    {
                        Id = address.Id,
                        ZipCode = address.ZipCode.ToString().PadLeft(8, '0'),
                        StreetName = address.StreetName,
                        StateInitials = address.City.State.Initials,
                        StateName = address.City.State.Name,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City.Name
                    });
                }
            }
            return list;
        }

        public static ZipCodeResponseDto Map(ZipCodeReponse address)
        {
            if (address == null) return null;
            return new ZipCodeResponseDto(address.StreetName, address.StateInitials, address.StateName, address.District, address.CityName);
        }
    }
}
