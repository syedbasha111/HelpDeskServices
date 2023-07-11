using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class EmployeetypeBAL
    {
        EmployeetypeDAL DAL = new EmployeetypeDAL();

        public string CreatEmployeetype(Employeetype obj)
        {
            return DAL.CreatEmployeetype(obj);
        }
        public string UpdateEmployeetype(Employeetype obj)
        {
            return DAL.UpdateEmployeetype(obj);
        }

        public string DeleteEmployeeType(DeleteObj obj)
        {
            return DAL.DeleteEmployeetype(obj);
        }
    }
}