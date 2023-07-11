using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class WoResource
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}