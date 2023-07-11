using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class GroupMasterBAL
    {
        GroupMasterDAL DAL = new GroupMasterDAL();
        public List<GroupMasterModel> GetGroupMasterName(int CompanyId)
        {
            return DAL.GetGroupMasterName(CompanyId);
        }
        public List<GroupMasterModel> GetGroupMasterCode(int Id,int CompanyId)
        {
            return DAL.GetGroupMasterCode(Id,CompanyId);
        }
    }
}