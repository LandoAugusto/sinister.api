using Application.DTO.Common;
using Application.DTO.Communicant;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Notification
{
    public class SaveCommunicationRequestDtoExample : IExamplesProvider<UpdateSaveCommunicantRequestDto>
    {
        public UpdateSaveCommunicantRequestDto GetExamples() => new()
        {
            NotificationId = 1,
            CommunicantTypeId = 1,
            Name = "Teste Teste Teste",
            Email = new[] {
                new EmailRequestDto()
                {
                    EmailTypeId = 1,
                    Email = "teste.teste@gmail.com"
                }
            },
            Phone = new[]
            {
                new PhoneRequestDto()
                {
                    PhoneTypeId = 1,
                    Ddd ="11",
                    Phone = "1198282399898"
                }
            }
        };
    }
}
