using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class MaintenanceSLA
    {
        public int Id { get; set; }
        public int Country { get; set; }
        public string CountryName { get; set; }
        public int City { get; set; }
        public string CityName { get; set; }
        public int Location { get; set; }
        public string LocationName { get; set; }
        public string CompanyId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }

    }
}