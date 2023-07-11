using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class RolemasterBAL
    {
        RoleMasterDAL DAL = new RoleMasterDAL();

        public string CreateRole(RoleModel obj)
        {
            return DAL.CreateRole(obj);
        }

        public string UpdateRole(RoleModel obj)
        {
            return DAL.UpdateRole(obj);
        }

        public List<RoleModel> GetRoleMaster(int companyId)
        {
            return DAL.GetRoleMaster(companyId);
        }

        public string DeleteRole(DeleteObj obj)
        {
            return DAL.DeleteRole(obj);
        }
    }
}