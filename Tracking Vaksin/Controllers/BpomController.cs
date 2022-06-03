using Microsoft.AspNetCore.Mvc;
using Tracking_Vaksin_Services;
using ServiceModelBPOM;
using ServiceModelProdusen;
using ServiceModelDataVaksin;

namespace Tracking_Vaksin.Controllers
{
    public class BpomController : Controller
    {
        private ServiceModelBPOM.BPOMS bpomS = null;
        private ServiceModelBPOMClient serviceModelBPOMClient = new ServiceModelBPOMClient();
        private List<ServiceModelDataVaksin.DataVaksinS> listDataVaksinS = new List<ServiceModelDataVaksin.DataVaksinS>();
        private ServiceModelDataVaksinClient serviceModelDataVaksinClient = new ServiceModelDataVaksinClient();
        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";
        public static string ROLE = "Bpom";

        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                ViewBag.username = HttpContext.Session.GetString("_Username");
                int idBpom = (int)HttpContext.Session.GetInt32(BpomController.ID_SESSION);
                serviceModelDataVaksinClient.getAllDataVaksin(ref listDataVaksinS, ref StatusCode, ref Message);
                return View(listDataVaksinS);
            }
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
            return RedirectToAction("Index", "Home");
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
