using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class CreateUserBAL
    {
        CreateUserDAL DAL = new CreateUserDAL();

        public string CreatUser(CreateUser obj)
        {
            return DAL.CreatUser(obj);
        }

        public string UpdateUser(CreateUser obj)
        {
            return DAL.UpdateUser(obj);
        }

        public List<CreateUser> GetUserList(int UserId, int CompanyId)
        {
            return DAL.GetUserList(UserId, CompanyId);
        }

        public List<CreateUser> GetUserdetails(int CompanyId)
        {
            return DAL.GetUserdetails(CompanyId);
        }

        public List<RoleModel> GetRolesByUser(string UserId, int CompanyId)
        {
            return DAL.GetRolesByUser(UserId,CompanyId);
        }


    }
}