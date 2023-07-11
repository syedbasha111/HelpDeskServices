using HelpDeskServices.BusinessAccessLayer.Maintenance_mgmt.pm_by_system;
using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_System
{

    [RoutePrefix("api/pmbysystem")]
    public class CreateController : ApiController
    {
        CreateplanBAL BAL = new CreateplanBAL();


        #region  getcreatesystem
        [HttpPost]
        [Route("getcreatesystem")]
        public async Task<IEnumerable<object>> getcreatedetails(allassetsreq request)
        {
            return await BAL.getcreatedetails(request);
        }
        #endregion

        #region getroutemappingdetails 
        [HttpPost]
        [Route("getroutemappingdetails")]
        public async Task<IEnumerable<object>> getroutemappingdetails(allassetsreq request)
        {
            return await BAL.getroutemappingdetails(request);
        }
        #endregion

        /// <summary>
        /// pmbysys change plan
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        #region  getcmsysforchange 
        [HttpPost]
        [Route("getcmsysforchange")]
        public async Task<Hd_Responce> getcreatedetailsforchange(allassetsreq request)
        {
            return await BAL.getcreatedetailsforchange(request);
        }
        #endregion


        #region  
        [HttpGet]
        [Route("getlocationbyassetSubsys")]
        public async Task<IEnumerable<object>> getlocationbyassetSubsys(int Companyid,string Subsys)
        {
            return await BAL.getlocationbyassetSubsys(Companyid, Subsys);
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

        #region  change plan
        [HttpPost]
        [Route("Changeplan")]
        public async Task<Hd_Responce> Changeplan(List<planreq> req)
        {
            return await BAL.Changeplan(req);
        }
        #endregion

        #region  Addchilddats
        /// <summary>
        /// Adding resource spares,tools and consumabels
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Addchilddats")]
        public async Task<Hd_Responce> Addchilddats(List<listofresourcesandspares> req)
        {
            return await BAL.Addchilddats(req);
        }
        #endregion

        #region getlistforapprove 
        /// <summary>
        /// get created list for approved details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getlistforapprove")]
        public async Task<Hd_Responce> getlistforapprove(allassetsreq request)
        {
            return await BAL.getlistforapprove(request);
        }
        #endregion




        #region  GetprintWOList
        /// <summary>
        /// get Print Wo List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetprintWOList")]
        public async Task<Hd_Responce> GetprintWOList(allassetsreq request)
        {
            return await BAL.GetprintWOList(request);
        }
        #endregion


        #region  
        /// <summary>
        /// get WO list for print 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetprintWOaftrapprv")]
        public async Task<Hd_Responce> GetprintWOaftrapprv(allassetsreq request)
        {
            return await BAL.GetprintWOaftrapprv(request);
        }
        #endregion


        #region  
        /// <summary>
        /// get count of child table resource,spares...
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getchildcounts")]
        public async Task<Hd_Responce> getchildcounts(int Id)
        {
            return await BAL.getchildcounts(Id);
        }
        #endregion

        #region  
        /// <summary>
        /// get list of child table resource,spares...
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getchilddata")]
        public async Task<Hd_Responce> getchilddata(int Id)
        {
            return await BAL.getchilddata(Id);
        }
        #endregion


        #region  
        /// <summary>
        /// get list of child table resource,spares... for update screen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getchilddataforupdate")]
        public async Task<Hd_Responce> getchilddataforupdate(int Id)
        {
            return await BAL.getchilddataforupdate(Id);
        }
        #endregion


        #region apprvWo
        /// <summary>
        /// Approve Wo Plan
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("apprvWo")]
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


        #region  
        /// <summary>
        /// get Tasklist for schedule screen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TasklistForschedule")]
        public async Task<Hd_Responce> getTasklistForschedule(int Id)
        {
            return await BAL.getTasklistForschedule(Id);
        }
        #endregion

        #region  
        /// <summary>
        /// Checking the holiday for workorder assign
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckingHolidayWO")]
        public async Task<Hd_Responce> CheckWOHoliday(string date,int ShiftId)
        {
            return await BAL.CheckWOHoliday(date, ShiftId);
        }
        #endregion




        #region  
        /// <summary>
        /// Updating resource spares,tools and consumabels
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePmbysyschilddats")]
        public async Task<Hd_Responce> UpdatePmBySYchilddats(List<listofresourcesandspares> req)
        {
            return await BAL.UpdatePmBySYchilddats(req);
        }
        #endregion


        #region  
        /// <summary>
        /// update wo close pmbysys
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateWoPmBySys")]
        public async Task<Hd_Responce> updateWoPmBySys(List<closereq> req)
        {
            return await BAL.updateWoPmBySys(req);
        }
        #endregion

        public class closereq
        {
            public int Id { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
        }
        #region  GetpmbySYSWoCloselist
        /// <summary>
        /// get pmby sys  WO list for print 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetpmbySYSWoCloselist")]
        public async Task<Hd_Responce> GetpmbySYSWoCloselist(allassetsreq request)
        {
            return await BAL.GetpmbySYSWoCloselist(request);
        }
        #endregion



        #region  
        /// <summary>
        /// get list of child table resource,spares...
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getclosedetailsbyplan")]
        public async Task<Hd_Responce> getclosedetailsbyplan(int Id)
        {
            return await BAL.getclosedetailsbyplan(Id);
        }
        #endregion


        #region  GetpmbySYSWoreshedulelist
        /// <summary>
        /// get pmby sys Reshedule list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetpmbySYSWoreshedulelist")]
        public async Task<Hd_Responce> GetpmbySYSWoreshedulelist(allassetsreq request)
        {
            return await BAL.GetpmbySYSWoreshedulelist(request);
        }
        #endregion


        #region  
        /// <summary>
        /// Updating date in reshdule wo resource spares,tools and consumabels
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("reshedulePmbysyschilddats")]
        public async Task<Hd_Responce> reshedulePmbysyschilddats(List<listofresourcesandspares> req)
        {
            return await BAL.reshedulePmbysyschilddats(req);
        }
        #endregion



    }
}
