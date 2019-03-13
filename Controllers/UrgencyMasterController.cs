﻿using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    public class UrgencyMasterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage InsertUrgencyCallMaster(UrgencyCallMasterModel UrgencyObject)
        {
            string status = "";
            UrgencyMasterBAL Urgencybalmethods = new UrgencyMasterBAL();
            if (UrgencyObject.UrgencyCallMasterId != 0)
                status = Urgencybalmethods.UpdateUrgencyCallMaster(UrgencyObject);
            else
                status = Urgencybalmethods.InsertUrgencyCallMaster(UrgencyObject);

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        public HttpResponseMessage GetUrgencyCallMaster(int companyId)
        {
            UrgencyMasterBAL getUrgencybalmethods = new UrgencyMasterBAL();
            List<UrgencyCallMasterModel> UrgencyObj = new List<UrgencyCallMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, UrgencyObj = getUrgencybalmethods.GetUrgencyCallMaster(companyId));
        }
    }
}
