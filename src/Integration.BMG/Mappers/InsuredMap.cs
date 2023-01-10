using Application.DTO.Insured;
using Integration.BMG.Schemas;

namespace Integration.BMG.Mappers
{
    internal class InsuredMap
    {
        public static List<InsuredResponseDto> Map(List<InsuredResponse> response)
        {
            var result = new List<InsuredResponseDto>();
            foreach (var insured in response)
            {
                var person = new InsuredResponseDto(insured.PersonId, insured.Name, insured.DocumentNumber, AddressMap.Map(insured.Addressess));
                result.Add(person);
            }
            return result;
        }
        public static InsuredResponseDto Map(InsuredResponse response) =>
            new(response.PersonId, response.Name, response.DocumentNumber, AddressMap.Map(response.Addressess));
    }
}
