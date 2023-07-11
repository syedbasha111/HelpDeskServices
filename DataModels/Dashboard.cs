using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Dashboard
    {

    }
    public class HelpdeskManagement
    {
        public int RequestsRaised { get; set; }
        public int ProceedWO { get; set; }
        public int SRAssign { get; set; }
        public int WOCreated { get; set; }
        public int WOInProgress { get; set; }
        public int WO_OnHold { get; set; }
        public int WO_Completed { get; set; }
        public int WO_Closed { get; set; }
        public int RequestCancelled { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string ServiceName{ get; set; }

    }

    public class ListOfhelpedeskmanagement
    {
        public int Site { get; set; }
        public int service { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public List<HelpdeskManagement> StatusDetails { get; set; }


    }
    public class assetcounts
    {
        public List<assetlocation> LocationCount { get; set; }
        public List<assetservice> Serviceount { get; set; }

    }

    public class assetlocation
    {
        public string name { get; set; }
        public string y { get; set; }
    }

    public class assetservice
    {
        public string name { get; set; }
        public string y { get; set; }
    }
}