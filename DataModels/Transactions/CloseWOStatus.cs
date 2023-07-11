using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class CloseWOStatus
    {
        public int Id { get; set; }
        public int WoId { get; set; }
        public int ServiceReqId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
        public string Acknowledge { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}