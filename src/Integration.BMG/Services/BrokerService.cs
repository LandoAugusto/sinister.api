using Domain.Core.Infrastructure.Exceptions;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Schemas;
using Microsoft.Extensions.Configuration;

namespace Integration.BMG.Services
{
    internal class BrokerService : IBrokerService
    {
        private const string BROKER_SERVICE_NAME = "broker/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public BrokerService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<BrokerResponse> GetBrokerAsync(int brokerUserId)
        {
            try
            {
                var serviceName = "GetBroker";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, GetBrokerResponseModel, ErrorResponseModel>
                     ($"{_apiConfig.BaseUrl}{BROKER_SERVICE_NAME}{serviceName}", 
                     new { UserId = brokerUserId }, TimeoutInMilliseconds, true);

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
