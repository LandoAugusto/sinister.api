using Domain.Core.Models;
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
                var person = new InsuredModel(insured.PersonId, insured.Name, insured.DocumentNumber, AddressMap.Map(insured.Addressess));
                result.Add(person);
            }
            return result;
        }      
        public static InsuredModel Map(InsuredResponse response) =>
            new(response.PersonId, response.Name, response.DocumentNumber, AddressMap.Map(response.Addressess));
    }
}
