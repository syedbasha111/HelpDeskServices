using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class RegionModel
    {
        public int RegionId { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string DistrictName { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public int DistrictId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

    }
}