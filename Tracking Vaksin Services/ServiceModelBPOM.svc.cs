using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelBPOM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelBPOM.svc or ServiceModelBPOM.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelBPOM : IServiceModelBPOM
    {
        public bool login(ref BPOMS bpomS, string username, string password, ref int StatusCode, ref string Message)
        {
            using(DBVaksinEntities db = new DBVaksinEntities())
            {
                try
                {
                    if (db.BPOM.Any(x => x.username == username && x.password == password))
                    {
                        BPOM bpom = db.BPOM.Where(x => x.username == username && x.password == password).FirstOrDefault();
                        bpomS = new BPOMS
                        {
                            id = bpom.id,
                            username = bpom.username
                        };
                        
                        StatusCode = 200;
                        Message = "Login Success";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        Message = "Kombinasi username dan password salah";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    StatusCode = 500;
                    Message = ex.Message;
                    return false;
                }
            }
        }
    }
}
