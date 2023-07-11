using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Reports
{
    public class CM_status_details
    {
        public int RequestID {get;set;}
        public int WOID {get;set;}
        public string Requester { get;set;}
        public string ReceivedBy {get;set;}
        public DateTime ReceivedDate {get;set;}
        public string ReportingTime {get;set;}
        public string Site { get;set;}
        public string Zone { get;set;}
        public string Building { get;set;}
        public string Floor { get;set;}
        public string Area { get;set;}
        public string Room { get;set;}
        public string BusinessUnit {get;set;}
        public string Service { get;set;}
        public string SubService {get;set;}
        public string Problem { get;set;}
        public string ProblemDesc {get;set;}
        public string System { get;set; }
        public string SubSystem {get;set; }
        public string AssignedTo {get;set; }
        public string Status { get;set; }
        public string workorderexp { get;set; }
        public string reqorderexp { get;set; }

        public string RequestSubmitted {get;set; }
        public string RequestModified {get;set; }
        public string ProceedforWOCreation { get;set; }
        public string RequestforServiceReassign { get;set; }
        public string WOCreated {get;set; }
        public string WOOnHold { get;set; }
        public string WOInProgress { get;set; }
        public string WOCompleted {get;set; }
        public string WOClosed {get;set; }
        public string WORejected {get;set; }
    }
}