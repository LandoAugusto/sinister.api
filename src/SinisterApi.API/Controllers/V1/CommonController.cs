using Application.DTO.Standard;
using Application.Interfaces;
using Domain.Core.Extensions;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class CommonController : BaseController
    {
        private readonly ICommonApplication _commonApplication;

        public CommonController(
            IUser user,
            ILogger<CommonController> logger,
            IBrokerApplication brokerApplication,
            ICommonApplication commonApplication) : base(user, logger) =>
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
            var response = await _commonApplication.ListCommunicantTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }


        [HttpGet]
        [Route("ListPhoneType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPhoneTypeAsync()
        {
            var response = await _commonApplication.ListPhoneTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("ListEmailType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListEmailTypeAsync()
        {
            var response = await _commonApplication.ListEmailTypeAsync();
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

            return ReturnSuccess(response);
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

        [HttpGet]
        [Route("ListProcessType")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListProcessTypeAsync()
        {
            var response = await _commonApplication.ListProcessTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("GetZipCode/{zipCode}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetZipCodeAsync(string zipCode)
        {
            var response = await _commonApplication.GetZipCodeAsync(int.Parse(zipCode.OnlyNumerical()));
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}