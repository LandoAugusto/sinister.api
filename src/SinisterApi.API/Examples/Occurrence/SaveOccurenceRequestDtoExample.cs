using Application.DTO.Common;
using Application.DTO.Occurence;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Occurrence
{
    public class SaveOccurenceRequestDtoExample : IExamplesProvider<SaveOccurenceRequestDto>
    {
        public SaveOccurenceRequestDto GetExamples() => new()
        {
            NotificationId = 1,
            DateOccurence = "09/01/2023",
            TimeOccurrence = "21:35",
            DescriptonOccurence = "xxxxxxxxxx xxxxxxxxx xxxxxxxxx",
            DescriptionDamage = "yyyyyyyyyyyy yyyyyyyyyyyyyyyyy yyyyyyyy",
            Damage = 1500,
            Comments = "aaaaaaa bbbbbbbbbb xxxxxxxxxxxxx zzzzzzzzzzzz",
            IsRiskLocation = true,
            Phone = new[]
            {
                new SaveOccurencePhoneResquestDto()
                {
                    Name = "Teste teste teste teste",
                    PhoneTypeId = 1,
                    Ddd ="11",
                    Phone = "1198282399898"
                }
            },
            Address = new[]
            {
                 new AddressResquestDto()
                {
                    ZipCode = 06360290,
                    StateName = "São Paulo",
                    StateInitials ="SP",
                    City = "Cotia",
                    Number = "2222"                    
                }
            }

        };
    }
}