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
    [RoutePrefix("api/RoomMaster")]
    public class RoomMasterController : ApiController
    {
        [HttpGet]
        [Route("detailsbyRoomType")]
        public HttpResponseMessage GetdetailsbyRoomType(int companyId, int Id)
        {
            RoomMasterBAL responce = new RoomMasterBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetdetailsbyRoomType(companyId, Id));
        }

        [HttpPost]
        [Route("RoomMaster")] //Matches POST api/products
        public HttpResponseMessage RoomMaster(RoomMasterModel request)
        {
            string status = "";
            RoomMasterBAL BAL = new RoomMasterBAL();
            if (request.ID > 0)
            {
                status = BAL.UpdateRoomMaster(request);

            }
            else
            {
                status = BAL.CreateRoomMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("RoomDetails")]
        public HttpResponseMessage GetRoomMaster(int companyId)
        {
            RoomMasterBAL responce = new RoomMasterBAL();
            List<RoomMasterModel> List = new List<RoomMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetRoomMaster(companyId));
        }

        [HttpDelete]
        [Route("DeleteRoom")]
        public HttpResponseMessage deleteRoomMaster(int Id)
        {
            RoomMasterBAL responce = new RoomMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.deleteRoomMaster(Id));
        }

        [HttpGet]
        [Route("RoomName")]
        public HttpResponseMessage GetRoomNameBYAreaid(int companyId,int Id)
        {
            RoomMasterBAL responce = new RoomMasterBAL();
            List<RoomMasterModel> List = new List<RoomMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetRoomNameBYAreaid(companyId,Id));
        }
    }
}
