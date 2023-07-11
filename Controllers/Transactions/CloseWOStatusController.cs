using HelpDeskServices.BusinessAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Transactions
{
    [RoutePrefix("api/CloseWO")]
    public class CloseWOStatusController : ApiController
    {
        CloseWOBAL BAL = new CloseWOBAL();

        [HttpPost]
        [Route("CloseWO")] 
        public IHttpActionResult CreateCloseWOStatus(CloseWOStatus request)
        {
            return Ok(BAL.CreateCloseWOStatus(request));
        }

        [HttpPost]
        [Route("RrejectCloseWO")]
        public IHttpActionResult RejectCloseWOStatus(CloseWOStatus request)
        {
            return Ok(BAL.RejectCloseWOStatus(request));
        }


        [HttpPost]
        [Route("AddTotalTime")]
        public IHttpActionResult AddTotalTime(List<Resources> request)
        {
            TimeSpan totaltime = TimeSpan.FromHours(0);

            // List<Resources> data = new List<Resources>();

            foreach (var data in request)
            {
                TimeSpan t1 = TimeSpan.Parse((data.TimeTaken).ToString());
                totaltime = t1.Add(totaltime);
            }

            return Ok(totaltime.ToString());

        }
    }
}
