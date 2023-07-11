using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class RegionMaterBAL
    {
        public string CreateRegion(RegionModel obj)
        {
            RegionMasterDAL DAL= new RegionMasterDAL();
            return DAL.CreateRegion(obj);

        }

        public string UpdateRegion(RegionModel obj)
        {
            RegionMasterDAL DAL = new RegionMasterDAL();
            return DAL.UpdateRegion(obj);

        }

        public List<RegionModel> GetRegionMaster(int companyId)
        {
            RegionMasterDAL DAL = new RegionMasterDAL();
            return DAL.GetRegionMaster(companyId);

        }
        public List<RegionModel> GetRegions(RegionModel request)
        {
            RegionMasterDAL DAL = new RegionMasterDAL();
            return DAL.GetRegions(request);

        }
        public string DeleteRegion(int id)
        {
            RegionMasterDAL StatecallMethod = new RegionMasterDAL();
            return StatecallMethod.DeleteRegion(id);

        }

    }
}