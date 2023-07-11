using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataAccessLayer.DocumentsPathsDAL;
using HelpDeskServices.DataModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanymasterController : ApiController
    {
        CompanyMasterBAL BAL = new CompanyMasterBAL();


        /// <summary>
        /// Get drop down Values like CompanyName,Currencycode,TimeZone
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Companydropdowns")]
        public HttpResponseMessage GetBindingdata()
        {
            MVCompanyData List = new MVCompanyData();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetBindingdata());
        }

        [HttpGet]
        [Route("Companydropdownsbyuser")]
        public HttpResponseMessage GetCompanyBasedUser(string Username)
        {
            List<CompanyMaster> List = new List<CompanyMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCompanyBasedUser(Username));
        }
        /// <summary>
        /// Get Currency Name By CurrencyId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CurrencyName")]
        public HttpResponseMessage GetCurrencyName(int Id)
        {
            List<CurrencyCode> List = new List<CurrencyCode>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCurrencyName(Id));
        }

        /// <summary>
        /// Get Company Name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Company")]
        public HttpResponseMessage GetCompanydata()
        {
            List<CompanyMaster> List = new List<CompanyMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCompanyName());
        }

        [HttpPost]
        [Route("CompanyMaster")]
        public HttpResponseMessage CreateCompanymaster(CompanyMaster request)
        {
            string status = "";

            if (request.CompanyId > 0)
            {
                status = BAL.UpdateCompanyMaster(request);
            }
            else
            {
                status = BAL.CompanyMaster(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpPost]
        [Route("logoFile")]
        public HttpResponseMessage savelogoFile()
        {
            string sucess = "";
            string  responce = deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "ComapanyLogo");
            string fileSavePath = string.Empty;
             if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                string filPath = string.Empty;

                var httpPostedFile = HttpContext.Current.Request.Files["fileUpload"];
                fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/Logo"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);
                filPath = "/Holiday/Logo/" + httpPostedFile.FileName;
                CompanyMaster image = new CompanyMaster();
                image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                image.Logo = filPath;
                sucess = BAL.savelogoFile(image);

            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }


        [HttpPost]
        [Route("docsFile")]
        public HttpResponseMessage savedocsFile()
        {
            string sucess = "";
            string responce = deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "ComapanyDoc");

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                string filPath = string.Empty;
                string fileSavePath = string.Empty;

                var httpPostedFile = HttpContext.Current.Request.Files["fileUpload"];
                fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/RasieServiceDocuments"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);
                filPath = "/Holiday/CompanyDocs/" + httpPostedFile.FileName;
                CompanyMaster image = new CompanyMaster();
                image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                image.CompanyRegistrationDocument = filPath;
                sucess = BAL.savedocsFile(image);
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("grid")]
        public HttpResponseMessage SaveCompanyGrid(int Id, List<CompanyAdressDetails> request)
        {
            string status = "";
            if (request[0].CompanyMasterDetailId > 0)
            {
                //status = BAL.UpdateCompanyGrid(Id, request);
            }
            else
            {
                status = BAL.SaveCompanyGrid(Id, request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("CompanyAdress")]
        public HttpResponseMessage GetCompanyAdress(int CompanyId)
        {
            List<CompanyAdressDetails> List = new List<CompanyAdressDetails>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCompanyAdress(CompanyId));
        }

        [HttpGet]
        [Route("CompanyType")]
        public HttpResponseMessage GetCompanyType(int CompanyId)
        {
            List<OfficeTypeModel> List = new List<OfficeTypeModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCompanyType(CompanyId));
        }




        public string deleteImages(int Id,string jsonname)
        {
            string jsonFile = HttpContext.Current.Server.MapPath("~/Common/Tabledata.json");
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray a = (JArray)jObject[jsonname];
            
            IList<Imagepathdetails> person = a.ToObject<IList<Imagepathdetails>>();
            person[0].Id =(Id).ToString();
            DeleteImages Dal = new DeleteImages();
            List<ImageModel> data = Dal.GetImagespathdetails(person);

            if (data.Count > 0)
            {
                foreach (var list in data)
                {
                    string fileSavePath1 = string.Empty;
                    fileSavePath1 = Path.Combine(HttpContext.Current.Server.MapPath(""), list.Imagepathpath);
                    if (File.Exists(fileSavePath1))
                        File.Delete(fileSavePath1);
                }

                return "deleted";
            }


            return "No records";
        }
    }
    public class Imagepathdetails
    {
        public string Id { get; set; }
        public string TableName { get; set; }
        public string Id_name { get; set; }
        public string ImagePath1 { get; set; }
    }

}
