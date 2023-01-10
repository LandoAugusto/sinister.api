using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using Application.DTO.Insured;
using Infrastruture.CrossCutting.Identity.Interfaces;

namespace SinisterApi.API.Controllers.V1
{
    public class InsuredController : BaseController
    {
        private readonly IInsurdeApplication _insurdeApplication;

        public InsuredController(
            IUser user,
            ILogger<InsuredController> logger,
            IInsurdeApplication insurdeApplication) : base(user, logger) =>
            _insurdeApplication = insurdeApplication;

        [HttpPost]
        [Route("ListInsured")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListInsuredAscync(ListInsuredRequestDto request)
        {
            var response = await _insurdeApplication.ListInsuredAsync(request.Name, request.DocumentNumber);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpGet]
        [Route("GetInsured/{insuredPersonId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuredAscync(int insuredPersonId)
        {
            var response = await _insurdeApplication.GetInsuredAsync(insuredPersonId);

            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
