using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_System.CreateController;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/Assetroutemaster")]

    public class AssetRoutemasterController : ApiController
    {
        AssetRoutemasterBAL BAL = new AssetRoutemasterBAL();


        #region  
        [HttpPost]
        [Route("create")]
        public async Task<Hd_Responce> SaveAssetroute(Assetroutegroupmode request)
        {
            if (request.Id > 0)
            {
                return await BAL.UpdateAssetroute(request);
            }
            else
            {
                return await BAL.SaveAssetroute(request);
            }
        }
        #endregion

        #region  
        [HttpGet]
        [Route("Getdetails")]
        public async Task<Hd_Responce> getdetails(int companyid)
        {
            
                return await BAL.getdetails(companyid);
            
        }
        #endregion

        #region  
        [HttpDelete]
        [Route("Delatedetails")]
        public async Task<Hd_Responce> Delatedetails(int Id,int companyid)
        {

            return await BAL.Delatedetails(Id,companyid);

        }
        #endregion

        #region  
        /// <summary>
        /// Asset route update inAddcapital asset table
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Assetrouteupdate")]
        public async Task<object> assetrouteupdate(List<planreq> req)
        {
            return await BAL.assetrouteupdate(req);
        }
       
        #endregion

    }

    public class Assetroutegroupmode
    { 
        public string code { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string Remarks { get; set; }
        public bool isActive { get; set; }
    }
}
