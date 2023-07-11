using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static HelpDeskServices.Controllers.DashboardController;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class DashbordBAL
    {
        DashboardDAL DAL = new DashboardDAL();

        public HelpdeskManagement GetHelpdeskManagement(int companyId)
        {
            return DAL.GetHelpdeskManagement(companyId);
        }

        public assetcounts GetAssetdata(int companyId)
        {
            return DAL.GetAssetdata(companyId);
        }

        public List<ListOfhelpedeskmanagement> GetmapbyLocation(List<LocationRequest> request)
        {
            return DAL.GetmapbyLocation(request);
        }

        public List<ListOfhelpedeskmanagement> GetmapbyLocationPM(List<LocationRequest> request)
        {
            return DAL.GetmapbyLocationPM(request);
        }

    }
}