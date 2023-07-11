using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Employeetype
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string EmployeeType { get; set; }
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime MOdifiedOn { get; set; }

    }
}