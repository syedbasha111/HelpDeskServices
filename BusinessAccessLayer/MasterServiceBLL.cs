using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MasterServiceBLL
    {

        MasterServiceDAL MasterDAL = new MasterServiceDAL();
      
        public List<ServiceObject> GetServiceUnit(int campanyId)
        {
            
            return MasterDAL.GetServiceUnit(campanyId);
        }

        public string InsertService(Service serviceObj)
        {
            return MasterDAL.InsertService(serviceObj);
        }

        public string updateService(Service serviceObj)
        {
            return MasterDAL.updateService(serviceObj);
        }

        public ServiceObject GetServiceById(int ServiceId)
        {
            return MasterDAL.GetServiceById(ServiceId);
        }

        public string DeleteService(int ServiceId)
        {
            return MasterDAL.DeleteService(ServiceId);
        }

        public List<CitiesModel> GetCities(string countryName)
        {
            MasterModeulDAL MasterIDAl = new MasterModeulDAL();
            return  MasterIDAl.GetCities(countryName);
        }

        public List<CitiesModel> GetAllCities()
        {
            MasterModeulDAL MasterIDAl = new MasterModeulDAL();
            return MasterIDAl.GetAllCities();
        }
        public List<CountriesModel> GetCoutries()
        {
            MasterModeulDAL MasterIDAl = new MasterModeulDAL();
            return MasterIDAl.GetCountries();
        }
    }
}