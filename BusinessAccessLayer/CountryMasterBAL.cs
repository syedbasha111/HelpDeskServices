using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class CountryMasterBAL
    {

        public string InsertCountryMaster(CountryModel obj)
        {
            CountryMasterDAL CountrycallMethod = new CountryMasterDAL();
            return CountrycallMethod.insertCountryMaster(obj);

        }
        public string updateCountryMaster(CountryModel obj)
        {
            CountryMasterDAL CountrycallMethod = new CountryMasterDAL();
            return CountrycallMethod.updateCountryMaster(obj);

        }

        public List<CountryModel> GetCountryMaster(int companyId)
        {
            CountryMasterDAL CountrycallMethod = new CountryMasterDAL();
            return CountrycallMethod.GetCountryMaster(companyId);

        }
        public string DeleteCountryMaster(DeleteObj obj)
        {
            CountryMasterDAL CountrycallMethod = new CountryMasterDAL();
            return CountrycallMethod.deleteCountryMaster(obj);

        }
    }
}