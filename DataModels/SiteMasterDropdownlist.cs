using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class SiteMasterDropdownlist
    {
        public List<Service> ServiceModelList { get; set; }
        public List<BussinessParametersObj> BusinessModelList { get; set; }


        public List<AreaMasterModel> AreaModelList { get; set; }
        public List<FloorMasterModel> FloorModelList { get; set; }
        public List<BuildingModel> BuildingModelList { get; set; }
        public List<ZoneModel> ZoneModelList { get; set; }
        public List<SiteMasterModel> SiteModelList { get; set; }
        public List<DistrictModel> DistrictModelList { get; set; }
        public List<CityModel> cityModelList { get; set; }
        public List<RegionModel> RegoinModelList { get; set; }
        public List<CountryModel> CountryModelList { get; set; }
    }
}