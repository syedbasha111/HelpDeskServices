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
    [RoutePrefix("api/Holiday")]
    public class HolidayMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertHolidayCallMaster(List<HolidayCallMasterModel> HolidayObject)
        {
            string status = "";
            HolidayMasterBAL Holidaybalmethods = new HolidayMasterBAL();
            if (HolidayObject[0].HolidayCallMasterId != 0)
            {
                status = Holidaybalmethods.UpdateHolidayCallMaster(HolidayObject);
            }
            else
            {
                List<HD_BaseModel> responce = new List<HD_BaseModel>();
                responce = Holidaybalmethods.InsertHolidayCallMaster(HolidayObject);
                return Request.CreateResponse(HttpStatusCode.OK, responce);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetHolidayCallMaster(int companyId)
        {
            HolidayMasterBAL getHolidaybalmethods = new HolidayMasterBAL();
            List<HolidayCallMasterModel> HolidayObj = new List<HolidayCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, HolidayObj = getHolidaybalmethods.GetHolidayCallMaster(companyId));
        }

        [HttpDelete]
        [Route("deleteHoliday")]
        public HttpResponseMessage DeleteHoliday(int recordId, int CompanyId)
        {
            string status;
            HolidayMasterBAL BAL = new HolidayMasterBAL();
            status = BAL.DeleteHolidayCallMaster(recordId, CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
    }
}
