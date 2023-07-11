using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MaintenanceSLABAL
    {
        MaintenanceSLADAL DAL = new MaintenanceSLADAL();
        public string SaveMaintenanceSLA(MaintenanceSLA request)
        {
            return DAL.SaveMaintenanceSLA(request);
        }

        public string UpdateMaintenanceSLA(MaintenanceSLA request)
        {
            return DAL.UpdateMaintenanceSLA(request);
        }

        public List<MaintenanceSLA> getMaintenanceSLA(int CompanyId)
        {
            return DAL.getMaintenanceSLA(CompanyId);
        }
    }
}