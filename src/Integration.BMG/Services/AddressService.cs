using Domain.Core.Infrastructure.Exceptions;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Schemas;
using Microsoft.Extensions.Configuration;

namespace Integration.BMG.Services
{
    public class AddressService : IAddressService
    {
        private const string ADDRESS_SERVICE_NAME = "address/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public AddressService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<ZipCodeReponse> GetZipCodeAsync(int zipCode)
        {
            try
            {
                var serviceName = "GetZipCode";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, GetZipCodeResponseModel, ErrorResponseModel>
                     ($"{_apiConfig.BaseUrl}{ADDRESS_SERVICE_NAME}{serviceName}", new { ZipCode = zipCode }, TimeoutInMilliseconds, true);

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
