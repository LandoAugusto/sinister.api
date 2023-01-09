using Application.DTO.Occurence;
using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class OccurrenceController : BaseController
    {
        private readonly IOccurenceApplication _occurenceApplication;
        public OccurrenceController(IOccurenceApplication occurenceApplication) =>
            _occurenceApplication = occurenceApplication;

        [HttpGet]
        [Route("GetOccurrence/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOccurrenceAsync(int notificationId)
        {
            //var response = await _occurenceApplication.ListInsuredAsync(request.Name, request.DocumentNumber);

            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("SaveOccurrence")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveOccurrenceAsync(SaveOccurenceRequestDto request)
        {
            //var response = await _occurenceApplication.ListInsuredAsync(request.Name, request.DocumentNumber);

            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}

