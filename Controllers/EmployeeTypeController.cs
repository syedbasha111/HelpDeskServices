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
    [RoutePrefix("api/Employeetype")]
    public class EmployeeTypeController : ApiController
    {
        EmployeetypeBAL BAL = new EmployeetypeBAL();


        [HttpPost]
        [Route("Employeetype")]
        public IHttpActionResult CreatEmployeetype(Employeetype request)
        {
            if (request.Id > 0)
            {
                return Ok(BAL.UpdateEmployeetype(request));
            }
            else
            {
                return Ok(BAL.CreatEmployeetype(request));
             }
        }

        [HttpPost]
        [Route("DeleteEmployeeType")]
        public IHttpActionResult DeleteEmployeeType(DeleteObj obj)
        {
            return Ok(BAL.DeleteEmployeeType(obj));
        }
    }
}
