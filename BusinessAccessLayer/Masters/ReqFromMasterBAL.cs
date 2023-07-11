using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class ReqFromMasterBAL
    {
        ReqFromMasterDAL DAL = new ReqFromMasterDAL();

        public string CreatereqFrom(RequestForm obj)
        {
            return DAL.CreateReqFrom(obj);
        }

        public string UpdateReqfrom(RequestForm obj)
        {
            return DAL.UpdateReqFrom(obj);
        }

        public List<RequestForm> GetReqMaster(int companyId)
        {
            return DAL.GetReqFromMaster(companyId);
        }

        public string DeleteReqfrom(DeleteObj obj)
        {
            return DAL.DeleteReqfrom(obj);
        }
    }
}