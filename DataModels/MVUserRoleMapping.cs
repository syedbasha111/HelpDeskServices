using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class MVUserRoleMapping
    {
        public List<NewUser> EmployeeList { get; set; }
        public List<Role> RoleList { get; set; }
        public List<Location> LocationList { get; set; }
        public List<ServiceModel> ServiceList { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
    }
    public class Role
    {
        public string RoleId { get; set; }
        
    }
    public class Location
    {
        public string Id { get; set; }

    }
    public class ServiceModel
    {
        public string ServiceID { get; set; }

    }



}