using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class CityMasterBAL
    {
        public string InsertCityMaster(CityModel obj)
        {
            CityMasterDAL CitycallMethod = new CityMasterDAL();
            return CitycallMethod.insertCityMaster(obj);

        }
        public string updateCityMaster(CityModel obj)
        {
            CityMasterDAL CitycallMethod = new CityMasterDAL();
            return CitycallMethod.updateCityMaster(obj);

        }

        public List<CityModel> GetCityMaster(int companyId)
        {
            CityMasterDAL CitycallMethod = new CityMasterDAL();
            return CitycallMethod.GetCityMaster(companyId);

        }
        public List<StateModel> GetState(int companyId,int countryId)
        {
            CityMasterDAL StatecallMethod = new CityMasterDAL();
            return StatecallMethod.GetState(companyId, countryId);

        }

        public List<CityModel> Getcitybystate(int companyId, int countryId,int stateid)
        {
            CityMasterDAL Citycallmethod = new CityMasterDAL();
            return Citycallmethod.Getcitybystate(companyId, countryId, stateid);

        }


        public string DeleteCityMaster(DeleteObj obj)
        {
            CityMasterDAL CitycallMethod = new CityMasterDAL();
            return CitycallMethod.deleteCityMaster(obj);

        }
    }
}