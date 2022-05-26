using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePemerintah" in both code and config file together.
    [ServiceContract]
    public interface IServicePemerintah
    {
        /**
         * Fungsi ini digunakan oleh Rumah Sakit untuk mengkonfirmasi validitas NIK dari dataPenduduk
         * Jika nilai kembalian adalah true, maka NIK pada dataPenduduk adalah valid
         * Jika tidak, maka NIK pada dataPenduduk tidak valid
         */
        [OperationContract]
        bool KonfirmasiNIKPenduduk(string NIK, ref int StatusCode, ref string Message);
    }
}
