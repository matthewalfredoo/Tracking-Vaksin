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
            Tracking_Vaksin_Services.BPOMS bpomS = null;
            string username = "bpom1";
            string password = "12345678";

            ServiceModelBPOM.ServiceModelBPOMClient serviceModelBPOMClient = new ServiceModelBPOM.ServiceModelBPOMClient();
            serviceModelBPOMClient.login(ref bpomS, username, password, ref StatusCode, ref Message);

            ServiceModelBPOM.loginRequest LoginRequest = new ServiceModelBPOM.loginRequest(bpomS, username, password, StatusCode, Message);
            return View(LoginRequest);
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