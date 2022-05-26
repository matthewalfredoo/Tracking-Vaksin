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
        bool getAllDataPenduduk(ref IEnumerable<DataPenduduk> dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPendudukByID(ref DataPenduduk dataPenduduk, int ID, ref int StatusCode, ref string Message);

        [OperationContract]
        bool getDataPendudukByNIK(ref DataPenduduk dataPenduduk, string NIK, ref int StatusCode, ref string Message);

        [OperationContract]
        bool createDataPenduduk(ref DataPenduduk dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool updateDataPenduduk(ref DataPenduduk dataPenduduk, ref int StatusCode, ref string Message);

        [OperationContract]
        bool deleteDataPenduduk(int id, ref int StatusCode, ref string Message);
    }
}
