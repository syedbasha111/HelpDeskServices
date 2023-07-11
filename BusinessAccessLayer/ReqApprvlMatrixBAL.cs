using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ReqApprvlMatrixBAL
    {
        ReqApprvlMatrixDAL DAL = new ReqApprvlMatrixDAL();

        public string SaveReqApprvlMatrix(requestApprovalmatrix request)
        {
            return DAL.SaveReqApprvlMatrix(request);
        }
        public string UpdateReqApprvlMatrix(requestApprovalmatrix request)
        {
            return DAL.UpdateReqApprvlMatrix(request);
        }

        public List<requestApprovalmatrix> getReqApprvlMatrix(int CompanyId)
        {
            return DAL.getReqApprvlMatrix(CompanyId);
        }

        public string deleteApprovematrix(DeleteObj request)
        {
            return DAL.deleteApprovematrix(request);
        }
    }
}