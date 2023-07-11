using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class UserRights
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool view { get; set; }
        public bool newId { get; set; }
        public bool Edit { get; set; }
        public bool Approve { get; set; }
        public bool Print { get; set; }
        public bool Delete { get; set; }
        public string ScreenId { get; set; }
        public string Username { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }

    }
}