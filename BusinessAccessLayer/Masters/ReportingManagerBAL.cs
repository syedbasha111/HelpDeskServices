using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class ReportingManagerBAL
    {
        ReportingManagerDAL DAL = new ReportingManagerDAL();
        public string CreateReportingMaster(ReportingManager request)
        {
            
            return DAL.CreateReportingMaster(request);
        }
        public string UpdateReportingMaster(ReportingManager request)
        {

            return DAL.UpdateReportingMaster(request);
        }

        public string DeleteReportingManger(DeleteObj request)
        {

            return DAL.DeleteReportingManger(request);
        }
    }
}