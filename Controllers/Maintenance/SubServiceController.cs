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
    [RoutePrefix("api/Miantanance/SubService")]
    public class MaintanaceSubServiceController : ApiController
    {
        [HttpGet]
        [Route("GetSubServiceDetails")]

        public HttpResponseMessage GetSubServiceDetails(int companyId)
         {
            MaintananceSubServiceBLL getseubservice = new MaintananceSubServiceBLL();
            List<SubServiceObject> subServiceList = new List<SubServiceObject>();
            subServiceList = getseubservice.GetSubServiceUnit(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, subServiceList);
        }
        [HttpPost]
        [Route("InsertSubService")]

        public HttpResponseMessage InsertSubService(SubService SubServiceObj)
        {
            string status;
            MaintananceSubServiceBLL getsubservice = new MaintananceSubServiceBLL();
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
            MaintananceSubServiceBLL getsubservice = new MaintananceSubServiceBLL();
            status=getsubservice.DeleteSubService(recordId, CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("GetServiceByBusinessUnit")]

        public HttpResponseMessage GetServiceByBusinessUnit(int bunitId ,int companyId)
        {
            MaintananceSubServiceBLL getsubservice = new MaintananceSubServiceBLL();
            List<ServiceByBusinessUnit> ServiceUnitList = new List<ServiceByBusinessUnit>();
            ServiceUnitList = getsubservice.GetServiceByBusinessUnit(bunitId, companyId);
            return Request.CreateResponse(HttpStatusCode.OK, ServiceUnitList);
        }

        [HttpGet]
        [Route("dropdown")]
        public HttpResponseMessage GetdetailsbysubserviceId(int companyId, int Id)
        {
            MaintananceSubServiceBLL responce = new MaintananceSubServiceBLL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetdetailsbysubserviceId(companyId, Id));
        }

        [HttpGet]
        [Route("SubSurvice")]
        public HttpResponseMessage Getsubservicebyserviceid(int companyId, int Id)
        {
            MaintananceSubServiceBLL responce = new MaintananceSubServiceBLL();
            List<SubServiceObject> List = new List<SubServiceObject>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.Getsubservicebyserviceid(companyId, Id));
        }
    }  
}
