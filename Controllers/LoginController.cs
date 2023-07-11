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
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        LoginBAL BAL = new LoginBAL();

        [HttpPost]
        [Route("Login")] //Matches POST api/products
        public HttpResponseMessage Login(Login request)
        {
            //List<Login> Responce = new List<Login>();
            return Request.CreateResponse(HttpStatusCode.OK,BAL.Login(request));
        }

        [HttpPost]
        [Route("PasswordRecovery")] //Matches POST api/products
        public HttpResponseMessage PasswordRecovery(User request)
        {
            string Responce;
            return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.PasswordRecovery(request));
        }

        [HttpPost]
        [Route("Logindetails")] //Matches POST api/products
        public IHttpActionResult saveLoginDetails(Loginrecords request)
        {
            if (request.Id == 0){ return Ok(BAL.saveLogindetails(request)); }
            else { return Ok(BAL.UpdateLogindetails(request)); }
            
        }

        [HttpGet]
        [Route("GetEmployess")]
        public IHttpActionResult GetListOfEmployees(int CompanyId)
        {
            return Ok(BAL.GetListOfEmployees(CompanyId));
        }

        [HttpPost]
        [Route("GetLoginUsers")]
        public IHttpActionResult GetLoginUserslist(Loginrecords req)
        {
            return Ok(BAL.GetLoginUserslist(req));
        }

        [HttpGet]
        [Route("loginfromHeader")]
        public IHttpActionResult Getuserdetails(int CompanyId,int UserId)
        {
            return Ok(BAL.Getuserdetails(CompanyId, UserId));
        }
    }
}
