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
    public class SubServiceController : ApiController
    {
        public HttpResponseMessage GetSubServiceDetails(int companyId)
        {
            MasterSubServiceBLL getseubservice = new MasterSubServiceBLL();
            List<SubServiceObject> subServiceList = new List<SubServiceObject>();
            subServiceList = getseubservice.GetSubServiceUnit(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, subServiceList);
        }
        [HttpPost]
        public HttpResponseMessage InsertSubService(SubService SubServiceObj)
        {
            string status;
            MasterSubServiceBLL getsubservice = new MasterSubServiceBLL();
            if (SubServiceObj.SubServiceID != 0)
            {
                status = getsubservice.updateSubService(SubServiceObj);
            }
            else
            {
                status = getsubservice.InsertSubService(SubServiceObj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        public HttpResponseMessage DeleteSubService(int recordId)
        {
            string status;
            MasterSubServiceBLL getsubservice = new MasterSubServiceBLL();
            status=getsubservice.DeleteSubService(recordId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
    }  
}
