using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class MiantananceSystemMasterBAL
    {

        MaintanceSystemDAL DAL = new MaintanceSystemDAL();
        public string SaveSystem(SystemMaster request)
        {
            return DAL.SaveSystem(request);
        }
        public string UpdateSystem(SystemMaster request)
        {
            return DAL.UpdateSystem(request);
        }

        public string DeleteSystemdata(int CompanyId, int Id)
        {
            return DAL.DeleteSystemdata(CompanyId, Id);
        }
        public List<SystemMaster> GetSystemdata(int CompanyId)
        {
            return DAL.GetSystemdata(CompanyId);
        }
        
    }
}