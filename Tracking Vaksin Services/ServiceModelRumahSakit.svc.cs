using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelRumahSakit" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelRumahSakit.svc or ServiceModelRumahSakit.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelRumahSakit : IServiceModelRumahSakit
    {
        public bool login(ref RumahSakitS rumahSakitS, string username, string password, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.RumahSakit.Any(x => x.username == username && x.password == password))
                    {
                        RumahSakit rumahSakitLogin = db.RumahSakit.Where(x => x.username == username && x.password == password).FirstOrDefault();
                        rumahSakitS = new RumahSakitS
                        {
                            id = rumahSakitLogin.id,
                            username = rumahSakitLogin.username,
                            nama = rumahSakitLogin.nama,
                            alamat = rumahSakitLogin.alamat
                        };
                        StatusCode = 200;
                        Message = "Berhasil login";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Kombinasi username dan password salah";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    StatusCode = 500;
                    Message = ex.Message;
                    return false;
                }
            }
        }
    }
}
