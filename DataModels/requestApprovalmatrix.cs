using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class requestApprovalmatrix
    {
        public int Id { get; set; }
        public int L1Approval { get; set; }
        public string L1Approvalname { get; set; }
        public int L2Approval { get; set; }
        public string L2Approvalname { get; set; }
        public int WoExcecutionL1Approval { get; set; }
        public string WoExcecutionL1Approvalname { get; set; }
        public int WoExcecutionL2Approval { get; set; }
        public string WoExcecutionL2Approvalname { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}