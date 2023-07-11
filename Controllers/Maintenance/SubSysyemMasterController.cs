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
    [RoutePrefix("api/Maintenance/SubSystem")]
    public class MaintenanceSubSysyemController : ApiController
    {
        MaintenanceSubSystemBAL BAL = new MaintenanceSubSystemBAL();
        [HttpPost]
        [Route("SubSystem")] //Matches POST api/products
        public HttpResponseMessage SaveSubSystemMaster(SubSytem request)
        {
            string Responce = "";
            if (request.Id > 0)
            {
                Responce= BAL.UpdateSubSystem(request);
            }
            else
            {
                Responce = BAL.SaveSubSystem(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Responce);


        }

        [HttpPost]
        [Route("SystemDropDown")]
        public HttpResponseMessage DropdownSystemdata([FromBody] SystemMaster request)
        {
            List<SystemMaster> List = new List<SystemMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetSystemdata(request));
        }
        [HttpGet]
        [Route("SubSystemdata")]
        public HttpResponseMessage GetSubSystemData(int CompanyId)
        {
            List<SubSytem> List = new List<SubSytem>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetSubSystemData(CompanyId));
        }
        [HttpDelete]
        [Route("ClearSubSystem")]
        public HttpResponseMessage DeleteSubSystemdata(int CompanyId, int Id)
        {
            string Responce = "";
            return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.DeleteSubSystemdata(CompanyId, Id));
        }
    }
}
