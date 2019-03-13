using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class AssetLocationBAL
    {
        public List<AssetLocation> GetAssetLocationById(int companyId)
        {
            AssetLocationDAL getassetLocations = new AssetLocationDAL();
            return getassetLocations.GetAssetLocations(companyId);
        }

        public string InsertAssetLocation(AssetLocation assetsobj)
        {
            AssetLocationDAL insertassetLocations = new AssetLocationDAL();
           return insertassetLocations.InsertAssetLocation(assetsobj);

        }

        public string UpdateAssetLocation(AssetLocation assetsobj)
        {
            AssetLocationDAL UpdateassetLocations = new AssetLocationDAL();
            return UpdateassetLocations.UpdateAssetLocation (assetsobj);

        }

        public string DeleteAssetLocation(int assetLocationId)
        {
            AssetLocationDAL deleteassetLocations = new AssetLocationDAL();
            return deleteassetLocations.DeleteAssetLocation(assetLocationId);

        }
    }
}