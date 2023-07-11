﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class mvzonemode
    {
        public List<ZoneModel> ZoneModelList { get; set; }
    }
    public class ZoneModel
    {
        public int ID { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string DistrictName { get; set; }
        public string SiteName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public int SiteId { get; set; }
        public int CountryID { get; set; }
        public int DistrictID { get; set; }
        public int cityID { get; set; }
        public int RegionID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public int Companyid { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }

    }
}