using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class FeedbackMasterBAL
    {
        public string InsertFeedbackCallMaster(FeedbackCallMasterModel obj)
        {
            FeedbackMasterDAL FeedbackcallMethod = new FeedbackMasterDAL();
            return FeedbackcallMethod.insertFeedbackCallMaster(obj);

        }

        public string UpdateFeedbackCallMaster(FeedbackCallMasterModel obj)
        {
            FeedbackMasterDAL FeedbackcallMethod = new FeedbackMasterDAL();
            return FeedbackcallMethod.UpdateFeedbackMaster(obj);

        }
        public List<FeedbackCallMasterModel> GetFeedbackCallMaster(int companyId)
        {
            FeedbackMasterDAL FeedbackcallMethod = new FeedbackMasterDAL();
            return FeedbackcallMethod.GetFeedbackMaster(companyId);

        }

        public string DeleteFeedbackCallMaster(int recordId)
        {

            FeedbackMasterDAL FeedbackcallMethod = new FeedbackMasterDAL();
            return FeedbackcallMethod.DeleteFeedbackMaster(recordId);
        }
    }
}