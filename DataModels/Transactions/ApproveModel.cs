using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class ApproveModel
    {
        public int? Site { get; set; }
        public int? Zone { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
        public string Location { get; set; }
        public string ZoneName{ get; set; }
        public string IsStatus{ get; set; }
        public string Remarks { get; set; }
        public int? ServiceReqId { get; set; }
        public int? WOId { get; set; }
        public string WOExp { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}