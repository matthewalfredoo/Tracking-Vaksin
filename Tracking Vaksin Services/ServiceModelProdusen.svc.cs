using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelProdusen" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelProdusen.svc or ServiceModelProdusen.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelProdusen : IServiceModelProdusen
    {

        public bool login(ref ProdusenS produsenS, string username, string password, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.Produsen.Any(x => x.username == username && x.password == password))
                    {
                        Produsen produsen = db.Produsen.Where(x => x.username == username && x.password == password).FirstOrDefault();
                        produsenS = new ProdusenS()
                        {
                            id = produsen.id,
                            nama = produsen.nama,
                            username = produsen.username
                        };
                        
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

        public bool register(string username, string password, string nama, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    Produsen produsenBaru = new Produsen
                    {
                        username = username,
                        password = password,
                        nama = nama
                    };
                    db.Produsen.Add(produsenBaru);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Berhasil mendaftar";
                    return true;
                }
                catch (Exception e)
                {
                    StatusCode = 500;
                    Message = e.Message;
                    return false;
                }
            };
        }

        public bool getProdusenById(ref ProdusenS produsenS, int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.Produsen.Any(x => x.id == id))
                    {
                        Produsen produsen = db.Produsen.Where(x => x.id == id).FirstOrDefault();
                        produsenS = new ProdusenS()
                        {
                            id = produsen.id,
                            nama = produsen.nama,
                            username = produsen.username
                        };
                        
                        StatusCode = 200;
                        Message = "Berhasil mengambil data";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data tidak ditemukan";
                        return false;
                    }
                }
                catch (Exception e)
                {
                    StatusCode = 500;
                    Message = e.Message;
                    return false;
                }
            }
        }
    }
}

