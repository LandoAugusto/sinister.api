using Application.DTO.Communicant;
using Application.DTO.Standard;
using Application.Interfaces;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class CommunicantController : BaseController
    {
        private readonly ICommunicantApplication _communicantApplication;

        public CommunicantController(
            IUser user,
            ILogger<CommunicantController> logger,
            ICommunicantApplication communicantApplication) : base(user, logger) =>
            _communicantApplication = communicantApplication;

        [HttpGet]
        [Route("GetComunicant/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComunicantAsync(int notificationId)
        {
            var response = await _communicantApplication.GetCommunicantAsync(notificationId);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveCommunicant")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveCommunicantAsync(SaveCommunicantRequestDto request)
        {
            var response = await _communicantApplication.SaveCommunicantAsync(request, 1);
            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("UpdateCommunicant")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCommunicantAsync(UpdateCommunicantRequestDto request)
        {
            //var response = await _communicantApplication.SaveCommunicantAsync(request, 1);

            var response = true;
            return ReturnSuccess(response);
        }
    }
}
