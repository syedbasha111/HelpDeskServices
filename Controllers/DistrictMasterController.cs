using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/District")]
    public class DistrictMasterController : ApiController
    {
        [HttpPost]
        [Route("District")] //Matches POST api/products
        public HttpResponseMessage District(DistrictModel request)
        {
            string status = "";
            DistrictMasterBAL getCity = new DistrictMasterBAL();
            if (request.DistrictId>0) { status = getCity.updateDistrictMaster(request); }
            else { status = getCity.InsertDistrictMaster(request); }
                
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("district")]
        public HttpResponseMessage GetDistrictMaster(int companyId)
        {
            DistrictMasterBAL responce = new DistrictMasterBAL();
            List<DistrictModel> List = new List<DistrictModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetDistrictMaster(companyId));
        }
        [HttpPost]
        [Route("DeleteDistrict")]
        public HttpResponseMessage deleteDistrictMaster(DeleteObj obj)
        {
            DistrictMasterBAL responce = new DistrictMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.DeleteState(obj.RecordId));
        }


        [HttpPost]
        [Route("DistrictsFoeCities")]
        public HttpResponseMessage GetDistricts(DistrictModel request)
            {
            DistrictMasterBAL responce = new DistrictMasterBAL();
            List<DistrictModel> List = new List<DistrictModel>();


            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetDistricts(request));
        }
    }
}
