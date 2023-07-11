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
    [RoutePrefix("api/ReportingManager")]
    public class ReportingManagerController : ApiController
    {

        ReportingManagerBAL BAL = new ReportingManagerBAL();

        [HttpPost]
        [Route("ReportingManager")]
        public IHttpActionResult CreateReportingMaster(ReportingManager request)
        {
            if(request.Id>0)
            return Ok(BAL.UpdateReportingMaster(request));
            else
            return Ok(BAL.CreateReportingMaster(request));
        }

        [HttpPost]
        [Route("DeleteReporitng")]
        public IHttpActionResult DeleteReportingManger(DeleteObj req)
        {
            return Ok(BAL.DeleteReportingManger(req));
        }
    }
}
