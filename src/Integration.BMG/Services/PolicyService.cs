﻿using Domain.Core.Infrastructure.Exceptions;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Schemas;
using Microsoft.Extensions.Configuration;

namespace Integration.BMG.Services
{
    internal class PolicyService : IPolicyService
    {
        private const string POLICY_SERVICE_NAME = "policy/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public PolicyService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<IList<PolicyResponse>> ListPolicyAsync(int? policyId, int? insuredPersonId, int? stipulatorPersonId, int? certificate)
        {
            try
            {
                var serviceName = "ListPoliciesEx";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, ListPolicyResponse, ErrorResponseModel>
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

                return response.ResponseObject.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
