using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/Designation")]
    public class DesignationMasterController : ApiController
    {
        DesignationBAL BAL = new DesignationBAL();
        [HttpPost]
        [Route("Designation")] //Matches POST api/products
        public HttpResponseMessage SaveDesignation(DesignationModel request)
        {
            HD_BaseModel status = new HD_BaseModel();


            if (request.Id != 0)
            {
                status=BAL.UpdateDesignationMaster(request);
            }
            else
            {
                status=BAL.DesignationMaster(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("Designation")]
        public HttpResponseMessage GetDesignation(int companyId)
        {
            List<DesignationModel> List = new List<DesignationModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetDesignation(companyId));
        }

        [HttpPost]
        [Route("DeleteDesignation")]
        public HttpResponseMessage deletedesignation(DeleteObj obj)
        {
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = BAL.deletedesignation(obj));
        }
    }
}
