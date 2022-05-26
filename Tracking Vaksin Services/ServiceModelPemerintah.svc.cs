﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tracking_Vaksin_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceModelPemerintah" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceModelPemerintah.svc or ServiceModelPemerintah.svc.cs at the Solution Explorer and start debugging.
    public class ServiceModelPemerintah : IServiceModelPemerintah
    {
        public bool login(ref Pemerintah pemerintah, string username, string password, ref int StatusCode, ref string message)
        {
            try
            {
                using(DBVaksinEntities db = new DBVaksinEntities())
                {
                    pemerintah = db.Pemerintah.Where(x => x.username == username && x.password == password).FirstOrDefault();
                    if(pemerintah != null)
                    {
                        StatusCode = 200;
                        message = "Success";
                        return true;
                    }
                    else
                    {
                        StatusCode = 404;
                        message = "Username or Password is wrong";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                message = ex.ToString();
                return false;
            }
        }
    }
}