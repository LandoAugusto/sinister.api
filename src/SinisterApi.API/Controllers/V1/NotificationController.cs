using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.API.Models.Insured;
using SinisterApi.API.Models.Protocol;
using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class NotificationController : BaseController
    {
        private readonly IInsurdeApplication _insurdeApplication;

        public NotificationController(IInsurdeApplication insurdeApplication) =>
            _insurdeApplication = insurdeApplication;

        [HttpPost]
        [Route("GetNotification")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListInsuredAscync(ListInsuredRequestModel request)
        {
            var response = await _insurdeApplication.ListInsuredAsync(request.Name, request.DocumentNumber);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveNotification")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveAscync(ProtocolRequestModel request)
        {
            //var response = await _insurdeApplication.ListInsuredAsync(request.Name, request.DocumentNumber);

            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
