using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class DistrictMasterBAL
    {
        public string InsertDistrictMaster(DistrictModel obj)
        {
            DistrictMasterDAL DistrictcallMethod = new DistrictMasterDAL();
            return DistrictcallMethod.insertDistrictMaster(obj);

        }
        public string updateDistrictMaster(DistrictModel obj)
        {
            DistrictMasterDAL DistrictcallMethod = new DistrictMasterDAL();
            return DistrictcallMethod.updateDistrictMaster(obj);

        }

        public List<DistrictModel> GetDistrictMaster(int companyId)
        {
            DistrictMasterDAL DistrictcallMethod = new DistrictMasterDAL();
            return DistrictcallMethod.GetDistrictMaster(companyId);

        }
        public List<CityModel> GetCity(int companyId)
        {
            DistrictMasterDAL StatecallMethod = new DistrictMasterDAL();
            return StatecallMethod.GetCity(companyId);

        }

        public string DeleteState(int id)
        {
            DistrictMasterDAL StatecallMethod = new DistrictMasterDAL();
            return StatecallMethod.DeleteDistrictMaster(id);

        }
        public List<DistrictModel> GetDistricts(DistrictModel request)
        {
            DistrictMasterDAL StatecallMethod = new DistrictMasterDAL();
            return StatecallMethod.GetDistricts(request);

        }

    }
}