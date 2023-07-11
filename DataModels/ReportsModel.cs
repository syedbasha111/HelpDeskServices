using HelpDeskServices.DataModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class ReportsModel
    {

    }
    public class site_performance
    {
        public string SiteName { get; set; }
        public List<service_performance> Servicesdetails { get; set; }

    }
    public class service_performance
    {
        public string ServiceName { get; set; }
        public CM_Performance CmPerformanceList { get; set; }
    }
    public class pending_Wo_request
    {
        public int locationId { get; set; }
        public int BusinessId { get; set; }
        public int Service { get; set; }
        public int CompanyId { get; set; }
        
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class pending_Wo_responce
    {
        public string WOId { get; set; }
        public string System { get; set; }
        public string SubSystem { get; set; }
        public string Jobdescription { get; set; }
        public string Locatoon { get; set; }
        public string Service { get; set; }
        public string Startdate { get; set; }
        public string Hoursspent { get; set; }
        public string Remarks { get; set; }
        public string woexp { get; set; }
    }

    public class RE_cap_closeWO
    {
        public string Id { get; set; }
        public string woexp { get; set; }
        public string Subsystem { get; set; }
        public string Service { get; set; }
        public string StartWODate { get; set; }
        public string ExecutedDate { get; set; }

    }
    public class Keyperformance
    {
        public string Service { get; set; }
        public string ToatalWO { get; set; }
        public string ComapletedWO { get; set; }
        public string year { get; set; }
        public string month { get; set; }

    }





}