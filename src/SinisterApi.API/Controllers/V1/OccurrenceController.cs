using Application.DTO.Occurence;
using Application.DTO.Standard;
using Application.Interfaces;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class OccurrenceController : BaseController
    {
        private readonly IOccurenceApplication _occurenceApplication;
        public OccurrenceController(
            IUser user,
            ILogger<NotificationController> logger,
            IOccurenceApplication occurenceApplication) : base(user, logger) =>
            _occurenceApplication = occurenceApplication;

        [HttpGet]
        [Route("GetOccurrence/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOccurrenceAsync(int notificationId)
        {
            var response = await _occurenceApplication.GetOccurrenceAsync(notificationId);            
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("UpdateSaveOccurrence")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSaveOccurrenceAsync(UpdateSaveOccurenceRequestDto request)
        {
            var response = await _occurenceApplication.UpdateSaveOccurrenceAsync(1, request);
            if (response == 0)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}

