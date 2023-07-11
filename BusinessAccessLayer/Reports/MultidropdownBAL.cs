using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Reports;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Reports
{
    public class MultidropdownBAL
    {
        MultidropdownDAL DAL = new MultidropdownDAL();
        public Task<List<ZoneModel>> GetZoneNameBySiteid(int companyId, string location)
        {
            return Task.FromResult(DAL.GetZoneNameBySiteid(companyId, location));
        }

        public Task<List<BuildingModel>> GetbuildingList(int companyId, string zone)
        {
            return Task.FromResult(DAL.GetbuildingList(companyId, zone));
        }
        public Task<List<FloorMasterModel>> GetfloorList(int companyId, string building)
        {
            return Task.FromResult(DAL.GetfloorList(companyId, building));
        }

        public Task<List<Service>> GetServiceList(int companyId, string businessunit)
        {
            return Task.FromResult(DAL.GetServiceList(companyId, businessunit));
        }


        public Task<List<SystemMaster>> GetSystemList(int companyId, string service)
        {
            return Task.FromResult(DAL.GetSystemList(companyId, service));
        }

        public Task<List<SubSytem>> GetSubSystemList(int companyId, string system)
        {
            return Task.FromResult(DAL.GetSubSystemList(companyId, system));
        }

        public Task<IEnumerable<allassetsresponce>> Getallassetdetails(allassetsreq req)
        {
            return Task.FromResult(DAL.Getallassetdetails(req));
        }

        public Task<IEnumerable<object>> GetareaList(int Companyid, string floor)
        {
            return Task.FromResult(DAL.GetareaList(Companyid, floor));
        }
        public Task<IEnumerable<object>> GetRoomList(int Companyid, string area)
        {
            return Task.FromResult(DAL.GetRoomList(Companyid, area));
        }
    }
}