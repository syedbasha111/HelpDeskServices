using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class CurrencyCode
    {
        public int CurrencyId { get; set; }
        public string Systemcode { get; set; }
        public string CmpyCode { get; set; }
        public string Currencycode { get; set; }
        public string Currencyname { get; set; }
        public string SubCurrency { get; set; }
        public string Active { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}