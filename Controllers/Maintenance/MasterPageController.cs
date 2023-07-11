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
    [RoutePrefix("api/maintanance/Business")]
    public class BusinessController : ApiController
    {

        [HttpGet]
        [Route("BusinessUnitdata")]
        public HttpResponseMessage GetBussinessUnit(int companyId)
        {
            MaintananceBusinessModule GetBusinessData = new MaintananceBusinessModule();
            List<BusinessObject> businessdata = new List<BusinessObject>();
            businessdata=GetBusinessData.GetBussinessUnit(companyId);

            return Request.CreateResponse(HttpStatusCode.OK, businessdata);
        }

        [HttpPost]
        [Route("Businessdata")]
        public HttpResponseMessage InsertBussinessUnit(BussinessParametersObj businessUnit)
        {
            MaintananceBusinessModule InsertBusinessData = new MaintananceBusinessModule();
            string Status;
            if (businessUnit.ActionType == "update")
            {
                //update
                Status = InsertBusinessData.updateBusinessUnit(businessUnit);
               
            }
            else
            {
                //insert
                Status = InsertBusinessData.insertBusinessUnit(businessUnit);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        //[HttpPost]
        //public HttpResponseMessage UpdateBussinessUnitDetails(BussinessParametersObj businessUnitobj)
        //{
        //    MasterModule updateBusinessUnitdetails = new MasterModule();
        //    string Status = updateBusinessUnitdetails.updateBusinessUnit(businessUnitobj);
        //    return Request.CreateResponse(HttpStatusCode.OK, Status);
        //}
        [HttpGet]
        [Route("removeBusinessdata")]

        public HttpResponseMessage DeletebussinessCodeRecord(int RecordId,int CompanyId)
        {
            MaintananceBusinessModule deleteMasterBussinessUnitRecord = new MaintananceBusinessModule();
            string status=deleteMasterBussinessUnitRecord.DeleteBussinessUnit(RecordId,CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }


       

       
      
    }
}
