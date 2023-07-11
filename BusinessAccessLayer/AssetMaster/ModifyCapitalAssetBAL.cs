using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class ModifyCapitalAssetBAL
    {
        ModifyCapitalAssetDAL DAL = new ModifyCapitalAssetDAL();

        public List<AddCapitalAsset> GetCapitalAsset(AddCapitalAsset request)
        {
            return DAL.GetCapitalAsset(request);
        }
    }
}