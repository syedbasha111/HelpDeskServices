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
    public class MasterPageController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetNavigationMenu(string UserType,string CompanyCode)
        {
            MasterModule businesslayermaster = new MasterModule();
            List<menuObject> mastermenu = businesslayermaster.GetSideNavigation(UserType, CompanyCode);
            return Request.CreateResponse(HttpStatusCode.OK, mastermenu);
        }

        [HttpGet]
        public HttpResponseMessage GetBussinessUnit()
        {
            MasterModule GetBusinessData = new MasterModule();
            GetBusinessData.GetBussinessUnit();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage InsertBussinessUnit(BussinessParametersObj businessUnit)
        {
            MasterModule InsertBusinessData = new MasterModule();
            string Status=InsertBusinessData.insertBusinessUnit(businessUnit);
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }
    }
}
