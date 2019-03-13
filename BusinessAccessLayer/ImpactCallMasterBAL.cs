using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ImpactCallMasterBAL
    {
        public string InsertImpactCallMaster(ImpactCallMasterModel obj)
        {
            ImpactMasterDAL impactcallMethod = new ImpactMasterDAL();
            return impactcallMethod.insertImpactCallMaster(obj);

        }

        public string UpdateImpactCallMaster(ImpactCallMasterModel obj)
        {
            ImpactMasterDAL impactcallMethod = new ImpactMasterDAL();
            return impactcallMethod.UpdateImpactMaster(obj);

        }
        public List<ImpactCallMasterModel> GetImpactCallMaster(int companyId)
        {
            ImpactMasterDAL impactcallMethod = new ImpactMasterDAL();
            return impactcallMethod.GetImpactMaster(companyId);

        }

        public string DeleteImpactCallMaster(int recordId)
        {

            ImpactMasterDAL impactcallMethod = new ImpactMasterDAL();
            return impactcallMethod.DeleteImpactMaster(recordId);
        }
    }
}