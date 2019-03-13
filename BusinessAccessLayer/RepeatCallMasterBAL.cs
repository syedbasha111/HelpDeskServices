using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class RepeatCallMasterBAL
    {
        public string InsertRepeatCallMaster(RepeatCallMasterModel obj)
        {
            RepeatCallMasterDAL repeatcallMethod = new RepeatCallMasterDAL();
            return repeatcallMethod.insertRepeatCallMaster(obj);

        }

        public string UpdateRepeatCallMaster(RepeatCallMasterModel obj)
        {
            RepeatCallMasterDAL repeatcallMethod = new RepeatCallMasterDAL();
            return repeatcallMethod.UpdateRepeatCallMaster(obj);

        }
        public List<RepeatCallMasterModel> GetRepeatCallMaster(int companyId)
        {
            RepeatCallMasterDAL repeatcallMethod = new RepeatCallMasterDAL();
            return repeatcallMethod.GetRepeatCallMaster(companyId);

        }

        public string DeleteRepeatCallMaster(int recordId)
        {

            RepeatCallMasterDAL repeatcallMethod = new RepeatCallMasterDAL();
            return repeatcallMethod.DeleteRepeatCallMaster(recordId);
        }
    }
}