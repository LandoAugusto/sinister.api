using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.DTO.Policy;
using Application.Interfaces;
using Domain.Core.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class PolicyController : BaseController
    {
        private readonly IPolicyApplication _policyApplication;

        public PolicyController(IPolicyApplication policyApplication)
            => _policyApplication = policyApplication;

        [HttpPost]
        [Route("ListPolicies")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPoliciesAscync(ListPoliciesRequestModel request)
        {
            var response = await _policyApplication.ListPolicyAsync(request.PolicyId, request.InsuredPersonId, request.StipulatorPersonId, request.Certificate);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
