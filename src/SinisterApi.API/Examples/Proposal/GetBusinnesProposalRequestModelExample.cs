using SinisterApi.API.Models.Policy;
using SinisterApi.API.Models.Proposal;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Proposal
{
    public class GetBusinnesProposalRequestModelExample : IExamplesProvider<GetBusinnesProposalRequestModel>
    {
        public GetBusinnesProposalRequestModel GetExamples() => new()
        {
            BrokerUserId = 601,
            ProposalNumber = "61587"
        };
    }
}
