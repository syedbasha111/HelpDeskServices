using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class CompanyAdressDetails
    {
        public int CompanyMasterDetailId { get; set; }
        public int CompanyId { get; set; }
        public string Systemcode { get; set; }
        public string CmpyCode { get; set; }
        public int OfficeTypeId { get; set; }
        public string OfficeType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string POBox { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Tele1 { get; set; }
        public string Tele2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Primary1 { get; set; }
        public string Status { get; set; }
        public string CityId { get; set; }
        public string CountryId { get; set; }


    }
}