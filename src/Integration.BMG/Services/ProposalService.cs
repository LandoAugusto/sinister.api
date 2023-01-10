using Application.DTO.Proposal;
using Domain.Core.Infrastructure.Exceptions;
using Integration.BMG.Configurations;
using Integration.BMG.Http.Interfaces;
using Integration.BMG.Interfaces;
using Integration.BMG.Mappers;
using Integration.BMG.Schemas;
using Microsoft.Extensions.Configuration;

namespace Integration.BMG.Services
{
    internal class ProposalService : IProposalService
    {
        private const string PROPOSAL_SERVICE_NAME = "proposal/";
        private readonly int TimeoutInMilliseconds;
        private readonly MiddlewareApiConfig _apiConfig;

        private readonly IRequestExecutador _requestExecutador;

        public ProposalService(IRequestExecutador requestExecutador, MiddlewareApiConfig apiConfig, IConfiguration configuration) =>
           (_requestExecutador, _apiConfig, TimeoutInMilliseconds) = (requestExecutador, apiConfig, int.Parse(configuration["ExecuteTimeoutInMilliseconds"]));


        public async Task<ProposalResponseDto> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber)
        {
            try
            {
                var serviceName = "GetBusinessProposal";
                var response = await _requestExecutador
                     .PostManyJsonApiAsync<object, GetBusinnesProposalResponseModel, ErrorResponseModel>
                     ($"{_apiConfig.BaseUrl}{PROPOSAL_SERVICE_NAME}{serviceName}", new { BrokerUserId = brokerUserId, ProposalNumber = proposalNumber, }, TimeoutInMilliseconds);

                if (response.ErrorResponseObject != null)
                {
                    if (response.ErrorResponseObject.Detail.Contains("Nenhum dado localizado para")) return null;
                    throw new BusinessException(response.ErrorResponseObject.Detail);
                }   

                return ProposalMap.Map(response.ResponseObject.Data);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

