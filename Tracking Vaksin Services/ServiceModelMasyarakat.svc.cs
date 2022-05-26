using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelMasyarakat" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelMasyarakat.svc or ServiceModelMasyarakat.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelMasyarakat : IServiceModelMasyarakat
    {
        public bool login(ref Masyarakat masyarakat, ref DataPenduduk dataPenduduk, string username, string password, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    Masyarakat masyarakatLogin = db.Masyarakat.Where(x => x.username == username && x.password == password).FirstOrDefault();
                    if (masyarakatLogin != null)
                    {
                        masyarakat = masyarakatLogin;
                        dataPenduduk = db.DataPenduduk.Where(x => x.id == masyarakatLogin.id_data_penduduk).FirstOrDefault();
                        StatusCode = 200;
                        Message = "Login Success";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Login Failed";
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

        public bool register(string username, string password, string nik, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPenduduk = db.DataPenduduk.Where(x => x.nik == nik).FirstOrDefault();
                    if (dataPenduduk != null)
                    {
                        Masyarakat masyarakatRegister = new Masyarakat
                        {
                            username = username,
                            password = password,
                            id_data_penduduk = dataPenduduk.id
                        };
                        db.Masyarakat.Add(masyarakatRegister);
                        db.SaveChanges();
                        StatusCode = 200;
                        Message = "Berhasil membuat akun baru";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "NIK tersebut tidak ditemukan";
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
