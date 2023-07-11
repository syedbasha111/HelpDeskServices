using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Reports
{
    public class CM_Performance
    {
        public decimal total { get; set; }
        public decimal ReqSubmited { get; set; }
        public decimal CreateWO { get; set; }
        public decimal CloseWo { get; set; }
        public decimal CompletePercentage { get; set; }
        public string Service { get; set; }
        public string Location { get; set; }
    }
}