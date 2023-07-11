using HelpDeskServices.BusinessAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.AssetMaster
{
    [RoutePrefix("api/Group")]
    public class GroupMasterController : ApiController
    {
        GroupMasterBAL BAL = new GroupMasterBAL();
        [HttpGet]
        [Route("GroupMasterName")]
        public HttpResponseMessage GetGroupMasterName(int CompanyId)
        {
            List<GroupMasterModel> List = new List<GroupMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetGroupMasterName(CompanyId));
        }
        [HttpGet]
        [Route("GroupMasterCode")]
        public HttpResponseMessage GetGroupMasterCode(int Id,int CompanyId)
        {
            List<GroupMasterModel> List = new List<GroupMasterModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetGroupMasterCode(Id,CompanyId));
        }
    }
}
