using Microsoft.AspNetCore.Mvc;
using Tracking_Vaksin_Services;
using ServiceModelProdusen;
using ServiceModelDataVaksin;
using ServiceBPOM; // Menggunakan ServiceBPOM untuk melaporkan registrasi vaksin

namespace Tracking_Vaksin.Controllers
{
    public class ProdusenController : Controller
    {
        private ServiceModelProdusen.ProdusenS produsenS = null;
        private List<ServiceModelDataVaksin.DataVaksinS> listProdusenS = new List<ServiceModelDataVaksin.DataVaksinS>();

        private ServiceModelProdusenClient serviceModelProdusenClient = new ServiceModelProdusenClient();
        private ServiceModelDataVaksinClient serviceModelDataVaksinClient = new ServiceModelDataVaksinClient();
        private ServiceBPOMClient serviceBPOMClient = new ServiceBPOMClient();

        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";
        public static string NAMA_SESSION = "_Nama";
        public static string ROLE = "Produsen";

        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                int idProdusen = (int) HttpContext.Session.GetInt32(ProdusenController.ID_SESSION);
                serviceModelDataVaksinClient.getDataVaksinByIDProdusen(ref listProdusenS, (int)idProdusen, ref StatusCode, ref Message);
                return View(listProdusenS);
            }
            return View();
        }

        [HttpGet]
        public IActionResult RegistrasiVaksin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrasiVaksin(ServiceBPOM.DataVaksin dataVaksin)
        {
            dataVaksin.id_produsen = (int)HttpContext.Session.GetInt32(ProdusenController.ID_SESSION);
            dataVaksin.jumlah_pakai = 0;
            bool success = serviceBPOMClient.RegistrasiVaksin(dataVaksin, ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if(IsLoggedIn())
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(Tracking_Vaksin_Services.Produsen produsen)
        {
            if (IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            bool success = serviceModelProdusenClient.register(produsen.username, produsen.password, produsen.nama, ref StatusCode, ref Message);
            if(success)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Message = Message;
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
        public IActionResult Login(Tracking_Vaksin_Services.Produsen produsen)
        {
            bool success = serviceModelProdusenClient.login(ref produsenS, produsen.username, produsen.password, ref StatusCode, ref Message);
            if (success)
            {
                HttpContext.Session.SetString(ProdusenController.USERNAME_SESSION, produsen.username);
                HttpContext.Session.SetInt32(ProdusenController.ID_SESSION, produsenS.id);
                HttpContext.Session.SetString(ProdusenController.ROLE_SESSION, ProdusenController.ROLE);
                HttpContext.Session.SetString(ProdusenController.NAMA_SESSION, produsenS.nama);
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

        
    }
}
