using Application.DTO.Authentication;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Authentication
{
    public class GetTokenRequestDtoExample : IExamplesProvider<GetTokenRequestDto>
    {
        public GetTokenRequestDto GetExamples() => new()
        {
            Login = "leandro.cunha",
            Password = "Teste@123",
        };
    }
}

