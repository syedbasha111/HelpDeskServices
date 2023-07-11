using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class RoomTypeBAL
    {
        public SiteMasterDropdownlist GetdetailsbyAreaId(int companyId, int Id)
        {
            RoomTypeDAL request = new RoomTypeDAL();
            return request.GetdetailsbyAreaId(companyId, Id);

        }

        public string CreateRoomtypeMaster(RoomtypeModel obj)
        {
            RoomTypeDAL DAL = new RoomTypeDAL();
            return DAL.CreateRoomtypeMaster(obj);

        }
        public string UpdateRoomTypeMater(RoomtypeModel obj)
        {
            RoomTypeDAL DAL = new RoomTypeDAL();
            return DAL.UpdateRoomTypeMater(obj);

        }

        public List<RoomtypeModel> GetRoomtypeMaster(int companyId)
        {
            RoomTypeDAL DAL = new RoomTypeDAL();
            return DAL.GetRoomtypeMaster(companyId);

        }

        public string deleteRoomMaster(int Id)
        {
            RoomTypeDAL DAL = new RoomTypeDAL();
            return DAL.deleteRoomMaster(Id);

        }
    }
}