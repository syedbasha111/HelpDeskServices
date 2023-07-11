using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/Service")]

    public class ServiceController : ApiController
    {
        // GET: Service
        [HttpGet]
        [Route("GetServiceByCompanyID")]

        public HttpResponseMessage GetServiceByCompanyID(int companyId)
        {
            MasterServiceBLL getservice = new MasterServiceBLL();
            List<ServiceObject> ServiceObjectList = getservice.GetServiceUnit(companyId);
            return  Request.CreateResponse(HttpStatusCode.OK, ServiceObjectList);
        }

        [HttpPost]
        [Route("InsertServiceData")]

        public HttpResponseMessage InsertServiceData(Service serviceObj)
        {
            string status;
            MasterServiceBLL getservice = new MasterServiceBLL();
            if (serviceObj.ServiceID != 0)
            {
                status = getservice.updateService(serviceObj);
            }
            else
            {
                status = getservice.InsertService(serviceObj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [System.Web.Http.HttpGet]
        [Route("RemoveServiceRecordById")]

        public HttpResponseMessage RemoveServiceRecordById(int serviceId,int CompanyId)
        {
            MasterServiceBLL removeService = new MasterServiceBLL();
            string status = removeService.DeleteService(serviceId, CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("Servicename")]
        public HttpResponseMessage GetServicebybussinessID(int companyId,int Id)
        {
            MasterServiceBLL getservice = new MasterServiceBLL();
            List<ServiceObject> ServiceObjectList = getservice.GetServicebybussinessID(companyId,Id);
            return Request.CreateResponse(HttpStatusCode.OK, ServiceObjectList);
        }
    }
}