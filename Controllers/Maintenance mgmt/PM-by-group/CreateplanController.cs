using HelpDeskServices.BusinessAccessLayer.Maintenance_mgmt.Pm_by_Group;
using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_group
{
    [RoutePrefix("api/pmbygroup")]
    public class CreateplanController : ApiController
    {
        CreateplanBAL BAL = new CreateplanBAL();

        #region  getcreategroup
        [HttpPost]
        [Route("getcreategroup")]
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
        [Route("getcmgrpforchange")]
        public async Task<Hd_Responce> getcreatedetailsforchange(allassetsreq request)
        {
            return await BAL.getcreatedetailsforchange(request);
        }
        #endregion

        #region  change plan
        [HttpPost]
        [Route("Changeplan")]
        public async Task<Hd_Responce> Changeplan(List<planreq> req)
        {
            return await BAL.Changeplan(req);
        }
        #endregion

        #region getlistforapprove 
        /// <summary>
        /// get created list for approved details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getlistforapprovegroup")]
        public async Task<Hd_Responce> getlistforapprove(allassetsreq request)
        {
            return await BAL.getlistforapprove(request);
        }
        #endregion

        #region apprvWo
        /// <summary>
        /// Approve Wo Plan
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("apprvWogrp")]
        public async Task<Hd_Responce> ApprovePlanWo(List<apprvid> req)
        {
            return await BAL.ApprovePlanWo(req);
        }
        #region  
        /// <summary>
        /// get WO list Of Completed 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDetailsbycomplete")]
        public async Task<Hd_Responce> GetDetailsbycomplete(allassetsreq request)
        {
            return await BAL.GetDetailsbycomplete(request);
        }
        #endregion
        public class apprvid
        {
            public string Id { get; set; }
            public string Companyid { get; set; }
            public string Remarks { get; set; }
            public string Status { get; set; }
        }
        #endregion

        #region  GetprintWOaftrapprvgrp
        /// <summary>
        /// get WO list for print 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetprintWOaftrapprvgrp")]
        public async Task<Hd_Responce> GetprintWOaftrapprv(allassetsreq request)
        {
            return await BAL.GetprintWOaftrapprv(request);
        }
        #endregion

        #region  GetpmbygrpWoCloselist
        /// <summary>
        /// get pmby sys  WO list for print 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetpmbygrpWoCloselist")]
        public async Task<Hd_Responce> GetpmbygrpWoCloselist(allassetsreq request)
        {
            return await BAL.GetpmbygrpWoCloselist(request);
        }
        #endregion

        #region  GetpmbygrpWoreshedulelist
        /// <summary>
        /// get pmby sys Reshedule list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetpmbygrpWoreshedulelist")]
        public async Task<Hd_Responce> GetpmbygrpWoreshedulelist(allassetsreq request)
        {
            return await BAL.GetpmbygrpWoreshedulelist(request);
        }
        #endregion

    }

}
