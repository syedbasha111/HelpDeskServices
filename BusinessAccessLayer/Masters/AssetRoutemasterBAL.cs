using HelpDeskServices.Controllers.Masters;
using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_System.CreateController;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class AssetRoutemasterBAL
    {
        AssetRoutemasterDAL DAL = new AssetRoutemasterDAL();

        public Task<Hd_Responce> SaveAssetroute(Assetroutegroupmode obj)
        {
            return Task.FromResult(DAL.SaveAssetroute(obj));
        }
        public Task<Hd_Responce> UpdateAssetroute(Assetroutegroupmode obj)
        {
            return Task.FromResult(DAL.UpdateAssetroute(obj));
        }


        public Task<Hd_Responce> getdetails(int companyid)
        {
            return Task.FromResult(DAL.getdetails(companyid));
        }

        public Task<Hd_Responce> Delatedetails(int Id, int companyid)
        {
            return Task.FromResult(DAL.Delatedetails(Id,companyid));
        }

        public Task<Hd_Responce> assetrouteupdate(List<planreq> req)
        {
            return Task.FromResult(DAL.assetrouteupdate(req));
        }
    }
}