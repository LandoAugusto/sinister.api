using Flurl.Http;
using Microsoft.Extensions.Configuration;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Models;

namespace SinisterApi.Service.Services
{
    internal class PolicyService : IPolicyService
    {
        private const string JsonApiContentType = "application/json";
        private int TimeoutInMilliseconds;
        private readonly I4proApiConfig _apiConfig;

        public PolicyService(I4proApiConfig apiConfig, IConfiguration configuration) =>
           (_apiConfig, TimeoutInMilliseconds) = (apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task ProcessTransactionAsync(GetPolicyRequestModel model)
        {
            try
            {
                string url = $"{_apiConfig.BaseUrl}";
                var response = await SetupRequest(url, TimeoutInMilliseconds)
                    .PostJsonAsync(new GetPolicyRequestModel()
                    {

                    });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no serviço de transferência !! Número da Conta:", ex.InnerException);
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
