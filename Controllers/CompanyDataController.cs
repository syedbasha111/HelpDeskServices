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
    public class CompanyDataController : ApiController
    {
        public HttpResponseMessage GetcompaniesById(int companyId)
        {
            List<CompaniesModel> cmpList = new List<CompaniesModel>();
            CompanyDetailsBAL cmpBalMethod = new CompanyDetailsBAL();
            cmpList = cmpBalMethod.GetCompanyByID(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, cmpList);
        }


    }
}
