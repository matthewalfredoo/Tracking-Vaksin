using Microsoft.AspNetCore.Mvc;

using Tracking_Vaksin.Models;
using Tracking_Vaksin_Services;
using ServiceModelBPOM;

namespace Tracking_Vaksin.Controllers
{
    public class BpomController : Controller
    {
        private BPOMS bpomS = null;
        private ServiceModelBPOMClient serviceModelBPOMClient = new ServiceModelBPOMClient();
        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";
        public static string ROLE = "Bpom";

        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("_Username");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (IsLoggedIn() == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(BPOM bpom)
        {
            bool success = serviceModelBPOMClient.login(ref bpomS, bpom.username, bpom.password, ref StatusCode, ref Message);
            if (success)
            {
                HttpContext.Session.SetString(BpomController.USERNAME_SESSION, bpom.username);
                HttpContext.Session.SetInt32(BpomController.ID_SESSION, bpomS.id);
                HttpContext.Session.SetString(BpomController.ROLE_SESSION, BpomController.ROLE);
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public bool IsLoggedIn()
        {
            if (HttpContext.Session.GetString(BpomController.USERNAME_SESSION) == ""
                || HttpContext.Session.GetString(BpomController.USERNAME_SESSION) == null)
            {
                return false;
            }
            return true;
        }
    }
}
