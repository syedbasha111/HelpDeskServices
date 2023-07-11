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
    [RoutePrefix("api/AddNewUser")]
    public class AddNewUserController : ApiController
    {
        AddNewUserBAL BAL = new AddNewUserBAL();

        [HttpGet]

        [Route("EmployeeType")]
        public IHttpActionResult GetEmaployeeType(int companyId)
        {
            return Ok(BAL.GetEmaployeeType(companyId));
        }

        [HttpGet]
        [Route("EmpList")]
        public IHttpActionResult GetEmployeList(int CompanyId)
        {

            return Ok(BAL.GetEmployeList(CompanyId));
        }

        [HttpPost]
        [Route("Employee")]
        public IHttpActionResult CreatNewEmployee(NewUser request)
        {
            if (request.Id > 0)
            {
                return Ok(BAL.UpdateNewUser(request));
            }
            else
            {
                return Ok(BAL.CreatNewUser(request));
            }
        }

        #region gettingdropdownvalues
        [HttpGet]
        [Route("grade")]
        public IHttpActionResult Getgrde(int companyId)
        {
            return Ok(BAL.Getgrde(companyId));
        }
        [HttpGet]
        [Route("Reportingmanger")]
        public IHttpActionResult GetReportingmanger(int companyId)
        {
            return Ok(BAL.GetReportingmanger(companyId));
        }
        [HttpGet]
        [Route("vertical")]
        public IHttpActionResult GetVertical(int companyId)
        {
            return Ok(BAL.GetVertical(companyId));
        }
        [HttpGet]
        [Route("costcenter")]
        public IHttpActionResult Getcostcenter(int companyId)
        {
            return Ok(BAL.Getcostcenter(companyId));
        }
        [HttpGet]
        [Route("Skills")]
        public IHttpActionResult GetSkills(int companyId)
        {
            return Ok(BAL.GetSkills(companyId));
        }
        #endregion
    }
}
