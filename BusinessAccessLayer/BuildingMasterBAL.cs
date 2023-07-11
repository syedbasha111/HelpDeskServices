using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class BuildingMasterBAL
    {

        public string CreatebuildingMaster(BuildingModel obj)
        {
            BuildingMasterDAL DAL = new BuildingMasterDAL();
            return DAL.CreatebuildingMaster(obj);

        }
        public string updatebuildingMaster(BuildingModel obj)
        {
            BuildingMasterDAL DAL = new BuildingMasterDAL();
            return DAL.updatebuildingMaster(obj);

        }
        public SiteMasterDropdownlist GetDetailsbyZoneid(int companyId, int Id)
        {
            BuildingMasterDAL request = new BuildingMasterDAL();
            return request.GetDetailsbyZoneid(companyId, Id);

        }

        public List<BuildingModel> GetBuildingMaster(int companyId)
        {
            BuildingMasterDAL DistrictcallMethod = new BuildingMasterDAL();
            return DistrictcallMethod.GetBuildingMaster(companyId);

        }
        public string deleteBuildingMaster(int Id)
        {
            BuildingMasterDAL DistrictcallMethod = new BuildingMasterDAL();
            return DistrictcallMethod.deleteBuildingMaster(Id);

        }

        public List<BuildingModel> GetBuildingNameByZoneid(int companyId,int Id)
        {
            BuildingMasterDAL DistrictcallMethod = new BuildingMasterDAL();
            return DistrictcallMethod.GetBuildingNameByZoneid(companyId,Id);

        }
    }
}