using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/ReqFrom")]
    public class ReqFromMasterController : ApiController
    {
        ReqFromMasterBAL BAL = new ReqFromMasterBAL();

        [HttpPost]
        [Route("ReqFrom")]
        public IHttpActionResult CreateReqFrom(RequestForm request)
        {
            if (request.Id > 0){return Ok(BAL.UpdateReqfrom(request));}
            else { return Ok(BAL.CreatereqFrom(request)); }
        }

        [HttpGet]
        [Route("ReqFrom")]
        public IHttpActionResult GetReqMaster(int companyId)
        {
            return Ok(BAL.GetReqMaster(companyId));
        }

        [HttpPost]
        [Route("DeleteReqfrom")]
        public IHttpActionResult DeleteReqfrom(DeleteObj obj)
        {
            return Ok(BAL.DeleteReqfrom(obj));
        }



    }
}
