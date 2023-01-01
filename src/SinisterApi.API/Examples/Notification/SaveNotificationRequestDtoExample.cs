using SinisterApi.DTO.Notification;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Notification
{
    public class SaveNotificationRequestDtoExample : IExamplesProvider<SaveNotificationRequestDto>
    {
        public SaveNotificationRequestDto GetExamples() => new()
        {
            PolicyId = 28878,
            CodeItem = 1
        };
    }
}