using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SinisterApi.Domain.Models;

namespace SinisterApi.API.Controllers.V1.Base
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult ReturnSuccess(string message = "", object data = null)
        {
            return Ok(new ResponseModel()
            {
                Message = message,
                ResponseDate = DateTime.Now,
                ResponseData = data.ToString()
            });
        }
        protected ActionResult ReturnSuccessSerializeObject(string message = "", object data = null)
        {
            return Ok(new ResponseModel()
            {
                Message = message,
                ResponseDate = DateTime.Now,
                ResponseData = JsonConvert.SerializeObject(data)
            });
        }

        protected ActionResult ReturnNotFound()
        {
            return NotFound(new ResponseModel());
        }
    }
}
