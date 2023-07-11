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
    [RoutePrefix("api/SRAssignMaster")]
    public class SRAssignMasterController : ApiController
    {
        SRAssignMasterBAL BAl = new SRAssignMasterBAL();

        [HttpGet]
        [Route("EmployeebySite")]
        public IHttpActionResult GetEmaployeeBysite(int SiteId,int CompanyId)
        {
            return Ok(BAl.GetEmaployeeBysite(SiteId, CompanyId));
        }

        [HttpPost]
        [Route("SrAssign")]
        public IHttpActionResult SaveSrAssignMaster(SrAssignmaster request)
        {
            return Ok(BAl.SaveSrAssignMaster(request));
        }
        [HttpGet]
        [Route("Employeesbyservice")]
        public IHttpActionResult GetEmployeebyService(int ServiceId, int CompanyId)
        {
            return Ok(BAl.GetEmployeebyService(ServiceId, CompanyId));
        }

        [HttpPost]
        [Route("SiteEmpMapping")]
        public IHttpActionResult createSiteEmployeeMapping(SiteEmpMapping req)
        {
            return Ok(BAl.createSiteEmployeeMapping(req));
        }

    }
}
