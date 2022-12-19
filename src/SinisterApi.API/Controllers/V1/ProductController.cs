﻿using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;
using SinisterApi.Domain.Models;
using SinisterApi.Domain.Models.Policy;
using SinisterApi.Domain.Models.Product;

namespace SinisterApi.API.Controllers.V1
{
    public class ProductController : BaseController
    {
        [HttpPost]
        [Route("ListProduct")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductAscync(ProductModel request)
        {
            var response = 1;
            if (response == null)
                return ReturnNotFound();

            return ReturnSuccess("", response);
        }
    }
}
