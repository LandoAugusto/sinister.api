using Application.DTO.Standard;
using Application.Interfaces;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class BrokerController : BaseController
    {
        private readonly IBrokerApplication _brokerApplication;

        public BrokerController(
            IUser user,
            ILogger<BrokerController> logger,
            IBrokerApplication brokerApplication) : base(user, logger) =>
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
