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
    public class ServiceEscalationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertServiceEscalation(ServiceEscalationModel obj)
        {
            string result = "";
            ServiceEscalationBAL insertescalations = new ServiceEscalationBAL();
            if (obj.ServiceEscalationId != 0)
            {
                result = insertescalations.UpdateServiceEscalationById(obj);
            }
            else
            {
                result = insertescalations.InsertServiceEscalationById(obj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        [HttpGet]
        public HttpResponseMessage GetServiceEscalation(int companyID)

        {

            ServiceEscalationBAL getserviceescalation = new ServiceEscalationBAL();
            List<ServiceEscalationModel> escalationobj = new List<ServiceEscalationModel>();
            escalationobj = getserviceescalation.GetServiceEscalationById(companyID);
            return Request.CreateResponse(HttpStatusCode.OK, escalationobj);
        }

        [HttpGet]
        public HttpResponseMessage DeleteServiceEscalation(int recordId)
        {

            ServiceEscalationBAL deleteserviceescalation = new ServiceEscalationBAL();

            string result= deleteserviceescalation.DeleteServiceEscalationById(recordId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }


}
