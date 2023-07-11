using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Reports;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Reports;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Reports
{
    public class Reportsclass
    {
        ReportsDALClass Dal = new ReportsDALClass();

        public List<CM_Performance> CMPerformanceReport(RaiseService obj)
        {
            return Dal.CMPerformanceReport(obj);
        }

        public List<CM_status_details> CMStatusDetails(RaiseService obj)
        {
            return Dal.CMStatusDetails(obj);
        }
        public List<site_performance> performancedatabySite(RaiseService obj)
        {
            return Dal.performancedatabySite(obj);
        }

        public List<pending_Wo_responce> PendingWO_Report(pending_Wo_request obj)
        {
            return Dal.PendingWO_Report(obj);
        }

        public List<RE_cap_closeWO> RecapCloseWo_report(RaiseService obj)
        {
            return Dal.RecapCloseWo_report(obj);
        }

        public List<Keyperformance> Key_Performance_report(RaiseService obj)
        {
            return Dal.Key_Performance_report(obj);
        }

        public Task<IEnumerable<Workorder>> ReportByTechnician(allassetsreq obj)
        {
            return Task.FromResult(Dal.ReportByTechnician(obj));
        }

        public Task<IEnumerable<Workorder>> CustomizedReports(allassetsreq obj)
        {
            return Task.FromResult(Dal.CustomizedReports(obj));
        }

        public Task<IEnumerable<TATResponce>> TATReports(allassetsreq obj)
        {
            return Task.FromResult(Dal.TATReports(obj));
        }

        public Task<IEnumerable<object>> DailyOperationReports(allassetsreq obj)
        {
            return Task.FromResult(Dal.DailyOperationReports(obj));
        }
    }
}