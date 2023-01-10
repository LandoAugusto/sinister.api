using Application.DTO.Standard;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SinisterApi.API.Controllers.V1.Base
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public abstract class BaseController : ControllerBase
    {

        private readonly ILogger logger;
        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        public BaseController(IUser appUser, ILogger logger )
        {
            this.logger = logger;            
            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();            
                UsuarioAutenticado = true;
            }
        }
        protected ActionResult ReturnSuccess(object data = null)
        {
            return Ok(new ResponseModel()
            {
                Success = true,
                ResponseData = data
            });
        }
        protected ActionResult ReturnSuccessSerializeObject(object data)
        {
            return Ok(new ResponseModel()
            {
                Success = true,               
                ResponseData = JsonConvert.SerializeObject(data)
            });
        }

        protected ActionResult ReturnNotFound()
        {
            return NotFound(new ResponseModel());
        }
    }
}
