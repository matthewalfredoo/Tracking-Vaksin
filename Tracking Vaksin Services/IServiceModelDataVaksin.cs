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
        bool getAllDataVaksin(ref IEnumerable<DataVaksin> dataVaksin, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataVaksinByID(ref DataVaksin dataVaksin, int id, ref int StatusCode, ref string Message);

        [OperationContract]
        bool createDataVaksin(DataVaksin dataVaksin, ref int StatusCode, ref string Message);

        [OperationContract]
        bool updateDataVaksin(DataVaksin dataVaksin, ref int StatusCode, ref string Message);

        [OperationContract]
        bool deleteDataVaksin(int id, ref int StatusCode, ref string Message);
    }
}
