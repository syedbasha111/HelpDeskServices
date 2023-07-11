using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class UserLocationMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EmpId { get; set; }
        public int LocationId { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int Status { get; set; }

    }
}