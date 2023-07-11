using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Maintenance_mgmt.PM_by_system;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_System.CreateController;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.BusinessAccessLayer.Maintenance_mgmt.pm_by_system
{
    public class CreateplanBAL
    {
        CreateplanDAL DAL = new CreateplanDAL();

        public Task<IEnumerable<object>> getcreatedetails(allassetsreq obj)
        {
            return Task.FromResult(DAL.getcreatedetails(obj));
        }

        public Task<IEnumerable<object>> getroutemappingdetails(allassetsreq obj)
        {
            return Task.FromResult(DAL.getroutemappingdetails(obj));
        }

        public Task<Hd_Responce> getcreatedetailsforchange(allassetsreq obj)
        {
            return Task.FromResult(DAL.getcreatedetailsforchange(obj));
        }



        public Task<Hd_Responce> getlistforapprove(allassetsreq obj)
        {
            return Task.FromResult(DAL.getlistforapprove(obj));
        }


        public Task<Hd_Responce> GetprintWOList(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetprintWOList(obj));
        }

        public Task<Hd_Responce> GetprintWOaftrapprv(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetprintWOaftrapprv(obj));
        }


        public Task<Hd_Responce> GetpmbySYSWoCloselist(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetpmbySYSWoCloselist(obj));
        }

        public Task<Hd_Responce> GetDetailsbycomplete(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetDetailsbycomplete(obj));
        }

        public Task<Hd_Responce> getchildcounts(int Id)
        {
            return Task.FromResult(DAL.getchildcounts(Id));
        }

        public Task<Hd_Responce> getchilddata(int Id)
        {
            return Task.FromResult(DAL.getchilddata(Id));
        }

        public Task<Hd_Responce> getclosedetailsbyplan(int Id)
        {
            return Task.FromResult(DAL.getclosedetailsbyplan(Id));
        }


        public Task<Hd_Responce> getchilddataforupdate(int Id)
        {
            return Task.FromResult(DAL.getchilddataforupdate(Id));
        }

        public Task<Hd_Responce> getTasklistForschedule(int Id)
        {
            return Task.FromResult(DAL.getTasklistForschedule(Id));
        }


        public Task<Hd_Responce> updateWoPmBySys(List<closereq> req)
        {
            return Task.FromResult(DAL.updateWoPmBySys(req));
        }



        public Task<IEnumerable<object>> getlocationbyassetSubsys(int Companyid, string Subsys)
        {
            return Task.FromResult(DAL.getlocationbyassetSubsys(Companyid, Subsys));
        }

        public Task<object> Createplan(List<planreq> req)
        {
            return Task.FromResult(DAL.Createplan(req));
        }

        public Task<Hd_Responce> Changeplan(List<planreq> req)
        {
            return Task.FromResult(DAL.Changeplan(req));
        }

        public Task<Hd_Responce> Addchilddats(List<listofresourcesandspares> req)
        {
            return Task.FromResult(DAL.Addchilddats(req));
        }

        public Task<Hd_Responce> UpdatePmBySYchilddats(List<listofresourcesandspares> req)
        {
            return Task.FromResult(DAL.UpdatePmBySYchilddats(req));
        }


        public Task<Hd_Responce> ApprovePlanWo(List<apprvid> req)
        {
            return Task.FromResult(DAL.ApprovePlanWo(req));
        }

        public Task<Hd_Responce> CheckWOHoliday(string date,int ShiftId)
        {
            return Task.FromResult(DAL.CheckWOHoliday(date, ShiftId));
        }


        public Task<Hd_Responce> GetpmbySYSWoreshedulelist(allassetsreq obj)
        {
            return Task.FromResult(DAL.GetpmbySYSWoreshedulelist(obj));
        }

        public Task<Hd_Responce> reshedulePmbysyschilddats(List<listofresourcesandspares> req)
        {
            return Task.FromResult(DAL.reshedulePmbysyschilddats(req));
        }
    }
}