using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePemerintah" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePemerintah.svc or ServicePemerintah.svc.cs at the Solution Explorer and start debugging.
    public class ServicePemerintah : IServicePemerintah
    {
        public bool KonfirmasiNIKPenduduk(string NIK, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                var data = db.DataPenduduk.Where(x => x.nik == NIK).FirstOrDefault();
                if (data != null)
                {
                    StatusCode = 200;
                    Message = "Data ditemukan";
                    return true;
                }
                else
                {
                    StatusCode = 404;
                    Message = "Data tidak ditemukan";
                    return false;
                }
            }
        }
    }
}
