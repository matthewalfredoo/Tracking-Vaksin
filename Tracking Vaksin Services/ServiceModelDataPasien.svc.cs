using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelDataPasien" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelDataPasien.svc or ServiceModelDataPasien.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelDataPasien : IServiceModelDataPasien
    {
        public bool createDataPasien(ref DataPasienS dataPasienS, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    int? idPenduduk = dataPasienS.id_penduduk;
                    if (db.DataPasien.Any(x => x.id_penduduk == idPenduduk)) 
                    {
                        StatusCode = 400;
                        Message = "Data pasien sudah ada";
                        return false;
                    }
                    
                    DataPenduduk dataPenduduk = db.DataPenduduk.Find(idPenduduk);
                    DataPasien dataPasienCreate = new DataPasien
                    {
                        id = dataPasienS.id,
                        id_penduduk = dataPasienS.id_penduduk,
                        id_rumahsakit = dataPasienS.id_rumahsakit,
                        nik = dataPenduduk.nik
                    };
                    db.DataPasien.Add(dataPasienCreate);
                    db.SaveChanges();

                    StatusCode = 200;
                    Message = "Data pasien berhasil ditambahkan";
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

        public bool deleteDataPasien(int id, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataPasien.Any(x => x.id == id))
                    {
                        DataPasien dataPasienDelete = db.DataPasien.Find(id);
                        db.DataPasien.Remove(dataPasienDelete);
                        db.SaveChanges();

                        StatusCode = 200;
                        Message = "Data pasien berhasil dihapus";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data pasien tidak ditemukan";
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

        public bool getAllDataPasien(ref List<DataPasienS> dataPasienS, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    var dataPasienGetAll = db.DataPasien;
                    foreach (var data in dataPasienGetAll)
                    {
                        DataPasienS dataPasien = new DataPasienS
                        {
                            id = data.id,
                            id_penduduk = data.id_penduduk,
                            id_rumahsakit = data.id_rumahsakit,
                            id_vaksin = data.id_vaksin,
                            nik = data.nik,
                            tgl_terimavaksin = data.tgl_terimavaksin
                        };
                        dataPasienS.Add(dataPasien);
                    }

                    StatusCode = 200;
                    Message = "Data pasien berhasil diambil";
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

        public bool getDataPasienByID(ref DataPasienS dataPasienS, int ID, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataPasien.Any(x => x.id == ID))
                    {
                        DataPasien dataPasien = db.DataPasien.Find(ID);
                        dataPasienS = new DataPasienS
                        {
                            id = dataPasien.id,
                            id_penduduk = dataPasien.id_penduduk,
                            id_rumahsakit = dataPasien.id_rumahsakit,
                            id_vaksin = dataPasien.id_vaksin,
                            nik = dataPasien.nik,
                            tgl_terimavaksin = dataPasien.tgl_terimavaksin
                        };

                        StatusCode = 200;
                        Message = "Data pasien berhasil diambil";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data pasien tidak ditemukan";
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

        public bool getDataPasienByIDPenduduk(ref DataPasienS dataPasienS, int IDPenduduk, ref int StatusCode, ref string Message)
        {
            try
            {
                using (DBVaksinEntities db = new DBVaksinEntities())
                {
                    if (db.DataPasien.Any(x => x.id_penduduk == IDPenduduk))
                    {
                        DataPasien dataPasien = db.DataPasien.Where(x => x.id_penduduk == IDPenduduk).FirstOrDefault();
                        dataPasienS = new DataPasienS
                        {
                            id = dataPasien.id,
                            id_penduduk = dataPasien.id_penduduk,
                            id_rumahsakit = dataPasien.id_rumahsakit,
                            id_vaksin = dataPasien.id_vaksin,
                            nik = dataPasien.nik,
                            tgl_terimavaksin = dataPasien.tgl_terimavaksin
                        };

                        StatusCode = 200;
                        Message = "Data pasien berhasil diambil";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data pasien tidak ditemukan";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                Message = ex.Message;
                return false;
            }
        }

        bool IServiceModelDataPasien.getDataPasienByNIK(ref DataPasienS dataPasienS, string NIK, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataPasien.Any(x => x.nik == NIK))
                    {
                        DataPasien dataPasien = db.DataPasien.Where(x => x.nik == NIK).FirstOrDefault();
                        dataPasienS = new DataPasienS
                        {
                            id = dataPasien.id,
                            id_penduduk = dataPasien.id_penduduk,
                            id_rumahsakit = dataPasien.id_rumahsakit,
                            id_vaksin = dataPasien.id_vaksin,
                            nik = dataPasien.nik,
                            tgl_terimavaksin = dataPasien.tgl_terimavaksin
                        };

                        StatusCode = 200;
                        Message = "Data pasien berhasil diambil";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data pasien tidak ditemukan";
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

        public bool updateDataPasien(ref DataPasienS dataPasienS, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    int idPasien = dataPasienS.id;
                    if (db.DataPasien.Any(x => x.id == idPasien))
                    {
                        DataPasien dataPasienUpdate = db.DataPasien.Find(dataPasienS.id);
                        DataPenduduk dataPenduduk = db.DataPenduduk.Find(dataPasienS.id_penduduk);
                        
                        dataPasienUpdate.id_penduduk = dataPasienS.id_penduduk;
                        dataPasienUpdate.id_vaksin = dataPasienS.id_vaksin;
                        dataPasienUpdate.nik = dataPenduduk.nik;
                        dataPasienUpdate.tgl_terimavaksin = dataPasienS.tgl_terimavaksin;
                        db.SaveChanges();

                        StatusCode = 200;
                        Message = "Data pasien berhasil diubah";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data pasien tidak ditemukan";
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
