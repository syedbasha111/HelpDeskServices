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
    [RoutePrefix("api/SubService")]
    public class SubServiceController : ApiController
    {
        [HttpGet]
        [Route("GetSubServiceDetails")]

        public HttpResponseMessage GetSubServiceDetails(int companyId)
        {
            MasterSubServiceBLL getseubservice = new MasterSubServiceBLL();
            List<SubServiceObject> subServiceList = new List<SubServiceObject>();
            subServiceList = getseubservice.GetSubServiceUnit(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, subServiceList);
        }
        [HttpPost]
        [Route("InsertSubService")]

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
        [Route("DeleteSubService")]

        public HttpResponseMessage DeleteSubService(int recordId,int CompanyId)
        {
            string status;
            MasterSubServiceBLL getsubservice = new MasterSubServiceBLL();
            status=getsubservice.DeleteSubService(recordId, CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("GetServiceByBusinessUnit")]

        public HttpResponseMessage GetServiceByBusinessUnit(int bunitId ,int companyId)
        {
            MasterSubServiceBLL getsubservice = new MasterSubServiceBLL();
            List<ServiceByBusinessUnit> ServiceUnitList = new List<ServiceByBusinessUnit>();
            ServiceUnitList = getsubservice.GetServiceByBusinessUnit(bunitId, companyId);
            return Request.CreateResponse(HttpStatusCode.OK, ServiceUnitList);
        }

        [HttpGet]
        [Route("dropdown")]
        public HttpResponseMessage GetdetailsbysubserviceId(int companyId, int Id)
        {
            MasterSubServiceBLL responce = new MasterSubServiceBLL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetdetailsbysubserviceId(companyId, Id));
        }

        [HttpGet]
        [Route("SubSurvice")]
        public HttpResponseMessage Getsubservicebyserviceid(int companyId, int Id)
        {
            MasterSubServiceBLL responce = new MasterSubServiceBLL();
            List<SubServiceObject> List = new List<SubServiceObject>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.Getsubservicebyserviceid(companyId, Id));
        }
    }  
}
