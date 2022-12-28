using SinisterApi.Domain.Extensions;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal static  class AddressMap
    {
        public static List<AddressModel> Map(List<AddressResponse> listAddress)
        {
            var list = new List<AddressModel>();
            if (listAddress.IsAny())
            {
                foreach (var address in listAddress)
                {
                    list.Add(new AddressModel()
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
