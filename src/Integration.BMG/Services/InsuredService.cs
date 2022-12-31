using Microsoft.Extensions.Configuration;
using Domain.Core.Infrastructure.Exceptions;
using Domain.Core.Models;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Mappper;
using Integration.BMG.Schemas;

namespace Integration.BMG.Services
{
    internal class InsuredService : IInsuredService
    {
        private const string INSURED_SERVICE_NAME = "insured/";
        private int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public InsuredService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));

        public async Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber)
        {
            try
            {
                var serviceName = "ListInsureds";
                var response = await _requestExecutador
                    .PostManyJsonApiAsync<object, ListInsuredResponseResponseModel, ErrorResponseModel>
                    ($"{_apiConfig.BaseUrl}{INSURED_SERVICE_NAME}{serviceName}", new { Name = name, DocumentNumber = documentNumber }, TimeoutInMilliseconds);

                if (response.ErrorResponseObject != null)
                {
                    if (response.ErrorResponseObject.Detail.Contains("Nenhum dado localizado para")) return null;
                    throw new BusinessException(response.ErrorResponseObject.Detail);
                };                

                return InsuredMap.Map(response.ResponseObject.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<InsuredModel> GetInsuredAsync(int insuredPersonId)
        {
            try
            {              
                var serviceName = "GetInsured";
                var response = await _requestExecutador
                    .PostManyJsonApiAsync<object, GetInsuredResponseResponseModel, ErrorResponseModel>
                    ($"{_apiConfig.BaseUrl}{INSURED_SERVICE_NAME}{serviceName}", new { InsuredPersonId = insuredPersonId }, TimeoutInMilliseconds);

                if (response.ErrorResponseObject != null)
                {
                    if (response.ErrorResponseObject.Detail.Contains("Nenhum dado localizado para")) return null;
                    throw new BusinessException(response.ErrorResponseObject.Detail);
                }

                return InsuredMap.Map(response.ResponseObject.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }      
    }
}
