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
    [RoutePrefix("api/ServiceEscalation")]
    public class ServiceEscalationController : ApiController
    {
        ServiceEscalationBAL BAL = new ServiceEscalationBAL();
        [HttpPost]
        [Route("servicesEscalation")]
        public HttpResponseMessage InsertServiceEscalation(ServiceEscalationModel obj)
        {
            string result = "";
            if (obj.ServiceEscalationId != 0)
            {
                result = BAL.UpdateServiceEscalationById(obj);
            }
            else
            {
                result = BAL.InsertServiceEscalationById(obj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        [Route("EscalationSUbItems")]
        public IHttpActionResult SaveusersCheckList(List<ServiceEscalationSubItems> request)
        {
            string Responce = BAL.SaveusersCheckList(request);
            return Ok(Responce);

        }
        [HttpGet]
        [Route("GetServiceEscalation")]

        public HttpResponseMessage GetServiceEscalation(int companyID)
        {
            List<ServiceEscalationModel> escalationobj = new List<ServiceEscalationModel>();
            escalationobj = BAL.GetServiceEscalationById(companyID);
            return Request.CreateResponse(HttpStatusCode.OK, escalationobj);
        }

        [HttpGet]
        [Route("DeleteServiceEscalation")]

        public HttpResponseMessage DeleteServiceEscalation(int recordId)
        {
            string result= BAL.DeleteServiceEscalationById(recordId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpGet]
        [Route("role")]
        public IHttpActionResult Role(int CompanyId)
        {
            RoleTreeView responce = new RoleTreeView();
            responce = BAL.role(CompanyId);
            return Ok(responce);
        }
    }


}
