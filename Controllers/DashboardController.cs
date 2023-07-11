using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        DashbordBAL BAL = new DashbordBAL();

        [HttpGet]
        [Route("HelpdeskManagement")]
        public IHttpActionResult GetHelpdeskManagement(int companyId)
        {
            return Ok(BAL.GetHelpdeskManagement(companyId));
        }

        [HttpGet]
        [Route("AssetDataforchart")]
        public IHttpActionResult GetAssetdata(int companyId)
        {
            return Ok(BAL.GetAssetdata(companyId));
        }

        [HttpPost]
        [Route("MapbyLocation")]
        public IHttpActionResult GetmapbyLocation(List<LocationRequest> request)
        {
            return Ok(BAL.GetmapbyLocation(request));
        }

        [HttpPost]
        [Route("MapbyLocationPM")]
        public IHttpActionResult GetmapbyLocationPM(List<LocationRequest> request)
        {
            return Ok(BAL.GetmapbyLocationPM(request));
        }

        public class LocationRequest
        {
            public int CompanyId { get; set; }
            public int Site { get; set; }
            public string Lat { get; set; }
            public string Lng { get; set; }
            public List<Service> Locationservice { get; set; }

        }
       

    }
}
