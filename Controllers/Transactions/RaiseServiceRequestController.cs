using HelpDeskServices.BusinessAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelpDeskServices.Controllers.Transactions
{
    [RoutePrefix("api/RaiseServiceRequest")]
    public class RaiseServiceRequestController : ApiController
    {
        RaiseserviceBAL BAL = new RaiseserviceBAL();
        /// <summary>
        /// Creating Raise Services
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RaiseService")]
        public HttpResponseMessage CreateRaiseService(RaiseService request)
        {
            
            HD_BaseModel responce = new HD_BaseModel();

            if (request.Id > 0)
            {
                responce.ServiceId = BAL.updateRaiseService(request);
                responce.status = "Updated";

            }
            else
            {
               responce.ServiceId = BAL.CreateRaiseService(request);
                responce.status = "Inserted";
            }

            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }

        [HttpPost]
        [Route("AssignList")]
        public HttpResponseMessage UpdateAssignList(List<RaiseService> request)
        {
            string status = "";
            status = BAL.UpdateAssignList(request);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }


        [HttpPost]
        [Route("File")]
        public HttpResponseMessage saveFile()
        {
            string sucess = "";
            //string responce = new CompanymasterController().deleteImages(Convert.ToInt32(HttpContext.Current.Request.Params["Id"]), "RaiseServiceFile");

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

              
                    string filPath = string.Empty;
                string fileSavePath = string.Empty;

                
                var httpPostedFile = HttpContext.Current.Request.Files[i];

                fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/RasieServiceDocuments"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);
                filPath = "/Holiday/RasieServiceDocuments/" + httpPostedFile.FileName;
                RaiseService image = new RaiseService();
                //File.Delete(filPath);
                image.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                image.ImagePath = filPath;
                sucess = BAL.SaveRaisedocumentPath(image);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("GetRaiseService")]
        public HttpResponseMessage getserviceRequestDetails(RaiseService request)
        {
            List<RaiseService> List = new List<RaiseService>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getserviceRequestDetails(request));
        }

        [HttpPost]
        [Route("GetAssigndata")]
        public HttpResponseMessage getAssignData(RaiseService request)
        {
            List<RaiseService> List = new List<RaiseService>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getAssignData(request));
        }

        [HttpPost]
        [Route("WObySRId")]
        public HttpResponseMessage getserviceRequestDetailsforWO(RaiseService request)
        {
            List<RaiseService> List = new List<RaiseService>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getserviceRequestDetailsforWO(request));
        }

        [HttpGet]
        [Route("GetRaiseServiceBYId")]
        public HttpResponseMessage getserviceRequestByid(int Id)
        {
            List<RaiseService> List = new List<RaiseService>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getserviceRequestByid(Id));
        }

        [HttpPost]
        [Route("updateGriddata")]
        public HttpResponseMessage Test(List<RaiseService> request)
        {
            string test = "";
            return Request.CreateResponse(HttpStatusCode.OK, test);
        }

        [HttpGet]
        [Route("GetRequestForm")]
        public HttpResponseMessage getRequestFormMaster()
        {
            List<RequestForm> List = new List<RequestForm>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getRequestFormMaster());
        }

        [HttpGet]
        [Route("GetSystem")]
        public HttpResponseMessage getSystemMaster()
        {
            List<SystemName> List = new List<SystemName>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getSystemMaster());
        }

        [HttpGet]
        [Route("GetSubSystem")]
        public HttpResponseMessage getSubSystemMaster()
        {
            List<SubSystem> List = new List<SubSystem>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getSubSystemMaster());
        }

        [HttpGet]
        [Route("LocationPriority")]
        public HttpResponseMessage GetLocationPriority()
        {
            List<Locationpriority> List = new List<Locationpriority>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetLocationPriority());
        }

        [HttpGet]
        [Route("ServicePriority")]
        public HttpResponseMessage GetServicePriority()
        {
            List<Servicepriority> List = new List<Servicepriority>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetServicePriority());
        }
        [HttpPost]
        [Route("assertLabel")]
        public HttpResponseMessage SaveAssertlabelId(List<AssertLabelModel> request)
        {
            string status = "";
            status = BAL.SaveAssertlabelId(request);
            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        [HttpGet]
        [Route("GetassertLabel")]
        public HttpResponseMessage GetassertLabelMaster()
        {
            List<AssertLabelModel> List = new List<AssertLabelModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetassertLabelMaster());
        }
        /// <summary>
        /// get aseert Id to generate AssertId in serivce request
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetassertLabelId")]
        public HttpResponseMessage GetassertLabelMasterId(int Id)
        {
            List<AssertLabelModel> List = new List<AssertLabelModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetassertLabelMasterId(Id));
        }

        [HttpGet]
        [Route("GetAssignList")]
        public HttpResponseMessage GetAssignList(int Id)
        {
            List<AssignRequest> List = new List<AssignRequest>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetassignList(Id));
        }



    }
}
