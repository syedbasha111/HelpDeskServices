using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class UrgencyMasterBAL
    {
        public string InsertUrgencyCallMaster(UrgencyCallMasterModel obj)
        {
            UrgencyMasterDAL UrgencycallMethod = new UrgencyMasterDAL();
            return UrgencycallMethod.insertUrgencyCallMaster(obj);

        }

        public string UpdateUrgencyCallMaster(UrgencyCallMasterModel obj)
        {
            UrgencyMasterDAL UrgencycallMethod = new UrgencyMasterDAL();
            return UrgencycallMethod.UpdateUrgencyMaster(obj);

        }
        public List<UrgencyCallMasterModel> GetUrgencyCallMaster(int companyId)
        {
            UrgencyMasterDAL UrgencycallMethod = new UrgencyMasterDAL();
            return UrgencycallMethod.GetUrgencyMaster(companyId);

        }

        public string DeleteUrgencyCallMaster(int recordId)
        {

            UrgencyMasterDAL UrgencycallMethod = new UrgencyMasterDAL();
            return UrgencycallMethod.DeleteUrgencyMaster(recordId);
        }
    }
}