﻿using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using Application.Interfaces;
using Domain.Core.Models.Standard;

namespace SinisterApi.API.Controllers.V1
{
    public class BrokerController : BaseController
    {
        private readonly IBrokerApplication _brokerApplication;

        public BrokerController(IBrokerApplication brokerApplication) =>
            _brokerApplication = brokerApplication;

        [HttpGet]
        [Route("GetBroker/{brokeruserid}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBrokerAsync(int brokeruserid)
        {
            var response = await _brokerApplication.GetBrokerAsync(brokeruserid);
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
