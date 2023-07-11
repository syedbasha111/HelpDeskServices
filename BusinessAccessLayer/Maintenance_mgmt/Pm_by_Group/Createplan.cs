using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Maintenance_mgmt.Pm_by_group;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_group.CreateplanController;

namespace HelpDeskServices.BusinessAccessLayer.Maintenance_mgmt.Pm_by_Group
{
    public class CreateplanBAL
    {
        createplan DAL = new createplan();

        public Task<IEnumerable<object>> getcreatedetails(allassetsreq obj)
        {
            return Task.FromResult(DAL.getcreatedetails(obj));
        }
        public Task<object> Createplan(List<planreq> req)
        {
            return Task.FromResult(DAL.Createplan(req));
        }
        public Task<Hd_Responce> getcreatedetailsforchange(allassetsreq obj)
        {
            return Task.FromResult(DAL.getcreatedetailsforchange(obj));
        }
        public Task<Hd_Responce> Changeplan(List<planreq> req)
        {
            return Task.FromResult(DAL.Changeplan(req));
        }
        public Task<Hd_Responce> getlistforapprove(allassetsreq obj)
        {
            return Task.FromResult(DAL.getlistforapprove(obj));
        }
        public Task<Hd_Responce> ApprovePlanWo(List<apprvid> req)
        {
            return Task.FromResult(DAL.ApprovePlanWo(req));
        }
        public Task<Hd_Responce> GetDetailsbycomplete(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetDetailsbycomplete(obj));
        }
        public Task<Hd_Responce> GetprintWOaftrapprv(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetprintWOaftrapprv(obj));
        }
        public Task<Hd_Responce> GetpmbygrpWoCloselist(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetpmbygrpWoCloselist(obj));
        }
        public Task<Hd_Responce> GetpmbygrpWoreshedulelist(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetpmbygrpWoreshedulelist(obj));
        }

    }
}