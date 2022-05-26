using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelMasyarakat" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelMasyarakat
    {
        [OperationContract]
        bool register(string username, string password, string nik, ref int StatusCode, ref string Message);

        [OperationContract]
        bool login(ref MasyarakatS masyarakatS, ref DataPendudukS dataPendudukS, string username, string password, ref int StatusCode, ref string Message);
    }

    [DataContract]
    public class MasyarakatS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> id_data_penduduk { get; set; }
        [DataMember]
        public string username { get; set; }
    }
}
