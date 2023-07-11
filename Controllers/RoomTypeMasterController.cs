using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/RoomTypeMaster")]
    public class RoomTypeMasterController : ApiController
    {
        [HttpGet]
        [Route("detailsbyAreaId")]
        public HttpResponseMessage GetdetailsbyAreaId(int companyId, int Id)
        {
            RoomTypeBAL responce = new RoomTypeBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetdetailsbyAreaId(companyId, Id));
        }

        [HttpPost]
        [Route("RoomType")] //Matches POST api/products
        public HttpResponseMessage RoomTypeMaster(RoomtypeModel request)
        {
            string status = "";
            RoomTypeBAL BAL = new RoomTypeBAL();
            if (request.Id > 0)
            {
                status = BAL.UpdateRoomTypeMater(request);
            }
            else
            {
                status = BAL.CreateRoomtypeMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("RoomTypeDetails")]
        public HttpResponseMessage GetRoomtypeMaster(int companyId)
        {
            RoomTypeBAL responce = new RoomTypeBAL();
            List<RoomtypeModel> List = new List<RoomtypeModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetRoomtypeMaster(companyId));
        }

        [HttpDelete]
        [Route("DeleteRoomType")]
        public HttpResponseMessage deleteRoomMaster(int Id)
        {
            RoomTypeBAL responce = new RoomTypeBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.deleteRoomMaster(Id));
        }
    }
}
