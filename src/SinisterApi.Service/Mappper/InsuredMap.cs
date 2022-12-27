using SinisterApi.Domain.Extensions;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Mappper
{
    internal class InsuredMap
    {
        public static List<InsuredModel> Map(List<InsuredResponse> response)
        {
            var result = new List<InsuredModel>();
            foreach (var insured in response)
            {
                var person = new InsuredModel(insured.PersonId, insured.Name, insured.DocumentNumber);
                if (insured.Addressess.IsAny())
                {
                    foreach (var address in insured.Addressess)
                    {
                        person.Address.Add(new AddressModel()
                        {
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

                result.Add(person);
            }
            return result;
        }
        public static InsuredModel Map(InsuredResponse response)
        {
            var result = new InsuredModel(response.PersonId, response.Name, response.DocumentNumber);

            if (response.Addressess.IsAny())
            {
                foreach (var address in response.Addressess)
                {
                    result.Address.Add(new AddressModel()
                    {
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

            return result;
        }
    }
}
