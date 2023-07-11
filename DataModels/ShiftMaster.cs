using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class ShiftMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Country { get; set; }
        public int Location { get; set; }
        public string Status { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string Weekoff { get; set; }

        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}