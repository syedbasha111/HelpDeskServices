using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HelpDeskServices.Controllers
{
    public class ServiceController : ApiController
    {
        // GET: Service
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetServiceByCompanyID(int companyId)
        {
            MasterServiceBLL getservice = new MasterServiceBLL();
            List<ServiceObject> ServiceObjectList = getservice.GetServiceUnit(companyId);
            return  Request.CreateResponse(HttpStatusCode.OK, ServiceObjectList);
        }

        [System.Web.Http.HttpPost]
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
        public HttpResponseMessage RemoveServiceRecordById(int serviceId)
        {
            MasterServiceBLL removeService = new MasterServiceBLL();
            string status = removeService.DeleteService(serviceId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
    }
}