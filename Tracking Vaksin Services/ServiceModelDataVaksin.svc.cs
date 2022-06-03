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
        public bool createDataVaksin(DataVaksinS dataVaksinS, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if(db.DataVaksin.Any(x => x.no_registrasi == dataVaksinS.no_registrasi))
                    {
                        StatusCode = 400;
                        Message = "Data Vaksin dengan nomor registrasi tersebut sudah ada";
                        return false;
                    }
                    
                    DataVaksin dataVaksinCreate = new DataVaksin
                    {
                        id = dataVaksinS.id,
                        id_produsen = dataVaksinS.id_produsen,
                        id_rumahsakit_penerima = dataVaksinS.id_rumahsakit_penerima,
                        no_registrasi = dataVaksinS.no_registrasi,
                        nama = dataVaksinS.nama,
                        tgl_pembuatan = dataVaksinS.tgl_pembuatan,
                        tgl_terima = dataVaksinS.tgl_terima,
                        jumlah = dataVaksinS.jumlah
                    };
                    
                    db.DataVaksin.Add(dataVaksinCreate);
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
                    if (db.DataVaksin.Any(x => x.id == id))
                    {
                        DataVaksin dataVaksinDelete = db.DataVaksin.Find(id);
                        db.DataVaksin.Remove(dataVaksinDelete);
                        db.SaveChanges();
                        StatusCode = 200;
                        Message = "Berhasil menghapus data vaksin";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data vaksin dengan id tersebut tidak ditemukan";
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

        public bool getAllDataVaksin(ref List<DataVaksinS> dataVaksinS, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    var dataVaksinGetAll = db.DataVaksin;
                    foreach (var data in dataVaksinGetAll)
                    {
                        DataVaksinS dataVaksin = new DataVaksinS
                        {
                            id = data.id,
                            id_produsen = data.id_produsen,
                            id_rumahsakit_penerima = data.id_rumahsakit_penerima,
                            no_registrasi = data.no_registrasi,
                            nama = data.nama,
                            tgl_pembuatan = data.tgl_pembuatan,
                            tgl_terima = data.tgl_terima,
                            jumlah = data.jumlah,
                            jumlah_pakai = data.jumlah_pakai
                        };
                        dataVaksinS.Add(dataVaksin);
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

        public bool getDataVaksinByID(ref DataVaksinS dataVaksinS, int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataVaksin.Any(x => x.id == id))
                    {
                        DataVaksin dataVaksinGetByID = db.DataVaksin.Find(id);
                        dataVaksinS = new DataVaksinS
                        {
                            id = dataVaksinGetByID.id,
                            id_produsen = dataVaksinGetByID.id_produsen,
                            id_rumahsakit_penerima = dataVaksinGetByID.id_rumahsakit_penerima,
                            no_registrasi = dataVaksinGetByID.no_registrasi,
                            nama = dataVaksinGetByID.nama,
                            tgl_pembuatan = dataVaksinGetByID.tgl_pembuatan,
                            tgl_terima = dataVaksinGetByID.tgl_terima,
                            jumlah = dataVaksinGetByID.jumlah,
                            jumlah_pakai = dataVaksinGetByID.jumlah_pakai
                        };
                        
                        StatusCode = 200;
                        Message = "Berhasil mengambil data vaksin";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data vaksin dengan id tersebut tidak ditemukan";
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

        public bool getDataVaksinByIDProdusen(ref List<DataVaksinS> dataVaksinS, int idProdusen, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    var dataVaksinGetByIDProdusen = db.DataVaksin.Where(x => x.id_produsen == idProdusen);
                    foreach (var data in dataVaksinGetByIDProdusen)
                    {
                        DataVaksinS dataVaksin = new DataVaksinS
                        {
                            id = data.id,
                            id_produsen = data.id_produsen,
                            id_rumahsakit_penerima = data.id_rumahsakit_penerima,
                            no_registrasi = data.no_registrasi,
                            nama = data.nama,
                            tgl_pembuatan = data.tgl_pembuatan,
                            tgl_terima = data.tgl_terima,
                            jumlah = data.jumlah,
                            jumlah_pakai = data.jumlah_pakai
                        };
                        dataVaksinS.Add(dataVaksin);
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

        public bool updateDataVaksin(DataVaksinS dataVaksinS, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataVaksin.Any(x => x.id == dataVaksinS.id))
                    {
                        DataVaksin dataVaksinUpdate = db.DataVaksin.Find(dataVaksinS.id);
                        dataVaksinUpdate.nama = dataVaksinS.nama;
                        dataVaksinUpdate.id_rumahsakit_penerima = dataVaksinS.id_rumahsakit_penerima;
                        dataVaksinUpdate.tgl_pembuatan = dataVaksinS.tgl_pembuatan;
                        dataVaksinUpdate.id_rumahsakit_penerima = dataVaksinS.id_rumahsakit_penerima;
                        dataVaksinUpdate.tgl_terima = dataVaksinS.tgl_terima;
                        dataVaksinUpdate.jumlah = dataVaksinS.jumlah;
                        db.SaveChanges();
                        
                        StatusCode = 200;
                        Message = "Berhasil mengubah data vaksin";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data vaksin dengan id tersebut tidak ditemukan";
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
