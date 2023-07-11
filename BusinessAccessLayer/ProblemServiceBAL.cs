using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ProblemServiceBAL
    {
        public List<Problem> GetProblemData(int companyId)
        {
            ProblemDAL getProblemservice = new ProblemDAL();
            return getProblemservice.GetProblemServices(companyId);
        }

        public List<Problem> GetProblembysubservice(int companyId,int Id)
        {
            ProblemDAL getProblemservice = new ProblemDAL();
            return getProblemservice.GetProblembysubservice(companyId,Id);
        }
        public string InsertProblemServiceData(Problem problemobj)
        {
            ProblemDAL insertproblemobj = new ProblemDAL();
            return insertproblemobj.InsertProblem(problemobj);
        }

        public string DeleteProblemServiceById(int problemId,int CompanyId)
        {
            ProblemDAL delproblembyid = new ProblemDAL();
            return delproblembyid.DeleteProblemRecordById(problemId, CompanyId);

        }

        public string UpdateProblemService(Problem updateObj)
        {
            ProblemDAL updateproblembyid = new ProblemDAL();
            return updateproblembyid.UpdateProblem(updateObj);

        }
    }
}