using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class CompanyMaster
    {
        public int CompanyId { get; set; }
        public string CmpyCode { get; set; }
        public string Name { get; set; }
        public string ParentCmpyCode { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string BaseCurrencyCode { get; set; }
        public string OfficeType { get; set; }
        public string CurrencyName { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneValue { get; set; }
        public string Language { get; set; }
        public string Logo { get; set; }
        public string CompanyRegistrationDocument { get; set; }
        public string Active { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}