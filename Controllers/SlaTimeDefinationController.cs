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
    public class SlaTimeDefinationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertSLATimeDefination(SlaTimeDefinationModel slaObj)
        {
            string result = "";
            SlaTimeDefinationBAL slatimeBal = new SlaTimeDefinationBAL();
            if (slaObj.SlaTimeDefinationId != 0)
            {
                result = slatimeBal.UpdateSLATimeDefination(slaObj);
            }
            else
            {
                result = slatimeBal.InsertSLATimeDefination(slaObj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetSLATimeDefination(int companyId)
        {
            SlaTimeDefinationBAL slatimeBal = new SlaTimeDefinationBAL();
            List<SlaTimeDefinationModel> slaList = new List<SlaTimeDefinationModel>();
            slaList=slatimeBal.GetSLATimeDefination(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, slaList);

        }

        [HttpDelete]
        public HttpResponseMessage DeleteSLATimeDefination(int recordId)
        {
            SlaTimeDefinationBAL slatimeBal = new SlaTimeDefinationBAL();
            string result = slatimeBal.DeleteSLATimeDefination(recordId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
