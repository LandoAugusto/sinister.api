using Application.DTO.Common;
using Domain.Core.Extensions;
using Integration.BMG.Schemas;

namespace Application.Mappers
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
                        ZipCode = address.ZipCode,
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
    }
}
