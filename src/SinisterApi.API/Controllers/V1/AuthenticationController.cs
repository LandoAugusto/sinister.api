using Microsoft.AspNetCore.Mvc;

namespace SinisterApi.API.Controllers.V1
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
