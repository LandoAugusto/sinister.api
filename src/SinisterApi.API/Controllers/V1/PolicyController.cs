using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.Domain.Models;
using SinisterApi.Domain.Models.Policy;

namespace SinisterApi.API.Controllers.V1
{
    public class PolicyController : BaseController
    {
        [HttpPost]
        [Route("GetPolicy")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPolicyAscync(GetPolicyModel request)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }

        [HttpPost]
        [Route("ListPolicies")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPoliciesAscync(GetPolicyModel request)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }
    }
}
