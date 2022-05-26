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
        public bool createDataPenduduk(ref DataPendudukS dataPenduduk, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk pendudukCreate = new DataPenduduk
                    {
                        id = dataPenduduk.id,
                        id_pemerintah = dataPenduduk.id_pemerintah,
                        nama = dataPenduduk.nama,
                        nik = dataPenduduk.nik,
                        alamat = dataPenduduk.alamat,
                        jenis_kelamin = dataPenduduk.jenis_kelamin
                    };
                    db.DataPenduduk.Add(pendudukCreate);
                    
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
                    DataPenduduk dataPendudukDelete = db.DataPenduduk.Find(id);
                    db.DataPenduduk.Remove(dataPendudukDelete);
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

        public bool getAllDataPenduduk(ref List<DataPendudukS> dataPenduduk, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    var dataPendudukGetALl= db.DataPenduduk;
                    foreach (var data in dataPendudukGetALl)
                    {
                        DataPendudukS dataPendudukS = new DataPendudukS
                        {
                            id = data.id,
                            id_pemerintah = data.id_pemerintah,
                            nama = data.nama,
                            nik = data.nik,
                            alamat = data.alamat,
                            jenis_kelamin = data.jenis_kelamin
                        };
                        dataPenduduk.Add(dataPendudukS);
                    }
                    
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

        public bool getDataPendudukByID(ref DataPendudukS dataPendudukS, int ID, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPendudukGetByID = db.DataPenduduk.Find(ID);
                    if (dataPendudukGetByID != null)
                    {
                        dataPendudukS = new DataPendudukS
                        {
                            id = dataPendudukGetByID.id,
                            id_pemerintah = dataPendudukGetByID.id_pemerintah,
                            nama = dataPendudukGetByID.nama,
                            nik = dataPendudukGetByID.nik,
                            alamat = dataPendudukGetByID.alamat,
                            jenis_kelamin = dataPendudukGetByID.jenis_kelamin
                        };
                        
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

        public bool getDataPendudukByNIK(ref DataPendudukS dataPenduduk, string NIK, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPendudukGetByNIK= db.DataPenduduk.Where(x => x.nik == NIK).FirstOrDefault();
                    if (dataPenduduk != null)
                    {
                        dataPenduduk = new DataPendudukS
                        {
                            id = dataPendudukGetByNIK.id,
                            id_pemerintah = dataPendudukGetByNIK.id_pemerintah,
                            nama = dataPendudukGetByNIK.nama,
                            nik = dataPendudukGetByNIK.nik,
                            alamat = dataPendudukGetByNIK.alamat,
                            jenis_kelamin = dataPendudukGetByNIK.jenis_kelamin
                        };
                        
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

        public bool updateDataPenduduk(ref DataPendudukS dataPendudukS, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataPenduduk dataPendudukDiedit = db.DataPenduduk.Find(dataPendudukS.id);
                    dataPendudukDiedit.nama = dataPendudukS.nama;
                    dataPendudukDiedit.alamat = dataPendudukS.alamat;
                    dataPendudukDiedit.jenis_kelamin = dataPendudukS.jenis_kelamin;
                    db.DataPenduduk.Attach(dataPendudukDiedit);
                    db.Entry(dataPendudukDiedit).State = EntityState.Modified;
                    db.SaveChanges();

                    dataPendudukS = new DataPendudukS
                    {
                        id = dataPendudukDiedit.id,
                        id_pemerintah = dataPendudukDiedit.id_pemerintah,
                        nama = dataPendudukDiedit.nama,
                        nik = dataPendudukDiedit.nik,
                        alamat = dataPendudukDiedit.alamat,
                        jenis_kelamin = dataPendudukDiedit.jenis_kelamin
                    };
                    
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
