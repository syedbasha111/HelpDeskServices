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
    public class FeedbackMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertFeedbackCallMaster(FeedbackCallMasterModel FeedbackObject)
        {
            string status = "";
            FeedbackMasterBAL Feedbackbalmethods = new FeedbackMasterBAL();
            if (FeedbackObject.FeedbackCallMasterId != 0)
                status = Feedbackbalmethods.UpdateFeedbackCallMaster(FeedbackObject);
            else
                status = Feedbackbalmethods.InsertFeedbackCallMaster(FeedbackObject);

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetFeedbackCallMaster(int companyId)
        {
            FeedbackMasterBAL getFeedbackbalmethods = new FeedbackMasterBAL();
            List<FeedbackCallMasterModel> FeedbackObj = new List<FeedbackCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, FeedbackObj = getFeedbackbalmethods.GetFeedbackCallMaster(companyId));
        }
    }
}
