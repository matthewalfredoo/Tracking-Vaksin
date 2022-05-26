using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceBPOM" in both code and config file together.
    [ServiceContract]
    public interface IServiceBPOM
    {
        /**
         * Fungsi ini digunakan oleh Produsen Vaksin untuk mendaftarkan vaksin yang diproduksinya
         **/
        [OperationContract]
        bool RegistrasiVaksin(DataVaksin Vaksin, ref int StatusCode, ref string Message);

        /**
         * Fungsi ini digunakan oleh Rumah Sakit untuk melaporkan kedatangan vaksin di rumah sakit 
         **/
        [OperationContract]
        bool LaporKedatanganVaksin(string NoRegistrasiVaksin, ref int StatusCode, ref string Message);

        [OperationContract]
        /*(
         * Fungsi ini digunakan oleh Rumah Sakit untuk melaporkan penggunaan vaksin di rumah sakit 
         **/
        bool LaporPenggunaanVaksin(string NoRegistrasiVaksin, string NIK, int JumlahPakai, ref int StatusCode, ref string Message);
    }
}
