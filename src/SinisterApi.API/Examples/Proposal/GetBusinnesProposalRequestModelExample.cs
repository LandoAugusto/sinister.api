using Application.DTO.Proposal;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Proposal
{
    public class GetBusinnesProposalRequestModelExample : IExamplesProvider<GetBusinnesProposalRequestDto>
    {
        public GetBusinnesProposalRequestDto GetExamples() => new()
        {          
            ProposalNumber = "61587"
        };
    }
}
