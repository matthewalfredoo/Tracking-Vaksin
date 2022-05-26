using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelDataPenduduk" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelDataPenduduk.svc or ServiceModelDataPenduduk.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelDataPenduduk : IServiceModelDataPenduduk
    {
        public bool createDataPenduduk(ref DataPenduduk dataPenduduk, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    db.DataPenduduk.Add(dataPenduduk);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Data penduduk berhasil ditambahkan";
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

        public bool deleteDataPenduduk(int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPendudukDihapus = db.DataPenduduk.Find(id);
                    db.DataPenduduk.Remove(dataPendudukDihapus);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Data penduduk berhasil dihapus";
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

        public bool getAllDataPenduduk(ref IEnumerable<DataPenduduk> dataPenduduk, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    dataPenduduk = db.DataPenduduk;
                    StatusCode = 200;
                    Message = "Data penduduk berhasil diambil";
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

        public bool getDataPendudukByID(ref DataPenduduk dataPenduduk, int ID, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    dataPenduduk = db.DataPenduduk.Find(ID);
                    if (dataPenduduk != null)
                    {
                        StatusCode = 200;
                        Message = "Data penduduk berhasil diambil";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data penduduk tidak ditemukan";
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

        public bool getDataPendudukByNIK(ref DataPenduduk dataPenduduk, string NIK, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    dataPenduduk = db.DataPenduduk.Where(x => x.nik == NIK).FirstOrDefault();
                    if (dataPenduduk != null)
                    {
                        StatusCode = 200;
                        Message = "Data penduduk berhasil diambil";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data penduduk tidak ditemukan";
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

        public bool updateDataPenduduk(ref DataPenduduk dataPenduduk, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPendudukDiedit = db.DataPenduduk.Find(dataPenduduk.id);
                    dataPendudukDiedit.nama = dataPenduduk.nama;
                    dataPendudukDiedit.alamat = dataPenduduk.alamat;
                    dataPendudukDiedit.jenis_kelamin = dataPenduduk.jenis_kelamin;
                    db.DataPenduduk.Attach(dataPendudukDiedit);
                    db.Entry(dataPendudukDiedit).State = EntityState.Modified;
                    db.SaveChanges();

                    StatusCode = 200;
                    Message = "Data penduduk berhasil diperbarui";
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
