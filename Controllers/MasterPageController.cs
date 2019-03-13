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
    public class MasterPageController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetNavigationMenu(string UserType,string CompanyCode)
        {
            MasterModule businesslayermaster = new MasterModule();
            List<menuObject> mastermenu = businesslayermaster.GetSideNavigation(UserType, CompanyCode);
            return Request.CreateResponse(HttpStatusCode.OK, mastermenu);
        }

        [HttpGet]
        public HttpResponseMessage GetBussinessUnit()
        {
            MasterModule GetBusinessData = new MasterModule();
            List<BusinessObject> businessdata = new List<BusinessObject>();
            businessdata=GetBusinessData.GetBussinessUnit();

            return Request.CreateResponse(HttpStatusCode.OK, businessdata);
        }

        [HttpPost]
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
        public HttpResponseMessage DeletebussinessCodeRecord(int RecordId)
        {
            MasterModule deleteMasterBussinessUnitRecord = new MasterModule();
            string status=deleteMasterBussinessUnitRecord.DeleteBussinessUnit(RecordId);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }


        [HttpGet]
        public HttpResponseMessage GetCountries(int companyId)
        {
            MasterServiceBLL CountriesBal = new MasterServiceBLL();
            List<CountriesModel> countriesList = new List<CountriesModel>();
            countriesList=CountriesBal.GetCoutries();
            return Request.CreateResponse(HttpStatusCode.OK, countriesList);
        }

        [HttpGet]
        public HttpResponseMessage GetCities(string countryName)
        {
            MasterServiceBLL CitiessBal = new MasterServiceBLL();
            List<CitiesModel> citiesList = new List<CitiesModel>();
            citiesList = CitiessBal.GetCities(countryName);
            return Request.CreateResponse(HttpStatusCode.OK, citiesList);
        }

        [HttpGet]
        public HttpResponseMessage GetAllCities(string companyID,string CompanyName)
        {
            MasterServiceBLL CitiessBal = new MasterServiceBLL();
            List<CitiesModel> citiesList = new List<CitiesModel>();
            citiesList = CitiessBal.GetAllCities();
            return Request.CreateResponse(HttpStatusCode.OK, citiesList);
        }
    }
}
