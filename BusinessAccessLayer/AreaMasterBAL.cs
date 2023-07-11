using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class AreaMasterBAL
    {
        public SiteMasterDropdownlist GetdetailsbyfloorId(int companyId, int Id)
        {
            AreaMasterDAL request = new AreaMasterDAL();
            return request.GetdetailsbyfloorId(companyId, Id);

        }

        public string CreateAreaMaster(AreaMasterModel obj)
        {
            AreaMasterDAL DAL = new AreaMasterDAL();
            return DAL.CreateAreaMaster(obj);

        }

        public string UpdateAreaMaster(AreaMasterModel obj)
        {
            AreaMasterDAL DAL = new AreaMasterDAL();
            return DAL.UpdateAreaMaster(obj);

        }

        public List<AreaMasterModel> GetAreaMaster(int companyId)
        {
            AreaMasterDAL DistrictcallMethod = new AreaMasterDAL();
            return DistrictcallMethod.GetAreaMaster(companyId);

        }

        public string deleteAreaMaster(int Id)
        {
            AreaMasterDAL DistrictcallMethod = new AreaMasterDAL();
            return DistrictcallMethod.deleteAreaMaster(Id);

        }

        public List<AreaMasterModel> GetAreabyFloorid(int companyId,int Id)
        {
            AreaMasterDAL DistrictcallMethod = new AreaMasterDAL();
            return DistrictcallMethod.GetAreabyFloorid(companyId,Id);

        }
    }
}