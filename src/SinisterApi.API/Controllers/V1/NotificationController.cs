using Application.DTO.Occurence;
using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using Application.DTO.Notification;
using Infrastruture.CrossCutting.Identity.Interfaces;

namespace SinisterApi.API.Controllers.V1
{
    public class NotificationController : BaseController
    {
        private readonly INotificationApplication _notificationApplication;

        public NotificationController(
            IUser user,
            ILogger<NotificationController> logger,
            INotificationApplication notificationApplication) : base(user, logger) =>
            _notificationApplication = notificationApplication;

        [HttpGet]
        [Route("GetNotification/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNotificationAscync(int notificationId)
        {
            var response = await _notificationApplication.GetNotificationAscync(notificationId);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("ListNotification")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListNotificationAscync(ListNotificationRequestDto request)
        {
            var response = await _notificationApplication.ListNotificationAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveNotification")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveAscync(SaveNotificationRequestDto request)
        {
            var response = await _notificationApplication.SaveNotificationAsync(request.PolicyId, request.CodeItem);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
