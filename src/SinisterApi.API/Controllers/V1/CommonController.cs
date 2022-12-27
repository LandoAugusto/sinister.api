using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class CommonController : BaseController
    {
        private readonly ICommonApplication _commonApplication;

        public CommonController(ICommonApplication commonApplication) => 
            _commonApplication = commonApplication;

        [HttpGet]
        [Route("ListPeriodType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPeriodTypeAsync()
        {
            var response = await _commonApplication.ListPeriodTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("ListCommunicantType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListCommunicantTypeAsync()
        {
            var response = await _commonApplication.ListCommunicantTypeAsync ();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("ListStatus")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListStatusAsync()
        {
            var response = await _commonApplication.ListStatusAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess( response);
        }

        [HttpGet]
        [Route("ListSituation")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSituationAsync()
        {
            var response = await _commonApplication.ListSituationAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}