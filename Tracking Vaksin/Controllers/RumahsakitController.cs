using Microsoft.AspNetCore.Mvc;

namespace Tracking_Vaksin.Controllers
{
    public class RumahsakitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
