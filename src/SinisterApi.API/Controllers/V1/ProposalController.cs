using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.DTO.Policy;
using SinisterApi.DTO.Proposal;
using Application.Interfaces;
using Domain.Core.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class ProposalController : BaseController
    {
        private readonly IProposalApplication _proposalApplication;

        public ProposalController(IProposalApplication proposalApplication) =>
            _proposalApplication = proposalApplication;

        [HttpPost]
        [Route("GetBusinnesProposal")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPoliciesAscync(GetBusinnesProposalRequestModel request)
        {
            var response = await _proposalApplication.GetBusinnesProposalAsync(request.BrokerUserId, request.ProposalNumber);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
