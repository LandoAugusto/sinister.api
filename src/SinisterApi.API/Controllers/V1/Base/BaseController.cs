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
        protected ActionResult ReturnSuccess(object data = null)
        {
            return Ok(new ResponseModel()
            {
                ResponseDate = DateTime.Now,
                ResponseData = data
            });
        }
        protected ActionResult ReturnSuccessSerializeObject(object data)
        {
            return Ok(new ResponseModel()
            {

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
