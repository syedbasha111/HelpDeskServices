using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/AssetLocation")]
    public class AssetLocationController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAssetLocationById(int companyId)
        {
            AssetLocationBAL getassetlocation = new AssetLocationBAL();
            List<AssetLocation> assetLocationList = new List<AssetLocation>();
            assetLocationList=getassetlocation.GetAssetLocationById(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, assetLocationList);
        }

        [HttpPost]
        public HttpResponseMessage InsertAssetLocation(AssetLocation assetlocationObj)
        {
            string result = "";
            AssetLocationBAL insertassetlocation = new AssetLocationBAL();
            if (assetlocationObj.AssetLocationId != 0)
            {
                result= insertassetlocation.UpdateAssetLocation(assetlocationObj);
            }
            else
            {
                result = insertassetlocation.InsertAssetLocation(assetlocationObj);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpDelete]
        [Route("DeleteAsset")]
        public HttpResponseMessage DeleteAssetLocationById(int recordId,int CompanyId)
        {
            string result = "";
            AssetLocationBAL deleteassetlocation = new AssetLocationBAL();
            result = deleteassetlocation.DeleteAssetLocation(recordId, CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        
    }
}
