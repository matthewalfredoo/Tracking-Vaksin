using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceModelBPOM" in both code and config file together.
    [ServiceContract]
    public interface IServiceModelBPOM
    {
        [OperationContract]
        bool login(ref BPOM bpom, string username, string password, ref int StatusCode, ref string Message);
    }
}
