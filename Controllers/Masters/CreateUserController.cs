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
    [RoutePrefix("api/CreateUser")]
    public class CreateUserController : ApiController
    {
        CreateUserBAL BAL = new CreateUserBAL();

        [HttpPost]
        [Route("User")]
        public IHttpActionResult CreatUserfromEmployee(CreateUser request)
        {
            if(request.Id>0)
                return Ok(BAL.UpdateUser(request));
            else
                return Ok(BAL.CreatUser(request));
        }

        [HttpGet]
        [Route("User")]
        public IHttpActionResult GetUserList(int UserId, int CompanyId)
        {
            return Ok(BAL.GetUserList(UserId, CompanyId));
        }

        [HttpGet]
        [Route("UserList")]
        public IHttpActionResult GetUserdetails(int CompanyId)

        {
            return Ok(BAL.GetUserdetails(CompanyId));
        }

        [HttpGet]
        [Route("RoleBYUser")]
        public IHttpActionResult GetRolesByUser(string UserId,int CompanyId)
        {
            return Ok(BAL.GetRolesByUser(UserId,CompanyId));
        }

    }
}
