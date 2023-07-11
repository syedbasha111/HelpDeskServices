using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/UserRoleMapping")]
    public class UserRoleMappingController : ApiController
    {
        UserRoleMappingBAL BAL = new UserRoleMappingBAL();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get(int CompanyId)
        {

            return Ok();
        }

        /// <summary>
        /// create User Mappings Role,Location and Service Based On employeeId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserRole")]
        public IHttpActionResult CreateUserRoleMapping(MVUserRoleMapping request)
        {
            return Ok(BAL.CreateUserRoleMapping(request));
        }
       


    }
}
