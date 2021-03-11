using AutoLib.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoLib.Models.DAO
{
    public class ServiceAutolib
    {
        private static ServiceAutolib instance;
        private static autolibContext dbContext;


        public static ServiceAutolib getInstance()
        {
            if (ServiceAutolib.instance == null)
            {
                ServiceAutolib.instance = new ServiceAutolib();
                dbContext = new autolibContext();
            }

            return ServiceAutolib.instance;
        }
        private ServiceAutolib()
        {

        }
    }
}
