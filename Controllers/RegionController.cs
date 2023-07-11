using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/Region")]
    public class RegionController : ApiController
    {
        [HttpPost]
        [Route("Region")] //Matches POST api/products
        public HttpResponseMessage CreateRegion(RegionModel request)
        {
            string status = "";
            RegionMaterBAL BAL = new RegionMaterBAL();
            if (request.RegionId>0) {
                status = BAL.UpdateRegion(request);
            }
            else {
                status = BAL.CreateRegion(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("Region")]
        public HttpResponseMessage GetRegionMaster(int companyId)
        {
            RegionMaterBAL BAL = new RegionMaterBAL();
            List<RegionModel> List = new List<RegionModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetRegionMaster(companyId));
        }
        [HttpPost]
        [Route("DeleteRegion")]
        public HttpResponseMessage DeleteRegion(DeleteObj obj)
        {
            RegionMaterBAL responce = new RegionMaterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.DeleteRegion(obj.RecordId));
        }

        [HttpPost]
        [Route("RegionforDistricts")]
        public HttpResponseMessage GetREgions(RegionModel request)
        {
            RegionMaterBAL responce = new RegionMaterBAL();
            List<RegionModel> List = new List<RegionModel>();


            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetRegions(request));
        }

    }
}