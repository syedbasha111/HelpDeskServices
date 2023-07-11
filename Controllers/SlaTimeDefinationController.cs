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
    [RoutePrefix("api/SlaTime")]
    public class SlaTimeDefinationController : ApiController
    {
        SlaTimeDefinationBAL BAL = new SlaTimeDefinationBAL();
        [HttpPost]
        [Route("slatime")]
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

        [HttpPost]
        [Route("slatimesubitems")]
        public IHttpActionResult InsertSLATimesubItems(List<slatimesubitems> request)
        {
            string responce = "";
             responce = BAL.InsertSLATimesubItems(request);
            
            return Ok(responce);

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
