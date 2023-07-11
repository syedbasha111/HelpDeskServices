using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Transaction
{
    public class ApproveWoBAL
    {
        ApproveWoDAL DAL = new ApproveWoDAL();
        public List<ApproveModel> ApproveList(ApproveModel request)
        {
            return DAL.ApproveList(request);
        }

        public string UpdateApproveorderlist(List<Workorder> request)
        {
            return DAL.UpdateApproveorderlist(request);

        }
    }
}