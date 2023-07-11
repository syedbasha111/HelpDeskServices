using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class SRAssignMasterBAL
    {
        SRAssignMasterDAL DAL = new SRAssignMasterDAL();

        public List<NewUser> GetEmaployeeBysite(int SiteId,int CompanyId)
        {
            return DAL.GetEmaployeeBysite(SiteId, CompanyId);
        }

        public string SaveSrAssignMaster(SrAssignmaster obj)
        {
            return DAL.SaveSrAssignMaster(obj);
        }

        public List<NewUser> GetEmployeebyService(int ServiceId, int CompanyId)
        {
            return DAL.GetEmployeebyService(ServiceId, CompanyId);
        }

        public HD_BaseModel createSiteEmployeeMapping(SiteEmpMapping req)
        {
            return DAL.createSiteEmployeeMapping(req);
        }

    }
}