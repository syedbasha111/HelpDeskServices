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
    [RoutePrefix("api/countryController")]
    public class CountryMasterController : ApiController
    {
        [HttpPost]
        [Route("insertcountry")] //Matches POST api/products
        public HttpResponseMessage Insertcountry(CountryModel countrydata)
        {
            string status ="";
            CountryMasterBAL getcountry = new CountryMasterBAL();
            if (countrydata.CountryId != 0)
            {
                status = getcountry.updateCountryMaster(countrydata);
            }
            else
            {
                status = getcountry.InsertCountryMaster(countrydata);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("getCountires")]
        public HttpResponseMessage GetCountryMaster(int companyId)
        {
            CountryMasterBAL getcountry = new CountryMasterBAL();
            List<CountryModel> CountryList = new List<CountryModel>();
            return Request.CreateResponse(HttpStatusCode.OK, CountryList = getcountry.GetCountryMaster(companyId));
        }
        [HttpPost]
        [Route("deleteCountry")]
        public HttpResponseMessage DeleteCountryMaster(DeleteObj obj)
        {
            CountryMasterBAL getcountry = new CountryMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = getcountry.DeleteCountryMaster(obj));
        }
    }
}
