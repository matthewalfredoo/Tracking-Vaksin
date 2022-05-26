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
        public bool login(ref MasyarakatS masyarakatS, ref DataPendudukS dataPendudukS, string username, string password, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.Masyarakat.Any(x => x.username == username && x.password == password))
                    {
                        Masyarakat masyarakatLogin = db.Masyarakat.Where(x => x.username == username && x.password == password).FirstOrDefault();
                        masyarakatS = new MasyarakatS
                        {
                            id = masyarakatLogin.id,
                            id_data_penduduk = masyarakatLogin.id_data_penduduk,
                            username = masyarakatLogin.username
                        };

                        int? idDataPenduduk = masyarakatLogin.id_data_penduduk;
                        DataPenduduk dataPendudukLogin = db.DataPenduduk.Where(x => x.id == idDataPenduduk).FirstOrDefault();
                        dataPendudukS = new DataPendudukS
                        {
                            id = dataPendudukLogin.id,
                            id_pemerintah = dataPendudukLogin.id_pemerintah,
                            nama = dataPendudukLogin.nama,
                            nik = dataPendudukLogin.nik,
                            alamat = dataPendudukLogin.alamat,
                            jenis_kelamin = dataPendudukLogin.jenis_kelamin
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

        public bool register(string username, string password, string nik, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (!db.DataPenduduk.Any(x => x.nik == nik))
                    {
                        StatusCode = 400;
                        Message = "NIK tersebut belum terdaftar";
                        return false;
                    }
                    
                    DataPenduduk dataPenduduk = db.DataPenduduk.Where(x => x.nik == nik).FirstOrDefault();
                    if (db.Masyarakat.Any(x => x.id_data_penduduk == dataPenduduk.id))
                    {
                        StatusCode = 400;
                        Message = "NIK tersebut sudah terdaftar pada akun lain";
                        return false;
                    }

                    
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
