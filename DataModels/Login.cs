using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Login
    {
        public string UserName { get; set; }    
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string ReportingTo { get; set; }
    }
}