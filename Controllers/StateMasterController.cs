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
    [RoutePrefix("api/stateController")]
    public class StateMasterController : ApiController
    {
        [HttpPost]
        [Route("insertState")] //Matches POST api/products
        public HttpResponseMessage InsertState(StateModel Statedata)
        {
            string status = "";
            StateMasterBAL getState = new StateMasterBAL();
            if (Statedata.StateId != 0)
            {
                status = getState.updateStateMaster(Statedata);
            }
            else
            {
                status = getState.InsertStateMaster(Statedata);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("getState")]
        public HttpResponseMessage GetStateMaster(int companyId)
        {
            StateMasterBAL getState = new StateMasterBAL();
            List<StateModel> StateList = new List<StateModel>();
            return Request.CreateResponse(HttpStatusCode.OK, StateList = getState.GetStateMaster(companyId));
        }

        [HttpGet]
        [Route("getCountriesForStates")]
        public HttpResponseMessage GetCountriesMaster(int companyId)
        {
            StateMasterBAL getState = new StateMasterBAL();
            List<CountryModel> countryList = new List<CountryModel>();
            return Request.CreateResponse(HttpStatusCode.OK, countryList = getState.GetCountries(companyId));
        }

        [HttpPost]
        [Route("deletecountriesForStates")]
        public HttpResponseMessage DeleteCountriesMaster(DeleteObj obj)
        {
            StateMasterBAL getState = new StateMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = getState.deleteStateMaster(obj));
        }
    }
}
