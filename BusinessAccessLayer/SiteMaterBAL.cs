using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class SiteMaterBAL
    {

        public string CreateSiteMaster(SiteMasterModel obj)
        {
            SiteMasterDAL DAL = new SiteMasterDAL();
            return DAL.CreateSiteMaster(obj);

        }
        public string UpdateSiteMaster(SiteMasterModel obj)
        {
            SiteMasterDAL DAL = new SiteMasterDAL();
            return DAL.UpdateSiteMaster(obj);

        }
        public List<SiteMasterModel> GetSiteMaster(int companyId)
        {
            SiteMasterDAL DAL = new SiteMasterDAL();
            return DAL.GetSiteMaster(companyId);
        }
        public string DeleteSiteMaster(int id)
        {
            SiteMasterDAL StatecallMethod = new SiteMasterDAL();
            return StatecallMethod.DeleteSiteMaster(id);

        }
    }
}