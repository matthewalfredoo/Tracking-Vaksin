using Microsoft.AspNetCore.Mvc;
using Tracking_Vaksin_Services;
using ServiceModelPemerintah;
using ServiceModelDataPenduduk;

namespace Tracking_Vaksin.Controllers
{
    public class PemerintahController : Controller
    {
        private ServiceModelPemerintah.PemerintahS pemerintahS = null;
        private List<ServiceModelDataPenduduk.DataPendudukS> listDataPendudukS = new List<ServiceModelDataPenduduk.DataPendudukS>();

        private ServiceModelPemerintahClient serviceModelPemerintahClient = new ServiceModelPemerintahClient();
        private ServiceModelDataPendudukClient serviceModelDataPendudukClient = new ServiceModelDataPendudukClient();

        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";
        public static string ROLE = "Pemerintah";
        
        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                serviceModelDataPendudukClient.getAllDataPenduduk(ref listDataPendudukS, ref StatusCode, ref Message);
                if(TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"].ToString();
                }
                return View(listDataPendudukS);
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
        public IActionResult Login(Pemerintah pemerintah)
        {
            bool success = serviceModelPemerintahClient.login(ref pemerintahS, pemerintah.username, pemerintah.password, ref StatusCode, ref Message);
            if(success)
            {
                HttpContext.Session.SetString(USERNAME_SESSION, pemerintahS.username);
                HttpContext.Session.SetInt32(ID_SESSION, pemerintahS.id);
                HttpContext.Session.SetString(ROLE_SESSION, ROLE);
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
            if (HttpContext.Session.GetString(ProdusenController.USERNAME_SESSION) == ""
                || HttpContext.Session.GetString(ProdusenController.USERNAME_SESSION) == null)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult CreatePenduduk()
        {
            if(IsLoggedIn())
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult CreatePenduduk(ServiceModelDataPenduduk.DataPendudukS dataPendudukS)
        {
            serviceModelDataPendudukClient.createDataPenduduk(ref dataPendudukS, ref StatusCode, ref Message);
            dataPendudukS.id_pemerintah = HttpContext.Session.GetInt32(ID_SESSION);
            if (StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View();
        }

        [HttpGet]
        public IActionResult DeletePenduduk(int id)
        {
            serviceModelDataPendudukClient.deleteDataPenduduk(id, ref StatusCode, ref Message);
            if (StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            TempData["Message"] = Message;
            return RedirectToAction("Index");
        }
    }
}
