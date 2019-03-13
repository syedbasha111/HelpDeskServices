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
    public class HolidayMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertHolidayCallMaster(HolidayCallMasterModel HolidayObject)
        {
            string status = "";
            HolidayMasterBAL Holidaybalmethods = new HolidayMasterBAL();
            if (HolidayObject.HolidayCallMasterId != 0)
                status = Holidaybalmethods.UpdateHolidayCallMaster(HolidayObject);
            else
                status = Holidaybalmethods.InsertHolidayCallMaster(HolidayObject);

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetHolidayCallMaster(int companyId)
        {
            HolidayMasterBAL getHolidaybalmethods = new HolidayMasterBAL();
            List<HolidayCallMasterModel> HolidayObj = new List<HolidayCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, HolidayObj = getHolidaybalmethods.GetHolidayCallMaster(companyId));
        }
    }
}
