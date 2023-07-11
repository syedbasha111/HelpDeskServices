using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class DepartmentBAL
    {
        DepartmentDAL DAL = new DepartmentDAL();

        public HD_BaseModel SaveDepartment(DepartmentModel request)
        {
            return DAL.SaveDepartment(request);
        }

        public HD_BaseModel UpdateDepartment(DepartmentModel request)
        {
            return DAL.UpdateDepartment(request);
        }

        public List<DepartmentModel> GetDepartment(int companyId)
        {
            return DAL.GetDepartment(companyId);

        }
        public string deletedepartment(DeleteObj request)
        {
            return DAL.deletedepartment(request);
        }
    }
}