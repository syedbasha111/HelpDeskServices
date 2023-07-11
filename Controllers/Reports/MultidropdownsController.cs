using HelpDeskServices.BusinessAccessLayer.Reports;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Reports
{
    [RoutePrefix("api/Multidropdowns")]
    public class MultidropdownsController : ApiController
    {
        MultidropdownBAL BAL = new MultidropdownBAL();

        [HttpGet]
        [Route("ZoneByLocation")]
        public async Task<List<ZoneModel>> GetZoneList(int CompanyId, String Locations)
        {
            return await BAL.GetZoneNameBySiteid(CompanyId, Locations); ;
        }

        [HttpGet]
        [Route("Building")]
        public async Task<List<BuildingModel>> GetbuildingList(int CompanyId, String Zone)
        {
            return await BAL.GetbuildingList(CompanyId, Zone); ;
        }

        [HttpGet]
        [Route("Floor")]
        public async Task<List<FloorMasterModel>> GetfloorList(int CompanyId, String building)
        {
            return await BAL.GetfloorList(CompanyId, building); ;
        }

        [HttpGet]
        [Route("Service")]
        public async Task<List<Service>> GetServiceList(int CompanyId, String businessunit)
        {
            return await BAL.GetServiceList(CompanyId, businessunit); ;
        }

        [HttpGet]
        [Route("System")]
        public async Task<List<SystemMaster>> GetSystemList(int CompanyId, String service)
        {
            return await BAL.GetSystemList(CompanyId, service); ;
        }

        [HttpGet]
        [Route("SubSystem")]
        public async Task<List<SubSytem>> GetSubSystemList(int CompanyId, String system)
        {
            return await BAL.GetSubSystemList(CompanyId, system); 
        }

        [HttpGet]
        [Route("Area")]
        public async Task<IEnumerable<object>> GetareaList(int CompanyId, String floor)
        {
            return await BAL.GetareaList(CompanyId, floor);
        }

        [HttpGet]
        [Route("Room")]
        public async Task<IEnumerable<object>> GetRoomList(int CompanyId, String area)
        {
            return await BAL.GetRoomList(CompanyId, area);
        }

        [HttpPost]
        [Route("Allasetreports")]
        public async Task<IEnumerable<allassetsresponce>> Getallassetdetails(allassetsreq request)
        {
            return await BAL.Getallassetdetails(request);
        }






    }
    public class allassetsreq
    {
        public string id { get; set; }
        public string Locations { get; set; }
        public string Assetroute { get; set; }
        public string Zone { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Businessunit { get; set; }
        public string service { get; set; }
        public string system { get; set; }
        public string subsystem { get; set; }
        public string Employeelist { get; set; }
        public string Year { get; set; }
        public string uniqueAssetId { get; set; }
        public string frequency { get; set; }
        
        public string Companyid { get; set; }
        public string Pageno { get; set; }
        public string pagesize { get; set; }

        public string fromdate { get; set; }
        public string todate { get; set; }

    }

    public class allassetsresponce
    {
        public string Id { get; set; }
        public string UniqueassetId { get; set; }
        public string Assetname { get; set; }
        public string Assetdesc { get; set; }
        public string AsserRoute { get; set; }
        public string Location { get; set; }
        public string Sitecode { get; set; }
        public string Site { get; set; }
        public string ZoneCode { get; set; }
        public string Zone { get; set; }
        public string BuildingCode { get; set; }
        public string Building { get; set; }
        public string FloorCode { get; set; }
        public string Floor { get; set; }
        public string RoomCode { get; set; }
        public string Room { get; set; }
        public string LocationClass { get; set; }
        public string BusinessCode { get; set; }
        public string Businessunit { get; set; }
        public string ServiceCode { get; set; }
        public string Service { get; set; }
        public string Systemcode { get; set; }
        public string System { get; set; }
        public string subSystemcode { get; set; }
        public string systeminventorynumber{ get; set; }
        public string subsysteminventorynumber{ get; set; }
        public string systemdesc{ get; set; }
        public string subsystemdesc{ get; set; }
        public string systemquantity{ get; set; }
        public string subsystemquantity{ get; set; }
        public string status{ get; set; }
        public string major_minor{ get; set; }
        public string Pmtype{ get; set; }
        public string Companyid { get; set; }
        public string Totalrecords { get; set; }


    }


}



