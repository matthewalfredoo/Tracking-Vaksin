using Microsoft.AspNetCore.Mvc;

using Tracking_Vaksin.Models;
using Tracking_Vaksin_Services;
using ServiceModelPemerintah;

namespace Tracking_Vaksin.Controllers
{
    public class PemerintahController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
