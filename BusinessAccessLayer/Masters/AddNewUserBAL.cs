using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class AddNewUserBAL
    {
        AddNewUserDAL DAL = new AddNewUserDAL();


        public List<Employeetype> GetEmaployeeType(int companyId)
        {
            return DAL.GetEmaployeeType(companyId);
        }
        public List<NewUser> GetEmployeList(int companyId)
        {
            return DAL.GetEmployeList(companyId);
        }

        public string CreatNewUser(NewUser obj)
        {
            return DAL.CreatNewUser(obj);
        }
        public string UpdateNewUser(NewUser obj)
        {
            return DAL.UpdateNewUser(obj);
        }

        #region bindingGrid Data
        public List<Grade> Getgrde(int companyId)
        {
            return DAL.Getgrde(companyId);
        }
        public List<ReportingManager> GetReportingmanger(int companyId)
        {
            return DAL.GetReportingmanger(companyId);
        }
        public List<Vertical> GetVertical(int companyId)
        {
            return DAL.GetVertical(companyId);
        }
        public List<CostCenter> Getcostcenter(int companyId)
        {
            return DAL.Getcostcenter(companyId);
        }
        public List<Skills> GetSkills(int companyId)
        {
            return DAL.GetSkills(companyId);
        }
        #endregion
    }
}