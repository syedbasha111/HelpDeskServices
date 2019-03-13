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
    public class RepeatCallMasterController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage InsertRepeatCallMaster(RepeatCallMasterModel obj)
        {
            string result = "";
            RepeatCallMasterBAL repeatbalmethods = new RepeatCallMasterBAL();
            if (obj.RepeatCallMasterId != 0)
            {
                result = repeatbalmethods.UpdateRepeatCallMaster(obj);
            }
            else
            {
                result = repeatbalmethods.InsertRepeatCallMaster(obj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]

        public HttpResponseMessage GetRepeatCallMaster(int companyId)
        {
            List<RepeatCallMasterModel> repeatModelList = new List<RepeatCallMasterModel>();
            RepeatCallMasterBAL repeatbalmethods = new RepeatCallMasterBAL();
            repeatModelList = repeatbalmethods.GetRepeatCallMaster(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, repeatModelList);
        }
       
    }
    
}
