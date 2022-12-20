using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SinisterApi.Domain.Entities;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Services
{
    internal class InsuredService : IInsuredService
    {
        private const string POLICY_SERVICE_NAME = "insured/";
        private const string JsonApiContentType = "application/json";
        private int TimeoutInMilliseconds;

        private readonly MiddlewareApiConfig _apiConfig;

        public InsuredService(MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_apiConfig, TimeoutInMilliseconds) = (apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber)
        {
            try
            {
                var resutl = new ListInsuredResponseResponseModel();
                var serviceName = "ListInsureds";
                string url = $"{_apiConfig.BaseUrl}{POLICY_SERVICE_NAME}{serviceName}";
                var response = await SetupRequest(url, TimeoutInMilliseconds)
                    .PostJsonAsync(new { Name = name, DocumentNumber = documentNumber });

                if (response.ResponseMessage.IsSuccessStatusCode)
                    resutl = JsonConvert.DeserializeObject<ListInsuredResponseResponseModel>(response.ResponseMessage.Content.ReadAsStringAsync().Result);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no serviço de transferência !! Número da Conta:", ex.InnerException);
            }
        }

        public async Task<InsuredModel> GetInsuredAsync(int insuredPersonId)
        {
            try
            {
                var resutl = new GetInsuredResponseResponseModel();
                var serviceName = "GetInsured";
                string url = $"{_apiConfig.BaseUrl}{POLICY_SERVICE_NAME}{serviceName}";
                var response = await SetupRequest(url, TimeoutInMilliseconds)
                    .PostJsonAsync(new { InsuredPersonId = insuredPersonId });

                if (response.ResponseMessage.IsSuccessStatusCode)
                    resutl = JsonConvert.DeserializeObject<GetInsuredResponseResponseModel>(response.ResponseMessage.Content.ReadAsStringAsync().Result);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no serviço de transferência !! Número da Conta:", ex.InnerException);
            }
        }
        private IFlurlRequest SetupRequest(string url, int timeoutInMilliseconds = 10000, string authorization = "") => url
          // .WithOAuthBearerToken(authorization)
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
