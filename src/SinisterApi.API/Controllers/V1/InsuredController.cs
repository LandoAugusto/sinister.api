using Microsoft.AspNetCore.Mvc;
using SinisterApi.Domain.Models.Product;
using SinisterApi.Domain.Models;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class InsuredController : BaseController
    {
        [HttpGet]
        [Route("GetInsured/{request}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuredAscync(string request)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }
    }
}
