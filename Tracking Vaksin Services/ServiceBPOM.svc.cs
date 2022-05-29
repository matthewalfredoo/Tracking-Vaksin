using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceBPOM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceBPOM.svc or ServiceBPOM.svc.cs at the Solution Explorer and start debugging.
    public class ServiceBPOM : IServiceBPOM
    {

        public bool RegistrasiVaksin(DataVaksin Vaksin, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.DataVaksin.Any(x => x.no_registrasi == Vaksin.no_registrasi))
                    {
                        StatusCode = 400;
                        Message = "Data Vaksin dengan nomor registrasi tersebut sudah ada";
                        return false;
                    }
                    
                    db.DataVaksin.Add(Vaksin);
                    db.SaveChanges();
                    StatusCode = 200;
                    Message = "Vaksin berhasil ditambahkan";
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

        public bool LaporKedatanganVaksin(string NoRegistrasiVaksin, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataVaksin Vaksin = db.DataVaksin.Where(x => x.no_registrasi == NoRegistrasiVaksin).FirstOrDefault();
                    if (Vaksin != null)
                    {
                        Vaksin.tgl_terima = DateTime.Now;
                        db.SaveChanges();
                        StatusCode = 200;
                        Message = "Vaksin diterima oleh pihak rumah sakit";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data vaksin tidak ditemukan";
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

        public bool LaporPenggunaanVaksin(string NoRegistrasiVaksin, string NIK, int JumlahPakai, ref int StatusCode, ref string Message)
        {
            using (DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    DataVaksin Vaksin = db.DataVaksin.Where(x => x.no_registrasi == NoRegistrasiVaksin).FirstOrDefault();
                    DataPenduduk pendudukDiVaksin = db.DataPenduduk.Where(x => x.nik == NIK).FirstOrDefault();
                    if (Vaksin != null && pendudukDiVaksin != null)
                    {
                        Vaksin.jumlah_pakai += JumlahPakai;
                        db.SaveChanges();
                        StatusCode = 200;
                        Message = $"Pasien dengan nama {pendudukDiVaksin.nama} berhasil didaftarkan menggunakan vaksin nomor registrasi {NoRegistrasiVaksin}";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Data vaksin dan/atau data penduduk tidak ditemukan";
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
