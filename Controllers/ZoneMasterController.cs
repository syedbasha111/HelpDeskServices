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
    [RoutePrefix("api/ZoneMaster")]
    public class ZoneMasterController : ApiController
    {

        /// <summary>
        /// Add Zone Master
        /// </summary>
        /// <param name="request">zoneModel</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Zone")] //Matches POST api/products
        public HttpResponseMessage CreateZoneMaster(ZoneModel request)
        {
            string status = "";
            ZoneMasterBAL BAL = new ZoneMasterBAL();
            if (request.ID > 0)
            {
                status = BAL.UpdateZoneMaster(request);
            }
            else
            {
                status = BAL.CreateZoneMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("ZoneMaster")]
        public HttpResponseMessage GetZoneMaster(int companyId)
        {
            ZoneMasterBAL responce = new ZoneMasterBAL();
            List<ZoneModel> List = new List<ZoneModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetZoneMaster(companyId));
        }

        [HttpGet]
        [Route("detailsbySiteId")]
        public HttpResponseMessage GetDetailsbySiteid(int companyId,int Id)
        {
            ZoneMasterBAL responce = new ZoneMasterBAL();
            SiteMasterDropdownlist List = new SiteMasterDropdownlist();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetDetailsbySiteid(companyId,Id));
        }


        [HttpPost]
        [Route("DeleteZone")]
        public HttpResponseMessage DeleteZoneMaster(DeleteObj obj)
        {
            ZoneMasterBAL responce = new ZoneMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = responce.DeleteSiteMaster(obj.RecordId));
        }

        [HttpGet]
        [Route("ZoneName")]
        public HttpResponseMessage GetZoneNameBySiteid(int companyId, int Id)
        {
            ZoneMasterBAL responce = new ZoneMasterBAL();
            List<ZoneModel> List = new List<ZoneModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = responce.GetZoneNameBySiteid(companyId, Id));
        }

    }
}
