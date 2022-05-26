using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelDataPenduduk" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelDataPenduduk
    {
        [OperationContract]
        bool getAllDataPenduduk(ref List<DataPendudukS> dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPendudukByID(ref DataPendudukS dataPenduduk, int ID, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPendudukByNIK(ref DataPendudukS dataPenduduk, string NIK, ref int StatusCode, ref string Message);

        [OperationContract]
        bool createDataPenduduk(ref DataPendudukS dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool updateDataPenduduk(ref DataPendudukS dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool deleteDataPenduduk(int id, ref int StatusCode, ref string Message);
    }

    [DataContract]
    [KnownType(typeof(List<DataPendudukS>))]
    public class DataPendudukS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> id_pemerintah { get; set; }
        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public string nik { get; set; }
        [DataMember]
        public string alamat { get; set; }
        [DataMember]
        public string jenis_kelamin { get; set; }
    }
}
