using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class LoginBAL
    {
        LoginDAL DAL = new LoginDAL();
        public List<Login> Login(Login request)
        {
            return DAL.Login(request);
        }

        public string PasswordRecovery(User request)
        {
            return DAL.PasswordRecovery(request);
        }
        public string saveLogindetails(Loginrecords request)
        {
            return DAL.saveLogindetails(request);
        }
        public string UpdateLogindetails(Loginrecords request)
        {
            return DAL.UpdateLogindetails(request);
        }

        public List<User> GetListOfEmployees(int CompanyId)
        {
            return DAL.GetListOfEmployees(CompanyId);
        }

        public List<Loginrecords> GetLoginUserslist(Loginrecords req)
        {
            return DAL.GetLoginUserslist(req);
        }

        public Login Getuserdetails(int CompanyId, int UserId)
        {
            return DAL.Getuserdetails(CompanyId, UserId);
        }
    }
}