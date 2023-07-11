using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class CurrencyMaster
    {
        public int ForexRateId { get; set; }
        public string Systemcode { get; set; }
        public string Cmpycode { get; set; }
        public int CurCode { get; set; }
        public string CurName { get; set; }
        public decimal CurRate { get; set; }
        public string EffectDate { get; set; }
        public bool Active { get; set; }
        public bool Status { get; set; }
        public int CurrencyId { get; set; }

    }
}