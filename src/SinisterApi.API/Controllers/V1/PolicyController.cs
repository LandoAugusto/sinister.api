﻿using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using Application.DTO.Policy;
using Infrastruture.CrossCutting.Identity.Interfaces;

namespace SinisterApi.API.Controllers.V1
{
    public class PolicyController : BaseController
    {
        private readonly IPolicyApplication _policyApplication;
        public PolicyController(
         IUser user,
         ILogger<PolicyController> logger,
         IPolicyApplication policyApplication) : base(user, logger) =>
         _policyApplication = policyApplication;

        [HttpPost]
        [Route("ListPolicies")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPoliciesAscync(ListPoliciesRequestDto request)
        {
            var response = await _policyApplication.ListPolicyAsync(request.PolicyId, request.InsuredPersonId, request.StipulatorPersonId, request.Certificate);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }

        [HttpPost]
        [Route("GetPolicyInsured/{notificationId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPolicyInsured(int notificationId)
        {
            //var response = await _policyApplication.ListPolicyAsync(request.PolicyId, request.InsuredPersonId, request.StipulatorPersonId, request.Certificate);
            var response = "";
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
