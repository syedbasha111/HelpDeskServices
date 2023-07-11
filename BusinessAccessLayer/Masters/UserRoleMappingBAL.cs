using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class UserRoleMappingBAL
    {
        UserRoleMappingDAL DAL = new UserRoleMappingDAL();


        public string CreateUserRoleMapping(MVUserRoleMapping obj)
        {
            return DAL.CreateUserRole(obj);
        }

       
    }
}