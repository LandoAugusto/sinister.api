using Microsoft.Extensions.Configuration;
using SinisterApi.Domain.Infrastructure.Exceptions;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Http.Interfaces;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Mappper;
using SinisterApi.Service.Schemas;

namespace SinisterApi.Service.Services
{
    internal class PolicyService : IPolicyService
    {
        private const string POLICY_SERVICE_NAME = "policy/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public PolicyService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<IList<PolicyModel>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            try
            {
                var serviceName = "ListPoliciesEx";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, ListPoliciesExResponseModel, ErrorResponseModel>
                     ($"{_apiConfig.BaseUrl}{POLICY_SERVICE_NAME}{serviceName}", new
                     {
                         BrokerUsersIds = new List<int>
                        {
                        _apiConfig.User
                        },
                         PolicyId = policyId,
                         InsuredResponse = insuredPersonId,
                         SearchAllPolicies = false
                     }, TimeoutInMilliseconds);

                if (response.ErrorResponseObject != null)
                {
                    if (response.ErrorResponseObject.Detail.Contains("Nenhum dado localizado para")) return null;
                    throw new BusinessException(response.ErrorResponseObject.Detail);
                }


                return PolicyMap.Map(response.ResponseObject.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
