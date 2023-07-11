using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class AssignRequest
    {
        public int Id { get; set; }
        public string Assign { get; set; }
        public int CompanyId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}