using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SinisterApi.Domain.Models.Policy;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Models;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Services
{
    internal class PolicyService : IPolicyService
    {
        private const string POLICY_SERVICE_NAME = "policy/";
        private const string JsonApiContentType = "application/json";
        private int TimeoutInMilliseconds;

        private readonly MiddlewareApiConfig _apiConfig;

        public PolicyService(MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_apiConfig, TimeoutInMilliseconds) = (apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<PolicyModel> GetPolicyAsync(int policyId)
        {
            try
            {
                var resutl = new ListPoliciesExResponseModel();

                var serviceName = "ListPoliciesEx";
                string url = $"{_apiConfig.BaseUrl}{POLICY_SERVICE_NAME}{serviceName}";
                var response = await SetupRequest(url, TimeoutInMilliseconds)
                    .PostJsonAsync(new ListPoliciesExRequestModel()
                    {
                        BrokerUsersIds = new List<int>
                        {
                            _apiConfig.User
                        },
                        PolicyId = policyId,
                        SearchAllPolicies = false
                    });

                if (response.ResponseMessage.IsSuccessStatusCode)
                    resutl = JsonConvert.DeserializeObject<ListPoliciesExResponseModel>(response.ResponseMessage.Content.ReadAsStringAsync().Result);

                return new PolicyModel()
                {
                   
                };
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
