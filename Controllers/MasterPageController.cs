using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/Master")]
    public class MasterPageController : ApiController
    {
        [HttpGet]
        [Route("GetNavigationMenu")]

        public HttpResponseMessage GetNavigationMenu(string UserType,string CompanyCode)
        {
            MasterModule businesslayermaster = new MasterModule();
            List<menuObject> mastermenu = businesslayermaster.GetSideNavigation(UserType, CompanyCode);
            return Request.CreateResponse(HttpStatusCode.OK, mastermenu);
        }
        [HttpGet]
        [Route("GetSubmenuItems")]

        public HttpResponseMessage GetSubmenuItems(int Categoryid,string lang)
        {
            MasterModule BAL = new MasterModule();
            List<menuObject> Responce = new List<menuObject>();
            return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.GetSubmenuItems(Categoryid,lang));
        }

        [HttpGet]
        [Route("BusinessUnitdata")]
        public HttpResponseMessage GetBussinessUnit(int companyId)
        {
            MasterModule GetBusinessData = new MasterModule();
            List<BusinessObject> businessdata = new List<BusinessObject>();
            businessdata=GetBusinessData.GetBussinessUnit(companyId);

            return Request.CreateResponse(HttpStatusCode.OK, businessdata);
        }

        [HttpPost]
        [Route("InsertBussinessUnit")]

        public HttpResponseMessage InsertBussinessUnit(BussinessParametersObj businessUnit)
        {
            MasterModule InsertBusinessData = new MasterModule();
            string Status;
            if (businessUnit.ActionType == "update")
            {
                //update
                Status = InsertBusinessData.updateBusinessUnit(businessUnit);
               
            }
            else
            {
                //insert
                Status = InsertBusinessData.insertBusinessUnit(businessUnit);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        //[HttpPost]
        //public HttpResponseMessage UpdateBussinessUnitDetails(BussinessParametersObj businessUnitobj)
        //{
        //    MasterModule updateBusinessUnitdetails = new MasterModule();
        //    string Status = updateBusinessUnitdetails.updateBusinessUnit(businessUnitobj);
        //    return Request.CreateResponse(HttpStatusCode.OK, Status);
        //}
        [HttpGet]
        [Route("DeletebussinessCodeRecord")]

        public HttpResponseMessage DeletebussinessCodeRecord(int RecordId,int CompanyId)
        {
            MasterModule deleteMasterBussinessUnitRecord = new MasterModule();
            string status=deleteMasterBussinessUnitRecord.DeleteBussinessUnit(RecordId,CompanyId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }


        [HttpGet]
        [Route("GetCountries")]

        public HttpResponseMessage GetCountries(int companyId)
        {
            MasterServiceBLL CountriesBal = new MasterServiceBLL();
            List<CountriesModel> countriesList = new List<CountriesModel>();
            countriesList=CountriesBal.GetCoutries();
            return Request.CreateResponse(HttpStatusCode.OK, countriesList);
        }

        [HttpGet]
        [Route("GetCities")]

        public HttpResponseMessage GetCities(string countryName)
        {
            MasterServiceBLL CitiessBal = new MasterServiceBLL();
            List<CitiesModel> citiesList = new List<CitiesModel>();
            citiesList = CitiessBal.GetCities(countryName);
            return Request.CreateResponse(HttpStatusCode.OK, citiesList);
        }

        [HttpGet]
        [Route("GetAllCities")]

        public HttpResponseMessage GetAllCities(string companyID,string CompanyName)
        {
            MasterServiceBLL CitiessBal = new MasterServiceBLL();
            List<CitiesModel> citiesList = new List<CitiesModel>();
            citiesList = CitiessBal.GetAllCities();
            return Request.CreateResponse(HttpStatusCode.OK, citiesList);
        }

        [HttpGet]
        [Route("GetLocationByCity")]

        public HttpResponseMessage GetLocationByCity(string cityCode, int companyId)
        {
            MasterServiceBLL CitiessBal = new MasterServiceBLL();
            List<LocationModel> citiesList = new List<LocationModel>();
            citiesList = CitiessBal.GetLocationByCity(cityCode, companyId);
            return Request.CreateResponse(HttpStatusCode.OK, citiesList);
        }

      
    }
}
