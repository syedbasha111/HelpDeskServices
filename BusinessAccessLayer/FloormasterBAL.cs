using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class FloormasterBAL
    {
        public SiteMasterDropdownlist GetDetailsbybuildingid(int companyId, int Id)
        {
            FloorMasterDAL request = new FloorMasterDAL();
            return request.GetDetailsbybuildingid(companyId, Id);

        }

        public string InsertFloordetails(FloorMasterModel request)
        {
            FloorMasterDAL DAL =new FloorMasterDAL();

            return DAL.InsertFloordetails(request);
        }
        public string UpdateFloordetails(FloorMasterModel request)
        {
            FloorMasterDAL DAL = new FloorMasterDAL();

            return DAL.UpdateFloordetails(request);
        }
        public List<FloorMasterModel> GetFloorMaster(int companyId)
        {
            FloorMasterDAL DistrictcallMethod = new FloorMasterDAL();
            return DistrictcallMethod.GetFloorMaster(companyId);

        }
        public string deleteFloorMaster(int Id)
        {
            FloorMasterDAL DistrictcallMethod = new FloorMasterDAL();
            return DistrictcallMethod.deleteFloorMaster(Id);

        }
        public List<FloorMasterModel> GetFloorbybuildingid(int companyId,int Id)
        {
            FloorMasterDAL DistrictcallMethod = new FloorMasterDAL();
            return DistrictcallMethod.GetFloorbybuildingid(companyId,Id);

        }
    }
}