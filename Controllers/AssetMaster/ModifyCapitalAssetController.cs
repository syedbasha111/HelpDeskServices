using HelpDeskServices.BusinessAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers.AssetMaster
{
    [RoutePrefix("api/ModifyCapitalAsset")]
    public class ModifyCapitalAssetController : ApiController
    {
        ModifyCapitalAssetBAL BAL = new ModifyCapitalAssetBAL();
    
        [HttpPost]
        [Route("searchdata")]
        public IHttpActionResult GetCapitalAsset(AddCapitalAsset request)
        {
            List<AddCapitalAsset> List = new List<AddCapitalAsset>();
            return Ok( List = BAL.GetCapitalAsset(request));
        }
    }
}
