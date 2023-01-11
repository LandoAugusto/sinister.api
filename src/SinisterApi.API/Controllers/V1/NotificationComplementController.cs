using Application.DTO.NotificationComplement;
using Application.DTO.Standard;
using Application.Interfaces;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class NotificationComplementController : BaseController
    {
        private readonly INotificationComplementApplication _notificationComplementApplication;

        public NotificationComplementController(
            IUser user,
            ILogger<NotificationComplementController> logger,
            INotificationComplementApplication notificationComplementApplication) : base(user, logger) =>
            _notificationComplementApplication = notificationComplementApplication;

        [HttpGet]
        [Route("GetComplement/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComplementAsync(int notificationId)
        {
            //var response = await _insurdeApplication.GetByIdAsync(insuredPersonId);
            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveComplement")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveComplementAsync(SaveComplementRequestDto request)
        {
            var response = await _notificationComplementApplication.SaveNotificationComplementAsync(request);            
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
