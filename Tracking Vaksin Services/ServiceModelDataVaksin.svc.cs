using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelDataVaksin" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelDataVaksin.svc or ServiceModelDataVaksin.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelDataVaksin : IServiceModelDataVaksin
    {
        public bool createDataVaksin(DataVaksin dataVaksin, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataVaksin dataVaksinValidation = db.DataVaksin.Where(x => x.no_registrasi == dataVaksin.no_registrasi).FirstOrDefault();
                    if(dataVaksinValidation != null)
                    {
                        StatusCode = 400;
                        Message = "Data Vaksin sudah ada";
                        return false;
                    }
                    
                    db.DataVaksin.Add(dataVaksin);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Berhasil menambahkan data vaksin";
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

        public bool deleteDataVaksin(int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataVaksin dataVaksinDihapus = db.DataVaksin.Where(x => x.id == id).FirstOrDefault();
                    if (dataVaksinDihapus == null)
                    {
                        StatusCode = 404;
                        Message = "Data vaksin tidak ditemukan";
                        return false;
                    }
                    db.DataVaksin.Remove(dataVaksinDihapus);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Berhasil menghapus data vaksin";
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

        public bool getAllDataVaksin(ref IEnumerable<DataVaksin> dataVaksin, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    dataVaksin = db.DataVaksin;
                    StatusCode = 200;
                    Message = "Berhasil mengambil data vaksin";
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

        public bool getDataVaksinByID(ref DataVaksin dataVaksin, int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    dataVaksin = db.DataVaksin.Where(x => x.id == id).FirstOrDefault();
                    if (dataVaksin == null)
                    {
                        StatusCode = 404;
                        Message = "Data vaksin tidak ditemukan";
                        return false;
                    }
                    StatusCode = 200;
                    Message = "Berhasil mengambil data vaksin";
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

        public bool updateDataVaksin(DataVaksin dataVaksin, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataVaksin dataVaksinDiedit = db.DataVaksin.Where(x => x.id == dataVaksin.id).FirstOrDefault();
                    if (dataVaksinDiedit == null)
                    {
                        StatusCode = 404;
                        Message = "Data vaksin tidak ditemukan";
                        return false;
                    }
                    dataVaksinDiedit.nama = dataVaksin.nama;
                    dataVaksinDiedit.jumlah = dataVaksin.jumlah;
                    db.DataVaksin.Attach(dataVaksinDiedit);
                    db.Entry(dataVaksinDiedit).State = EntityState.Modified;

                    StatusCode = 200;
                    Message = "Berhasil memperbarui data vaksin";
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
