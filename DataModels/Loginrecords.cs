using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Loginrecords
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public int CompanyId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogOutTime { get; set; }

    }
}