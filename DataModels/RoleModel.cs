using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public List<User> UserList { get; set; }

    }
}