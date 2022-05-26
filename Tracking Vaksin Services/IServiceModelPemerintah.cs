using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelPemerintah" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelPemerintah
    {
        /**
         * Ini akan digunakan untuk mengambil data username dan password dari database tabel pemerintah atau login pemerintah
         */
        [OperationContract]
        bool login(ref PemerintahS pemerintahS, string username, string password, ref int StatusCode, ref string message);
    }

    [DataContract]
    public class PemerintahS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string username { get; set; }
    }
}
