using System.Collections.Generic;
namespace HelpDeskServices.DataModels
{
    public class MVCompanyData
    {
        public List<CompanyMaster> CompanyList{ get; set; }
        public List<CurrencyCode> CurrencycodeList { get; set; }
        public List<TimeZoneMaster> TimeZoneList { get; set; }
    }
}