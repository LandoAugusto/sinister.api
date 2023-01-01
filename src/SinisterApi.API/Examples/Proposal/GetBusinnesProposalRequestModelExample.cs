using SinisterApi.DTO.Policy;
using SinisterApi.DTO.Proposal;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Proposal
{
    public class GetBusinnesProposalRequestModelExample : IExamplesProvider<GetBusinnesProposalRequestDto>
    {
        public GetBusinnesProposalRequestDto GetExamples() => new()
        {
            BrokerUserId = 601,
            ProposalNumber = "61587"
        };
    }
}
