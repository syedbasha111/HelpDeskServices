using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static HelpDeskServices.Controllers.Masters.FutureplansController;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class FutureplansBAL
    {
        FutureplansDAL DAL = new FutureplansDAL();
        public Task<Hd_Responce> Getplans(Featureplansearch req)
        {
            return Task.FromResult(DAL.Getplans(req));
        }

        public Task<Hd_Responce> PlansToCreate()
        {
            return Task.FromResult(DAL.PlansToCreate());
        }

        public Task<Hd_Responce> SavePlanDetailsItems(List<PlanListAddItemModel> req)
        {
            return Task.FromResult(DAL.SavePlanListItems(req));
        }
        public Task<Hd_Responce> UpdateprovisionalplanDetailsItems(List<PlanListAddItemModel> req)
        {
            return Task.FromResult(DAL.UpdatedPlanListItems(req));
        }
    }
}