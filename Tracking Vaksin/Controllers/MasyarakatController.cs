using Microsoft.AspNetCore.Mvc;
using Tracking_Vaksin_Services;
using ServiceDataModelMasyarakat;
using ServiceModelDataPasien;
using ServiceModelDataPenduduk;
using ServiceModelDataVaksin;
using ServiceModelProdusen;

namespace Tracking_Vaksin.Controllers
{
    public class MasyarakatController : Controller
    {
        private ServiceDataModelMasyarakat.MasyarakatS masyarakatS = null;
        private ServiceModelDataPenduduk.DataPendudukS dataPendudukS = null;
        private ServiceDataModelMasyarakat.DataPendudukS dataPendudukS2 = null;
        private DataPasienS dataPasienS = null;
        private ServiceModelDataVaksin.DataVaksinS dataVaksinS = null;
        private ServiceModelProdusen.ProdusenS produsenS = null;

        private ServiceModelMasyarakatClient serviceModelMasyarakatClient = new ServiceModelMasyarakatClient();
        private ServiceModelDataPendudukClient serviceModelDataPendudukClient = new ServiceModelDataPendudukClient();
        private ServiceModelDataPasienClient serviceModelDataPasienClient = new ServiceModelDataPasienClient();
        private ServiceModelDataVaksinClient serviceModelDataVaksinClient = new ServiceModelDataVaksinClient();
        private ServiceModelProdusenClient serviceModelProdusenClient = new ServiceModelProdusenClient();

        private int StatusCode = 500;
        private string Message = "";

        public static string USERNAME_SESSION = "_Username";
        public static string ID_SESSION = "_Id";
        public static string ROLE_SESSION = "_Role";

        public static string NAMA_SESSION = "_Nama";
        public static string NIK_SESSION = "_Nik";
        public static string ALAMAT_SESSION = "_Alamat";
        public static string JENIS_KELAMIN_SESSION = "_JenisKelamin";

        public static string MESSAGE_PASIEN_SESSION = "_MessagePasien";
        public static string MESSAGE_VAKSIN_SESSION = "_MessageVaksin";

        public static string TANGGAL_TERIMA_VAKSIN_SESSION = "_TanggalTerimaVaksin";

        public static string ROLE = "Masyarakat";
        
        public IActionResult Index()
        {
            if (IsLoggedIn())
            {
                var NIK = HttpContext.Session.GetString(NIK_SESSION);
                bool success = serviceModelDataPasienClient.getDataPasienByNIK(ref dataPasienS, NIK, ref StatusCode, ref Message);
                if(!success)
                {
                    HttpContext.Session.SetString(MasyarakatController.MESSAGE_PASIEN_SESSION, "Anda belum terdaftar sebagai pasien di Rumah Sakit. " +
                        "\nKunjungi Rumah Sakit untuk mendapat vaksin");
                    return View();
                }
                
                int? idVaksin = dataPasienS.id_vaksin;
                if(idVaksin == null)
                {
                    HttpContext.Session.SetString(MasyarakatController.MESSAGE_VAKSIN_SESSION, "Anda belum divaksin");
                }
                HttpContext.Session.SetString(MasyarakatController.TANGGAL_TERIMA_VAKSIN_SESSION, dataPasienS.tgl_terimavaksin.ToString());
                int idVaksinInt = idVaksin == null ? default(int) : (int)idVaksin;

                success = serviceModelDataVaksinClient.getDataVaksinByID(ref dataVaksinS, idVaksinInt, ref StatusCode, ref Message);
                return View(dataVaksinS);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (IsLoggedIn())
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(Tracking_Vaksin_Services.Masyarakat masyarakat, string NIK)
        {
            bool success = serviceModelDataPendudukClient.getDataPendudukByNIK(ref dataPendudukS, NIK, ref StatusCode, ref Message);
            if (!success && StatusCode == 404)
            {
                ViewBag.Message = "NIK Anda belum didaftarkan pemerintahan setempat, segera laporkan!";
                return View();
            }
            success = serviceModelMasyarakatClient.register(masyarakat.username, masyarakat.password, NIK, ref StatusCode, ref Message);
            if (!success)
            {
                ViewBag.Message = Message;
                return View();
            }
            return RedirectToAction("Login");
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
        public IActionResult Login(Masyarakat masyarakat)
        {
            bool success = serviceModelMasyarakatClient.login(ref masyarakatS, ref dataPendudukS2, masyarakat.username, masyarakat.password, ref StatusCode, ref Message);
            if (success)
            {
                HttpContext.Session.SetString(MasyarakatController.USERNAME_SESSION, masyarakatS.username);
                HttpContext.Session.SetInt32(MasyarakatController.ID_SESSION, masyarakatS.id);
                HttpContext.Session.SetString(MasyarakatController.ROLE_SESSION, MasyarakatController.ROLE);

                HttpContext.Session.SetString(MasyarakatController.NAMA_SESSION, dataPendudukS2.nama);
                HttpContext.Session.SetString(MasyarakatController.NIK_SESSION, dataPendudukS2.nik);
                HttpContext.Session.SetString(MasyarakatController.ALAMAT_SESSION, dataPendudukS2.alamat);
                HttpContext.Session.SetString(MasyarakatController.JENIS_KELAMIN_SESSION, dataPendudukS2.jenis_kelamin);

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
