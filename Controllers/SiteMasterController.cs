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
    [RoutePrefix("api/SiteMaster")]
    public class SiteMasterController : ApiController
    {
        [HttpPost]
        [Route("SiteMaster")] //Matches POST api/products
        public HttpResponseMessage CreateSiteMaster(SiteMasterModel request)
        {
            string status = "";
            SiteMaterBAL BAL = new SiteMaterBAL();
            if (request.ID > 0)
            {
                status = BAL.UpdateSiteMaster(request);
            }
            else
            {
                status = BAL.CreateSiteMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("SiteMaster")]
        public HttpResponseMessage GetSiteMaster(int companyId)
        {
            SiteMaterBAL BAL = new SiteMaterBAL();
            List<SiteMasterModel> List = new List<SiteMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetSiteMaster(companyId));
        }

        [HttpPost]
        [Route("DeleteSiteMaster")]
        public HttpResponseMessage DeleteSiteMaster(DeleteObj obj)
        {
            SiteMaterBAL responce = new SiteMaterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.DeleteSiteMaster(obj.RecordId));
        }
    }
}
