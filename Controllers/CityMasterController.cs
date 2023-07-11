using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/cityController")]
    public class CityMasterController : ApiController
    {



        [HttpPost]
        [Route("insertCity")] //Matches POST api/products
        public HttpResponseMessage InsertCity(CityModel Citydata)
        {
            string status = "";
            CityMasterBAL getCity = new CityMasterBAL();
            if (Citydata.CityId != 0)
            {
                status = getCity.updateCityMaster(Citydata);
            }
            else
            {
                status = getCity.InsertCityMaster(Citydata);
            }
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("getCity")]
        public HttpResponseMessage GetCityMaster(int companyId)
        {
            CityMasterBAL getCity = new CityMasterBAL();
            List<CityModel> CityList = new List<CityModel>();
            return Request.CreateResponse(HttpStatusCode.OK, CityList = getCity.GetCityMaster(companyId));
        }

        [HttpGet]
        [Route("getStateForCitys")]
        public HttpResponseMessage GetStateMaster(int companyId, int countryId)
        {
            CityMasterBAL getCity = new CityMasterBAL();
            List<StateModel> StateList = new List<StateModel>();
            return Request.CreateResponse(HttpStatusCode.OK, StateList = getCity.GetState(companyId, countryId));
        }

        [HttpPost]
        [Route("DeleteCity")]
        public HttpResponseMessage deleteCityMaster(DeleteObj obj)
        {
            CityMasterBAL getCity = new CityMasterBAL();
            string status = "";
            return Request.CreateResponse(HttpStatusCode.OK, status = getCity.DeleteCityMaster(obj));
        }

        [HttpGet]
        [Route("citiesofstates")]
        public HttpResponseMessage Getcities(int companyId, int countryId, int stateid)
        {
            CityMasterBAL getCity = new CityMasterBAL();
            List<CityModel> CityList = new List<CityModel>();


            return Request.CreateResponse(HttpStatusCode.OK, CityList= getCity.Getcitybystate(companyId, countryId, stateid));
        }
        [HttpPost]
        [Route("File")]
        public HttpResponseMessage saveFile()
        {
            string sucess = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                string filPath = string.Empty;
                string fileSavePath = string.Empty;

                var httpPostedFile = HttpContext.Current.Request.Files["fileUpload"];
                fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/XmlFiles"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);
                sucess = "Saved";
            }
            else {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }


        //[HttpPost]
        //[Route("DownloadFile")]
        //public IHttpActionResult DownloadFile(string fileName)
        //{
        //    var currentDirectory = System.IO.Directory.GetCurrentDirectory();
        //    currentDirectory = currentDirectory + "\\Holiday\\XmlFiles";
        //    var file = Path.Combine(Path.Combine(currentDirectory, "attachments"), fileName);
        //    return  Ok(file);
        //}
    }
}
