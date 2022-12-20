using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models;
using SinisterApi.Domain.Models.Policy;

namespace SinisterApi.API.Controllers.V1
{
    public class PolicyController : BaseController
    {

        private readonly IPolicyApplication _policyApplication;

        public PolicyController(IPolicyApplication policyApplication)
            => _policyApplication = policyApplication;

        [HttpPost]
        [Route("ListPolicies/{policyId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPoliciesAscync(int policyId)
        {
            var response = "";

            await _policyApplication.GetPolicyAsync(policyId);

            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
