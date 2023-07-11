using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class FacilityMasterBAL
    {
        public string InsertFacilityCallMaster(FacilityCallMasterModel obj)
        {
            FacilityMasterDAL FacilitycallMethod = new FacilityMasterDAL();
            return FacilitycallMethod.insertFacilityCallMaster(obj);

        }

        public string UpdateFacilityCallMaster(FacilityCallMasterModel obj)
        {
            FacilityMasterDAL FacilitycallMethod = new FacilityMasterDAL();
            return FacilitycallMethod.UpdateFacilityMaster(obj);

        }
        public List<FacilityCallMasterModel> GetFacilityCallMaster(int companyId)
        {
            FacilityMasterDAL FacilitycallMethod = new FacilityMasterDAL();
            return FacilitycallMethod.GetFacilityMaster(companyId);

        }

        public string DeleteFacilityCallMaster(int recordId,int ComapanyId)
        {

            FacilityMasterDAL FacilitycallMethod = new FacilityMasterDAL();
            return FacilitycallMethod.DeleteFacilityMaster(recordId, ComapanyId);
        }
    }
}