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
    public class FacilityMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertFacilityCallMaster(FacilityCallMasterModel FacilityObject)
        {
            string status = "";
            FacilityMasterBAL Facilitybalmethods = new FacilityMasterBAL();
            if (FacilityObject.FacilityCallMasterId != 0)
                status = Facilitybalmethods.UpdateFacilityCallMaster(FacilityObject);
            else
                status = Facilitybalmethods.InsertFacilityCallMaster(FacilityObject);

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetFacilityCallMaster(int companyId)
        {
            FacilityMasterBAL getFacilitybalmethods = new FacilityMasterBAL();
            List<FacilityCallMasterModel> FacilityObj = new List<FacilityCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, FacilityObj = getFacilitybalmethods.GetFacilityCallMaster(companyId));
        }
    }
}
