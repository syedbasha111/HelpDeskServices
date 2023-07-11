using HelpDeskServices.BusinessAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.AssetMaster
{
    [RoutePrefix("api/Miantanance/System")]
    public class MiantananceSystemController : ApiController
    {
        MiantananceSystemMasterBAL BAL = new MiantananceSystemMasterBAL();
        [HttpPost]
        [Route("System")] //Matches POST api/products
        public HttpResponseMessage SaveSystemMaster(SystemMaster request)
        {
            string Responce="";
            if (request.Id > 0)
            {
                Responce = BAL.UpdateSystem(request);
            }
            else {
                Responce = BAL.SaveSystem(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Responce);


        }
        [HttpGet]
        [Route("SystemData")] 
        public HttpResponseMessage GetSystemdata(int CompanyId)
        {
            List<SystemMaster> List = new List<SystemMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetSystemdata(CompanyId));
        }

        [HttpDelete]
        [Route("ClearSystem")]
        public HttpResponseMessage DeleteSystemdata(int CompanyId,int Id)
        {
            string Responce = "";
            return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.DeleteSystemdata(CompanyId,Id));
        }
        
    }
}
