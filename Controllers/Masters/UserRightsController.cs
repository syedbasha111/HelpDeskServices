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
    [RoutePrefix("api/UserRight")]
    public class UserRightsController : ApiController
    {
        UserRightsBAL BAL = new UserRightsBAL();

        [HttpPost]
        [Route("UserRights")]
        public IHttpActionResult CreatUserRights(List<UserRights> request)
        {
            return Ok(BAL.CreatUserRights(request));
        }
        
        [HttpPost]
        [Route("UserRightsVerification")]
        public IHttpActionResult GetScreenUserRights(UserRights req)
        {
            return Ok(BAL.GetScreenUserRights(req));
        }

        [HttpGet]
        [Route("ScreenId")]
        public IHttpActionResult GetScreenIdbyUrl(string Url)
        {
            return Ok(BAL.GetUserdetails(Url));
        }
    }
}
