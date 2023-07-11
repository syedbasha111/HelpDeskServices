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
    [RoutePrefix("api/FloorMaster")]
    public class FloorMasterController : ApiController
    {
        [HttpGet]
        [Route("detailsbyBuildingId")]
        public HttpResponseMessage GetDetailsbybuildingid(int companyId, int Id)
        {
            FloormasterBAL responce = new FloormasterBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetDetailsbybuildingid(companyId, Id));
        }
        [HttpPost]
        [Route("Floor")]
        public HttpResponseMessage Floordetails(FloorMasterModel request)
        {
            string Responce = "";
            FloormasterBAL BAL = new FloormasterBAL();
            if (request.ID > 0)
            {
                Responce = BAL.UpdateFloordetails(request);

            }
            else {
                Responce = BAL.InsertFloordetails(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Responce);
           
        }

        [HttpGet]
        [Route("FloorDetails")]
        public HttpResponseMessage GetFloorMaster(int companyId)
        {
            FloormasterBAL responce = new FloormasterBAL();
            List<FloorMasterModel> List = new List<FloorMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetFloorMaster(companyId));
        }

        [HttpDelete]
        [Route("DeleteFloor")]
        public HttpResponseMessage deleteFloorMaster(int Id)
        {
            FloormasterBAL responce = new FloormasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.deleteFloorMaster(Id));
        }

        [HttpGet]
        [Route("FloorName")]
        public HttpResponseMessage GetFloorbybuildingid(int companyId,int Id)
        {
            FloormasterBAL responce = new FloormasterBAL();
            List<FloorMasterModel> List = new List<FloorMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetFloorbybuildingid(companyId,Id));
        }

    }
}
