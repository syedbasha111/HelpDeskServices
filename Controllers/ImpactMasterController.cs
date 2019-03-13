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
    public class ImpactMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertImpactCallMaster(ImpactCallMasterModel impObject)
        {
            string status = "";
            ImpactCallMasterBAL impactbalmethods = new ImpactCallMasterBAL();
            if (impObject.ImpactCallMasterId != 0)
                status = impactbalmethods.UpdateImpactCallMaster(impObject);
            else
                status = impactbalmethods.InsertImpactCallMaster(impObject);

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetImpactCallMaster(int companyId)
        {
            ImpactCallMasterBAL getimpactbalmethods = new ImpactCallMasterBAL();
            List<ImpactCallMasterModel> impactObj = new List<ImpactCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, impactObj = getimpactbalmethods.GetImpactCallMaster(companyId));
        }
    }
}
