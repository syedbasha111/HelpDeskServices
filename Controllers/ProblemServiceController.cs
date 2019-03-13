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
    public class ProblemServiceController : ApiController
    {
        public  HttpResponseMessage GetProblemMasterService(int companyId)
        {
            List<Problem> problemmodule = new List<Problem>();
            ProblemServiceBAL getproblem = new ProblemServiceBAL();
            problemmodule = getproblem.GetProblemData(companyId);

            return Request.CreateResponse(HttpStatusCode.OK, problemmodule);
        }

        public HttpResponseMessage InsertProblemData(Problem probobject)
        {
            string result="";
            ProblemServiceBAL insertproblemobj = new ProblemServiceBAL();
            if (probobject.ProblemId != 0)
            {
              result = insertproblemobj.UpdateProblemService(probobject);
            }
            else
            {
                result = insertproblemobj.InsertProblemServiceData(probobject);
               
            }
            
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        public HttpResponseMessage DeleteProblemServiceById(int problemId)
        {
            string result;
            ProblemServiceBAL deleteproblemservice = new ProblemServiceBAL();
            result = deleteproblemservice.DeleteProblemServiceById(problemId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
