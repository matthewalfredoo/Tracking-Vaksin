using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelDataVaksin" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelDataVaksin
    {
        [OperationContract]
        bool getAllDataVaksin(ref List<DataVaksinS> dataVaksinS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataVaksinByID(ref DataVaksinS dataVaksinS, int id, ref int StatusCode, ref string Message);
        [OperationContract]
        bool getDataVaksinByIDProdusen(ref List<DataVaksinS> dataVaksinS, int idProdusen, ref int StatusCode, ref string Message);

        [OperationContract]
        bool createDataVaksin(DataVaksinS dataVaksinS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool updateDataVaksin(DataVaksinS dataVaksinS, ref int StatusCode, ref string Message);

        [OperationContract]
        bool deleteDataVaksin(int id, ref int StatusCode, ref string Message);
    }

    [DataContract]
    [KnownType(typeof(List<DataVaksinS>))]
    public class DataVaksinS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> id_produsen { get; set; }
        [DataMember]
        public Nullable<int> id_rumahsakit_penerima { get; set; }
        [DataMember]
        public string no_registrasi { get; set; }
        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public Nullable<System.DateTime> tgl_pembuatan { get; set; }
        [DataMember]
        public Nullable<System.DateTime> tgl_terima { get; set; }
        [DataMember]
        public Nullable<int> jumlah { get; set; }
        [DataMember]
        public Nullable<int> jumlah_pakai { get; set; }
    }
}
