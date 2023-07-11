using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MaintananceServiceBLL
    {

        MaintananceServiceDAL MasterDAL = new MaintananceServiceDAL();
      
        public List<ServiceObject> GetServiceUnit(int campanyId)
        {
            
            return MasterDAL.GetServiceUnit(campanyId);
        }
        public List<ServiceObject> GetServicebybussinessID(int campanyId,int Id)
        {

            return MasterDAL.GetServicebybussinessID(campanyId,Id);
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

        public string DeleteService(int ServiceId,int CompanyId)
        {
            return MasterDAL.DeleteService(ServiceId, CompanyId);
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
        public List<LocationModel> GetLocationByCity(string cityCode,int companyId)
        {
            MasterModeulDAL MasterIDAl = new MasterModeulDAL();
            return MasterIDAl.GetLocationByCity(cityCode, companyId);
        }
    }
}