using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/Role")]
    public class RoleMasterController : ApiController
    {
        RolemasterBAL BAL = new RolemasterBAL();

        [HttpPost]
        [Route("Role")]
        public IHttpActionResult CreateRole(RoleModel request)
        {
            if (request.RoleId > 0)
            {
                return Ok(BAL.UpdateRole(request));
            }
            else {
                return Ok(BAL.CreateRole(request));
            }
        }

        [HttpGet]
        [Route("Role")]
        public IHttpActionResult GetRoleMaster(int companyId)
        {
            return Ok(BAL.GetRoleMaster(companyId));
        }

        [HttpPost]
        [Route("DeleteRole")]
        public IHttpActionResult DeleteRole(DeleteObj obj)
        {
            return Ok(BAL.DeleteRole(obj));
        }

    }
}
