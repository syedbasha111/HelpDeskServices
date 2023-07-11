using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
    }
    public class RoleTreeView
    {
        public List<User> UserList { get; set; }
        public List<RoleModel> RoleList { get; set; }
    }
}