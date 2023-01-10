using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using Application.DTO.Proposal;
using Infrastruture.CrossCutting.Identity.Interfaces;

namespace SinisterApi.API.Controllers.V1
{
    public class ProposalController : BaseController
    {
        private readonly IProposalApplication _proposalApplication;

        public ProposalController(
            IUser user,
            ILogger<ProductController> logger,
            IProposalApplication proposalApplication) : base(user, logger) =>
            _proposalApplication = proposalApplication;

        [HttpPost]
        [Route("GetBusinnesProposal")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBusinnesProposalAscync(GetBusinnesProposalRequestDto request)
        {
            var response = await _proposalApplication.GetBusinnesProposalAsync(601, request.ProposalNumber);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
