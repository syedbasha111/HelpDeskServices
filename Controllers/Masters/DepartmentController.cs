using HelpDeskServices.BusinessAccessLayer.Masters;
using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Masters
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        DepartmentBAL BAL = new DepartmentBAL();
        [HttpPost]
        [Route("Department")] //Matches POST api/products
        public HttpResponseMessage SaveDepartment(DepartmentModel request)
        {
            HD_BaseModel status = new HD_BaseModel();


            if (request.Id != 0)
            {
                status = BAL.UpdateDepartment(request);
            }
            else
            {
                status = BAL.SaveDepartment(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("Department")]
        public HttpResponseMessage GetDepartment(int companyId)
        {
            List<DepartmentModel> List = new List<DepartmentModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetDepartment(companyId));
        }

        [HttpPost]
        [Route("DeleteDepartment")]
        public HttpResponseMessage DeleteDepartment(DeleteObj obj)
        {
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = BAL.deletedepartment(obj));
        }
    }
}
