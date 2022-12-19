using Flurl.Http;
using Microsoft.Extensions.Configuration;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Services
{
    internal class AuthenticationService : IAuthenticationService
    {

        private const string AUTHENTICATION_SERVICE_NAME = "authentication/";
        private const string JsonApiContentType = "application/json";
        private int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        public AuthenticationService(MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_apiConfig, TimeoutInMilliseconds) = (apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<string> GetTokenAsync(string login, string password)
        {
            try
            {
                var serviceName = "GetToken";

                string url = $"{_apiConfig.BaseUrl}{AUTHENTICATION_SERVICE_NAME}{serviceName}";
                var response = await SetupRequest(url, TimeoutInMilliseconds)
                    .PostJsonAsync(new TokenRequestModel()
                    {
                        Login = login,
                        Password = password,
                    });

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no serviço de autenticação", ex.InnerException);
            }
        }
        private IFlurlRequest SetupRequest(string url, int timeoutInMilliseconds = 10000, string authorization = "") => url
          //.WithOAuthBearerToken(authorization)
          .WithHeaders(new
          {
              Content_Type = JsonApiContentType,
          })
          .ConfigureRequest(cfg =>
          {
              cfg.Timeout = timeoutInMilliseconds is 0 ? null : TimeSpan.FromMilliseconds(timeoutInMilliseconds);
              cfg.UrlEncodedSerializer = null;
          });
    }
}

