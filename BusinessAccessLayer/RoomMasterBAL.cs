using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class RoomMasterBAL
    {
        public SiteMasterDropdownlist GetdetailsbyRoomType(int companyId, int Id)
        {
            RoomMasterDAL request = new RoomMasterDAL();
            return request.GetdetailsbyRoomType(companyId, Id);

        }
        public string CreateRoomMaster(RoomMasterModel obj)
        {
            RoomMasterDAL DAL = new RoomMasterDAL();
            return DAL.CreateRoomMaster(obj);

        }
        public string UpdateRoomMaster(RoomMasterModel obj)
        {
            RoomMasterDAL DAL = new RoomMasterDAL();
            return DAL.UpdateRoomMaster(obj);

        }
        public List<RoomMasterModel> GetRoomMaster(int companyId)
        {
            RoomMasterDAL DAL = new RoomMasterDAL();
            return DAL.GetRoomMaster(companyId);

        }
        public string deleteRoomMaster(int Id)
        {
            RoomMasterDAL DAL = new RoomMasterDAL();
            return DAL.deleteRoomMaster(Id);

        }

        public List<RoomMasterModel> GetRoomNameBYAreaid(int companyId,int Id)
        {
            RoomMasterDAL DAL = new RoomMasterDAL();
            return DAL.GetRoomNameBYAreaid(companyId,Id);

        }
    }
}