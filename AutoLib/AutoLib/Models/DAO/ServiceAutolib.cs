using AutoLib.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Vehicule GetVehicule(int id)
        {
            Vehicule vehicule = null;
            try
            {
                vehicule = (from m in dbContext.Vehicules
                            where m.IdVehicule == id
                            select m)
                            .FirstOrDefault();
                return vehicule;
            }
            catch (Exception e)
            {
                throw new Exception(e.HelpLink);
            }
        }

        public DataTable ListVehicules()
        {
            DataTable dt = new DataTable();
            /// On construit les colonnes
            /// du datatable

            dt.Columns.Add("idVehicule ", typeof(int));
            dt.Columns.Add("RFID ", typeof(int));
            dt.Columns.Add("etatBatterie", typeof(int));
            dt.Columns.Add("Disponibilite", typeof(String));
            dt.Columns.Add("latitude", typeof(float));
            dt.Columns.Add("longitude", typeof(float));
            dt.Columns.Add("type_vehicule ", typeof(int));


            var mesV = (from m in dbContext.Vehicules                       
                        select m);
                             

            foreach (var res in mesV)
            {
                dt.Rows.Add(res.IdVehicule, res.Rfid, res.EtatBatterie, res.Disponibilite,res.Latitude,res.Longitude,res.TypeVehicule);
            }
            return dt;


        }
    }
}
