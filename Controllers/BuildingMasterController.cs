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
    [RoutePrefix("api/BuildingMaster")]
    public class BuildingMasterController : ApiController
    {
        [HttpPost]
        [Route("Building")] //Matches POST api/products
        public HttpResponseMessage Buildingmaster(BuildingModel request)
        {
            string status = "";
            BuildingMasterBAL BAL = new BuildingMasterBAL();
            if (request.ID > 0)
            {
                status = BAL.updatebuildingMaster(request);
            }
            else
            {
                status = BAL.CreatebuildingMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("detailsbyZoneId")]
        public HttpResponseMessage GetDetailsbyZoneid(int companyId, int Id)
        {
            BuildingMasterBAL responce = new BuildingMasterBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetDetailsbyZoneid(companyId, Id));
        }

        [HttpGet]
        [Route("Building")]
        public HttpResponseMessage GetBuildingMaster(int companyId)
        {
            BuildingMasterBAL responce = new BuildingMasterBAL();
            List<BuildingModel> List = new List<BuildingModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetBuildingMaster(companyId));
        }
        [HttpDelete]
        [Route("DeleteBuilding")]
        public HttpResponseMessage deleteBuildingMaster(int Id)
        {
            BuildingMasterBAL responce = new BuildingMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.deleteBuildingMaster(Id));
        }

        [HttpGet]
        [Route("BuildingName")]
        public HttpResponseMessage GetBuildingNameByZoneid(int companyId, int Id)
        {
            BuildingMasterBAL responce = new BuildingMasterBAL();
            List<BuildingModel> List = new List<BuildingModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetBuildingNameByZoneid(companyId, Id));
        }
    }
}
