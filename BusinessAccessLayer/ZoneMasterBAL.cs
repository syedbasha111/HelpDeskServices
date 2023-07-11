using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ZoneMasterBAL
    {
        /// <summary>
        /// Save ZOne master
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string CreateZoneMaster(ZoneModel obj)
        {
            ZoneMasterDAL DAL = new ZoneMasterDAL();
            return DAL.CreateZoneMaster(obj);

        }

        public string UpdateZoneMaster(ZoneModel obj)
        {
            ZoneMasterDAL DAL = new ZoneMasterDAL();
            return DAL.UpdateZoneMaster(obj);

        }
        public List<ZoneModel> GetZoneMaster(int companyId)
        {
            ZoneMasterDAL DistrictcallMethod = new ZoneMasterDAL();
            return DistrictcallMethod.GetZoneMaster(companyId);

        }
        public SiteMasterDropdownlist GetDetailsbySiteid(int companyId,int Id)
        {
            ZoneMasterDAL DistrictcallMethod = new ZoneMasterDAL();
            return DistrictcallMethod.GetDetailsbySiteid(companyId,Id);

        }

        public string DeleteSiteMaster( int Id)
        {
            ZoneMasterDAL DistrictcallMethod = new ZoneMasterDAL();
            return DistrictcallMethod.DeleteSiteMaster(Id);

        }

        public List<ZoneModel> GetZoneNameBySiteid(int companyId,int Id)
        {
            ZoneMasterDAL DAL = new ZoneMasterDAL();
            return DAL.GetZoneNameBySiteid(companyId,Id);

        }
    }
}