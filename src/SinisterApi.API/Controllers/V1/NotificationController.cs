using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.DTO.Notification;

namespace SinisterApi.API.Controllers.V1
{
    public class NotificationController : BaseController
    {
        private readonly INotificationApplication _notificationApplication;

        public NotificationController(INotificationApplication notificationApplication) =>
            _notificationApplication = notificationApplication;

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


        [HttpGet]
        [Route("GetComunicant/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComunicantAsync(int notificationId)
        {
            var response = await _notificationApplication.GetCommunicantAsync(notificationId);            
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveComunicant")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveComunicantAsync(SaveCommunicantRequestDto request)
        {
            var response = await _notificationApplication.SaveCommunicantAsync(request, 1);
            return ReturnSuccess(response);
        }


        [HttpGet]
        [Route("GetOccurence/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOccurenceAsync(int notificationId)
        {
            //var response = await _notificationApplication.ListInsuredAsync(request.Name, request.DocumentNumber);

            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }


        [HttpPost]
        [Route("SaveOccurence")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveOccurenceAsync(SaveNotificationRequestDto request)
        {
            //var response = await _notificationApplication.ListInsuredAsync(request.Name, request.DocumentNumber);

            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
