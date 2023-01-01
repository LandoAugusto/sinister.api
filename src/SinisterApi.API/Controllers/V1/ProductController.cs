using Application.DTO.Standard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class ProductController : BaseController
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication) =>
            _productApplication = productApplication;

        [HttpGet]
        [Route("ListProduct")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListProductAsync()
        {
            var response = await _productApplication.ListProductAsync();
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess(response);
        }
    }
}
