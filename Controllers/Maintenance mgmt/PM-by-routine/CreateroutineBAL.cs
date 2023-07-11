using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_routine.CreateroutineController;
using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_routine
{
    public class CreateroutineBAL
    {
        Createroutine DAL = new Createroutine();
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

    }
}