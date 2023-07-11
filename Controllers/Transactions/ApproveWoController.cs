using HelpDeskServices.BusinessAccessLayer.Transaction;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Transactions
{
    [RoutePrefix("api/Approve")]
    public class ApproveWoController : ApiController
    {
        ApproveWoBAL BAL = new ApproveWoBAL();

        [HttpPost]
        [Route("ApproveList")] //Matches POST api/products
        public HttpResponseMessage ApproveList (ApproveModel request)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BAL.ApproveList(request));
        }

        [HttpPost]
        [Route("bulkApproval")]
        public IHttpActionResult BulkApproval(List<Workorder> request)
        {
            return Ok(BAL.UpdateApproveorderlist(request));
        }


    }
}
