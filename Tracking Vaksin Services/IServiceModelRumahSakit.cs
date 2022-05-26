using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelRumahSakit" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelRumahSakit
    {
        [OperationContract]
        bool login(ref RumahSakitS rumahSakitS, string username, string password, ref int StatusCode, ref string Message);
    }

    [DataContract]
    public class RumahSakitS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public string alamat { get; set; }
    }
}
