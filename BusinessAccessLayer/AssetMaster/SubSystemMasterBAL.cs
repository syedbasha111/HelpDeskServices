using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class SubSystemMasterBAL
    {
        SubSystemMasterDAL DAL = new SubSystemMasterDAL();
        public string SaveSubSystem(SubSytem request)
        {
            return DAL.SaveSubSystem(request);
        }
        public string UpdateSubSystem(SubSytem request)
        {
            return DAL.UpdateSubSystem(request);
        }

        public List<SystemMaster> GetSystemdata(SystemMaster request)
        {
            return DAL.GetSystemdata(request);
        }

        public List<SubSytem> GetSubSystemData(int CompanyId)
        {
            return DAL.GetSubSystemData(CompanyId);
        }

        public string DeleteSubSystemdata(int CompanyId, int Id)
        {
            return DAL.DeleteSubSystemdata(CompanyId, Id);
        }
    }
}