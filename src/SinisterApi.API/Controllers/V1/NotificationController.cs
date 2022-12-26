using Microsoft.AspNetCore.Mvc;

namespace SinisterApi.API.Controllers.V1
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
