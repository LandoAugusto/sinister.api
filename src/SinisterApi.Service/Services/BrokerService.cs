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
    internal class BrokerService : IBrokerService
    {
        private const string BROKER_SERVICE_NAME = "broker/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public BrokerService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<BrokerModel> GetBrokerAsync(int brokerUserId)
        {
            try
            {
                var serviceName = "GetBroker";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, GetBrokerResponseModel, ErrorResponseModel>
                     ($"{_apiConfig.BaseUrl}{BROKER_SERVICE_NAME}{serviceName}", new { UserId = brokerUserId }, TimeoutInMilliseconds);

                if (response.ErrorResponseObject != null)
                {
                    if (response.ErrorResponseObject.Detail.Contains("Nenhum dado localizado para")) return null;
                    throw new BusinessException(response.ErrorResponseObject.Detail);
                }

                return BrokerMap.Map(response.ResponseObject.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
