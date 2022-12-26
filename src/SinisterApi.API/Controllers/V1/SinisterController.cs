using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.API.Models.Sinister;
using SinisterApi.Domain.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class SinisterController : BaseController
    {

        [HttpPost]
        [Route("ListSinisterNotification")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSinisterNotification(ListSinisterNotificationRequestModel request)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("GetSinisterNotification/{protocolNumber}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSinisterNotification(int protocolNumber)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
