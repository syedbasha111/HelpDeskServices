using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_routine
{
    [RoutePrefix("api/pmbyroutine")]
    public class CreateroutineController : ApiController
    {
        CreateroutineBAL BAL = new CreateroutineBAL();
        #region  getcreateroutine
        [HttpPost]
        [Route("getcreateroutine")]
        public async Task<IEnumerable<object>> getcreatedetails(allassetsreq request)
        {
            return await BAL.getcreatedetails(request);
        }

        #endregion

        #region   create plan
        [HttpPost]
        [Route("createplan")]
        public async Task<object> Createplan(List<planreq> req)
        {
            return await BAL.Createplan(req);
        }
        public class planreq
        {
            public string Id { get; set; }
            public string Frequency { get; set; }
            public string FromDate { get; set; }
            public string Todate { get; set; }
            public string Assetroute { get; set; }
        }
        #endregion

        #region  getcmgrpforchange 
        [HttpPost]
        [Route("getcmrtnforchange")]
        public async Task<Hd_Responce> getcreatedetailsforchange(allassetsreq request)
        {
            return await BAL.getcreatedetailsforchange(request);
        }
        #endregion
        #region  change plan
        [HttpPost]
        [Route("Changeplanrtn")]
        public async Task<Hd_Responce> Changeplan(List<planreq> req)
        {
            return await BAL.Changeplan(req);
        }
        #endregion

    }
}
