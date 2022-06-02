using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tracking_Vaksin.Models;

namespace Tracking_Vaksin.Controllers
{
    public class HomeController : Controller
    {
        private int StatusCode = 400;
        private string Message = "";
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}