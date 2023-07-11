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
    [RoutePrefix("api/AreaMaster")]
    public class AreaMasterController : ApiController
    {
        [HttpGet]
        [Route("detailsbyfloorId")]
        public HttpResponseMessage GetdetailsbyfloorId(int companyId, int Id)
        {
            AreaMasterBAL responce = new AreaMasterBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetdetailsbyfloorId(companyId, Id));
        }

        [HttpPost]
        [Route("Area")] //Matches POST api/products
        public HttpResponseMessage Areamaster(AreaMasterModel request)
        {
            string status = "";
            AreaMasterBAL BAL = new AreaMasterBAL();
            if (request.ID > 0)
            {
                status = BAL.UpdateAreaMaster(request);
            }
            else
            {
                status = BAL.CreateAreaMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("AreaDetails")]
        public HttpResponseMessage GetAreaMaster(int companyId)
        {
            AreaMasterBAL responce = new AreaMasterBAL();
            List<AreaMasterModel> List = new List<AreaMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetAreaMaster(companyId));
        }

        [HttpDelete]
        [Route("DeleteArea")]
        public HttpResponseMessage deleteAreaMaster(int Id)
        {
            AreaMasterBAL responce = new AreaMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.deleteAreaMaster(Id));
        }

        [HttpGet]
        [Route("AreaName")]
        public HttpResponseMessage GetAreabyFloorid(int companyId,int Id)
        {
            AreaMasterBAL responce = new AreaMasterBAL();
            List<AreaMasterModel> List = new List<AreaMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetAreabyFloorid(companyId,Id));
        }
    }
}
