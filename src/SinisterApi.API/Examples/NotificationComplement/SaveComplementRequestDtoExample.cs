using Application.DTO.NotificationComplement;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.NotificationComplement
{
    public class SaveComplementRequestDtoExample : IExamplesProvider<UpdateSaveComplementRequestDto>
    {
        public UpdateSaveComplementRequestDto GetExamples() => new()
        {
            NotificationId = 1,
            IsContentious = true,
            ProcessNumber = "xxxxxxxxxxx",
            ProcessDate = DateTime.Now,
            ProcessTypeId = 1,
            IsPoliceReport = true,
            PoliceReportNumber = "ccccxxxooopppp",
            IsThird = true,
            IsProvedor = true,
        };
    }
}
