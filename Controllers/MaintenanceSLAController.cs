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
    [RoutePrefix("api/MaintenanceSLA")]
    public class MaintenanceSLAController : ApiController
    {

        MaintenanceSLABAL BAL = new MaintenanceSLABAL();

        [HttpPost]
        [Route("MaintenanceSLA")] //Matches POST api/products
        public IHttpActionResult SaveMaintenanceSLA(MaintenanceSLA request)
        {
            if (request.Id == 0)
            {
                return Ok(BAL.SaveMaintenanceSLA(request));
            }
            else { return Ok(BAL.UpdateMaintenanceSLA(request)); }
        }

        [HttpGet]
        [Route("MaintenanceSLAList")]
        public IHttpActionResult getMaintenanceSLA(int CompanyId)
        {
            return Ok(BAL.getMaintenanceSLA(CompanyId));
        }
    }
}
