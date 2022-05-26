using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelDataPasien" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelDataPasien
    {
        [OperationContract]
        bool getAllDataPasien(ref List<DataPasienS> dataPasienS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPasienByID(ref DataPasienS dataPasienS, int ID, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPasienByIDPenduduk(ref DataPasienS dataPasienS, int IDPenduduk, ref int StatusCode, ref string Message);
        
        [OperationContract]
        bool getDataPasienByNIK(ref DataPasienS dataPasienS, string NIK, ref int StatusCode, ref string Message);

        [OperationContract]
        bool createDataPasien(ref DataPasienS dataPasienS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool updateDataPasien(ref DataPasienS dataPasienS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool deleteDataPasien(int id, ref int StatusCode, ref string Message);
    }

    [DataContract]
    [KnownType(typeof(List<DataPasienS>))]
    public class DataPasienS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> id_penduduk { get; set; }
        [DataMember]
        public Nullable<int> id_rumahsakit { get; set; }
        [DataMember]
        public Nullable<int> id_vaksin { get; set; }
        [DataMember]
        public string nik { get; set; }
        [DataMember]
        public Nullable<System.DateTime> tgl_terimavaksin { get; set; }
    }
}
