using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.Domain.Models.Product;
using SinisterApi.Domain.Models;

namespace SinisterApi.API.Controllers.V1
{
    public class CommonController : BaseController
    {

        [HttpGet]
        [Route("ListStatus")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListStatusAscync()
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }

        [HttpGet]
        [Route("ListPeriodType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPeriodType()
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }
    }
}