using Microsoft.AspNetCore.Mvc;
using ServiceBPOM; // Menggunakan ServiceBPOM untuk melaporkan registrasi vaksin
using ServiceModelDataPasien;
using ServiceModelDataPenduduk;
using ServiceModelDataVaksin;
using ServiceModelRumahSakit;
using ServicePemerintah;
using Tracking_Vaksin_Services;

namespace Tracking_Vaksin.Controllers
{
    public class RumahsakitController : Controller
    {
        private ServiceModelRumahSakit.RumahSakitS rumahSakitS = null;
        private ServiceModelDataVaksin.DataVaksinS dataVaksinS = null;
        private DataPasienS dataPasienS = null;
        private ServiceModelDataPenduduk.DataPendudukS dataPendudukS = null;

        private List<ServiceModelDataVaksin.DataVaksinS> listdataVaksinS = new List<ServiceModelDataVaksin.DataVaksinS>();
        private List<DataPasienS> listDataPasienS = new List<DataPasienS>();

        private ServiceModelRumahSakitClient serviceModelRumahSakitClient = new ServiceModelRumahSakitClient();
        private ServiceModelDataVaksinClient serviceModelDataVaksinClient = new ServiceModelDataVaksinClient();
        private ServiceModelDataPasienClient serviceModelDataPasienClient = new ServiceModelDataPasienClient();
        private ServiceModelDataPendudukClient serviceModelDataPendudukClient = new ServiceModelDataPendudukClient();
        private ServicePemerintahClient servicePemerintahClient = new ServicePemerintahClient();
        private ServiceBPOMClient serviceBPOMClient = new ServiceBPOMClient();

        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";
        public static string NAMA_SESSION = "_Nama";
        public static string ROLE = "RumahSakit";
        public static string ALAMAT = "_Alamat";

        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                ViewBag.username = HttpContext.Session.GetString("_Username");
                int idRumahSakit = (int)HttpContext.Session.GetInt32(RumahsakitController.ID_SESSION);
                serviceModelDataVaksinClient.getAllDataVaksin(ref listdataVaksinS, ref StatusCode, ref Message);
                return View(listdataVaksinS);
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
        public IActionResult Login(Tracking_Vaksin_Services.RumahSakit rumahSakit)
        {
            bool success = serviceModelRumahSakitClient.login(ref rumahSakitS, rumahSakit.username, rumahSakit.password, ref StatusCode, ref Message);
            if (success)
            {
                HttpContext.Session.SetString(RumahsakitController.USERNAME_SESSION, rumahSakit.username);
                HttpContext.Session.SetInt32(RumahsakitController.ID_SESSION, rumahSakitS.id);
                HttpContext.Session.SetString(RumahsakitController.ROLE_SESSION, RumahsakitController.ROLE);
                HttpContext.Session.SetString(RumahsakitController.NAMA_SESSION, rumahSakitS.nama);
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
            if (HttpContext.Session.GetString(RumahsakitController.USERNAME_SESSION) == ""
                || HttpContext.Session.GetString(RumahsakitController.USERNAME_SESSION) == null)
            {
                return false;
            }
            return true;
        }



        [HttpGet]
        public IActionResult UpdateDataVaksin(int id)
        {
            int idRumahSakit = (int)HttpContext.Session.GetInt32(RumahsakitController.ID_SESSION);
            serviceModelDataVaksinClient.getDataVaksinByID(ref dataVaksinS, id, ref StatusCode, ref Message);
            dataVaksinS.id_rumahsakit_penerima = idRumahSakit;
            bool success = serviceModelDataVaksinClient.updateDataVaksin(idRumahSakit, dataVaksinS, ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View("Index");
        }

        [HttpGet]
        public IActionResult TerimaVaksin(int id)
        {
            serviceModelDataVaksinClient.getDataVaksinByID(ref dataVaksinS, id, ref StatusCode, ref Message);
            bool success = serviceBPOMClient.LaporKedatanganVaksin(dataVaksinS.no_registrasi, ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View("Index");
        }
        [HttpGet]
        public IActionResult CreateDataPasien()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateDataPasien(Tracking_Vaksin_Services.DataPasien dataPasien)
        {
            int idRumahSakit = (int)HttpContext.Session.GetInt32(RumahsakitController.ID_SESSION);
            bool valid = servicePemerintahClient.KonfirmasiNIKPenduduk(dataPasien.nik, ref StatusCode, ref Message);
            if (!valid)
            {
                ViewBag.Message = Message;
                return View();
            }
            serviceModelDataPendudukClient.getDataPendudukByNIK(ref dataPendudukS, dataPasien.nik, ref StatusCode, ref Message);
            DataPasienS dataPasienS = new DataPasienS
            {
                id_penduduk = dataPendudukS.id,
                id_rumahsakit = idRumahSakit,
                id_vaksin = dataPasien.id_vaksin,
                nik = dataPasien.nik,
                tgl_terimavaksin = dataPasien.tgl_terimavaksin
            };
            bool success = serviceModelDataPasienClient.createDataPasien(ref dataPasienS, ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View();
        }

        [HttpGet]
        public IActionResult ListDataPasien()
        {
            int idRumahSakit = (int)HttpContext.Session.GetInt32(RumahsakitController.ID_SESSION);
            serviceModelDataPasienClient.getAllDataPasien(ref dataPasienS, ref listDataPasienS, ref StatusCode, ref Message);
            return View(listDataPasienS);
        }

        [HttpGet]
        public IActionResult DeleteDataPasien(int id)
        {
            bool success = serviceModelDataPasienClient.deleteDataPasien(id, ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("ListDataPasien");
            }
            ViewBag.Message = Message;
            return View("ListDataPasien");
        }

        [HttpGet]
        public IActionResult PemakaianVaksin()
        {
            serviceModelDataVaksinClient.getAllDataVaksin(ref listdataVaksinS, ref StatusCode, ref Message);
            return View(listdataVaksinS);
        }

        [HttpPost]
        public IActionResult PemakaianVaksin(string nik, int id)
        {
            int idRumahSakit = (int)HttpContext.Session.GetInt32(RumahsakitController.ID_SESSION);
            serviceModelDataVaksinClient.getDataVaksinByID(ref dataVaksinS, id, ref StatusCode, ref Message);
            serviceModelDataPasienClient.getDataPasienByNIK(ref dataPasienS, nik, ref StatusCode, ref Message);
            dataPasienS.id_vaksin = dataVaksinS.id;
            dataPasienS.tgl_terimavaksin = DateTime.Now;
            serviceModelDataPasienClient.updateDataPasien(ref dataPasienS, ref StatusCode, ref Message);
            bool success = serviceBPOMClient.LaporPenggunaanVaksin(dataVaksinS.no_registrasi, nik, 1 , ref StatusCode, ref Message);
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = Message;
            return View();
        }


    }
}
