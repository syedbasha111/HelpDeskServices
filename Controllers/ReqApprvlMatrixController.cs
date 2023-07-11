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
    [RoutePrefix("api/ReqApprvlMatrix")]
    public class ReqApprvlMatrixController : ApiController
    {
        ReqApprvlMatrixBAL BAL = new ReqApprvlMatrixBAL();

        [HttpPost]
        [Route("ReqApprvlMatrix")]
        public IHttpActionResult SaveReqApprvlMatrix(requestApprovalmatrix request)
        {
            if (request.Id == 0) { return Ok(BAL.SaveReqApprvlMatrix(request)); }
            else { return Ok(BAL.UpdateReqApprvlMatrix(request)); }
            
        }

        [HttpGet]
        [Route("ReqApprvlMatrix")]
        public IHttpActionResult getReqApprvlMatrix(int CompanyId)
        {
            return Ok(BAL.getReqApprvlMatrix(CompanyId));
        }
        [HttpPost]
        [Route("deletereqmtrx")]
        public IHttpActionResult deleteApprovematrix(DeleteObj req)
        {
            return Ok(BAL.deleteApprovematrix(req));
        }
    }
}
