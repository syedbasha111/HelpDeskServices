using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/Futureplan")]
    public class FutureplansController : ApiController
    {

        FutureplansBAL BAL = new FutureplansBAL();

        #region  
        [HttpPost]
        [Route("Getlistofplans")]
        public async Task<Hd_Responce> Getplans(Featureplansearch req)
        {
            return await BAL.Getplans(req);
        }
        #endregion

        #region  
        [HttpGet]
        [Route("GetplansTocreate")]
        public async Task<Hd_Responce> PlansToCreate()
         {
            return await BAL.PlansToCreate();
        }
        #endregion

        #region  
        [HttpPost]
        [Route("Insertplandetails")]
        public async Task<Hd_Responce> InsertCustomer(List<PlanListAddItemModel> req)
        {
            //string status = "";
            //status = BAL.SavePlanDetailsItems(req);
            return await BAL.SavePlanDetailsItems(req);
        }
        #endregion

        #region  
        [HttpPost]
        [Route("Inupdatedprovisionaldetails")]
        public async Task<Hd_Responce> Insertupdatedprovisional(List<PlanListAddItemModel> req)
        {
            //string status = "";
            //status = BAL.SavePlanDetailsItems(req);
            return await BAL.UpdateprovisionalplanDetailsItems(req);
        }
        #endregion



        public class Featureplansearch
        {
            public int Id { get; set; }
            public int planId { get; set; }
            public string Viewby { get; set; }
            public string fromdate { get; set; }
            public string todate { get; set; }
            public string pmtype { get; set; }
        }
    }
}