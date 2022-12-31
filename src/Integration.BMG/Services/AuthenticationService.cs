using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Schemas;
using System.Threading;

namespace Integration.BMG.Services
{
    internal class AuthenticationService : IAuthenticationService
    {

        private const string AUTHENTICATION_SERVICE_NAME = "authentication/";        
        private int TimeoutInMilliseconds;
        private const string JsonApiContentType = "application/json";
        private readonly MiddlewareApiConfig _apiConfig;        

        public AuthenticationService(MiddlewareApiConfig apiConfig,  IConfiguration configuration) =>
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

               var result = JsonConvert.DeserializeObject<GetTokenResponseModel>(response.ResponseMessage.Content.ReadAsStringAsync().Result); 

                return result.Data.AccessToken;
            }
            catch (Exception)
            {
                throw;
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

