﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelProdusen" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelProdusen
    {
        [OperationContract]
        bool register(string username, string password, string nama, ref int StatusCode, ref string Message);

        [OperationContract]
        bool login(ref ProdusenS produsen, string username, string password, ref int StatusCode, ref string Message);
        [OperationContract]
        bool getProdusenById(ref ProdusenS produsen, int id, ref int StatusCode, ref string Message);
    }

    [DataContract]
    public class ProdusenS
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string nama { get; set; }
    }
}
