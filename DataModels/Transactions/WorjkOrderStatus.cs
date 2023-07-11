using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class WorkOrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int ComapanyId { get; set; }
    }
}