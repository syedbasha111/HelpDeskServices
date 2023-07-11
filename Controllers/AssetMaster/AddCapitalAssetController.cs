using HelpDeskServices.BusinessAccessLayer.AssetMaster;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelpDeskServices.Controllers.AssetMaster
{
    [RoutePrefix("api/AddCapitalAsset")]
    public class AddCapitalAssetController : ApiController
    {

        AddCapitalAssetBAL BAL = new AddCapitalAssetBAL();

        [HttpPost]
        [Route("AddCapitalAsset")]
        public HttpResponseMessage SaveAddCapitalAsset(AddCapitalAsset request)
        {
            string Responce = "";
            if (request.Id > 0)
            {
                Responce = BAL.UpdateAddCapitalAsset(request);
            }
            else
            {
                Responce = BAL.SaveAddCapitalAsset(request);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Responce);
        }
        [HttpGet]
        [Route("GetCapitalAsset")]
        public HttpResponseMessage getAddCapitalAsset(int Id, int CompanyId)
        {
            List<AddCapitalAsset> responce = new List<AddCapitalAsset>();
            return Request.CreateResponse(HttpStatusCode.OK, responce = BAL.GetCapitalAsset(Id, CompanyId));
        }

        [HttpPost]
        [Route("ExcelDocument")]
        public HttpResponseMessage saveDocumnet()
        {
            string sucess = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/AddCapitalAsset/Uploadexceldocument"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/AddCapitalAsset/Uploadexceldocument/" + httpPostedFile.FileName;
                    //RaiseService image = new RaiseService();
                    //image.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    //image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    //image.ImagePath = filPath;
                    //sucess = BAL.SaveWorkOrderdocuments(image);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("AssetImage")]
        public HttpResponseMessage saveAssetImage()
        {
            string sucess = "";
            string responce = new CompanymasterController().deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "AddcapitalImage");

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/AddCapitalAsset/AssetImage"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/AddCapitalAsset/AssetImage/" + httpPostedFile.FileName;
                    AddCapitalAsset image = new AddCapitalAsset();
                    image.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    image.UploadAssetImage = filPath;
                    sucess = BAL.SaveAssetImage(image);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("AssetDocument")]
        public HttpResponseMessage saveAssetDocument()
        {
            string sucess = "";
            string responce = new CompanymasterController().deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "AddcapitalDocument");

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/AddCapitalAsset/Assetdocument"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/AddCapitalAsset/Assetdocument/" + httpPostedFile.FileName;
                    AddCapitalAsset document = new AddCapitalAsset();
                    document.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    document.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    document.UploadAssetDocument = filPath;
                    sucess = BAL.SaveAssetDocument(document);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("InsuranceDocument")]
        public HttpResponseMessage saveInsuranceDocument()
        {
            string sucess = "";
            string responce = new CompanymasterController().deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "AddcapitalInsuranceDocument");

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/AddCapitalAsset/InsuranceDocument"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/AddCapitalAsset/InsuranceDocument/" + httpPostedFile.FileName;
                    AddCapitalAsset document = new AddCapitalAsset();
                    document.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    document.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    document.UploadInsuranceDocument = filPath;
                    sucess = BAL.SaveInsuranceDocument(document);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }


        #region getting the data for dropdowns

        [HttpGet]
        [Route("vendor")]
        public HttpResponseMessage GetVendordata(int CompanyId)
        {
            List<Vendor> List = new List<Vendor>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetVendordata(CompanyId));
        }

        [HttpGet]
        [Route("department")]
        public HttpResponseMessage GetDepartmentdata(int CompanyId)
        {
            List<Department> List = new List<Department>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetDepartmentdata(CompanyId));
        }
        [HttpGet]
        [Route("status")]
        public HttpResponseMessage GetStatus(int CompanyId)
        {
            List<AddassetStatus> List = new List<AddassetStatus>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetStatus(CompanyId));
        }
        [HttpGet]
        [Route("AssetFor")]
        public HttpResponseMessage GetAssetfordata(int CompanyId)
        {
            List<AssetFormodel> List = new List<AssetFormodel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetAssetfordata(CompanyId));
        }
        [HttpGet]
        [Route("Priority")]
        public HttpResponseMessage GetPrioritydata(int CompanyId)
        {
            List<PriorityModel> List = new List<PriorityModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetPrioritydata(CompanyId));
        }
        [HttpGet]
        [Route("AssetPriority")]
        public HttpResponseMessage GetAssetPrioritydata(int CompanyId)
        {
            List<AssetPrioritymodel> List = new List<AssetPrioritymodel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetAssetPrioritydata(CompanyId));
        }


        [Route("Locationclass")]
        public HttpResponseMessage GetLocationclass(int CompanyId)
        {
            List<Locationclass> List = new List<Locationclass>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetLocationclass(CompanyId));
        }



        [Route("AssetClass")]
        public HttpResponseMessage GetAssetClass(int CompanyId)
        {
            List<Locationclass> List = new List<Locationclass>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetAssetClass(CompanyId));
        }


        #endregion

    }
}
