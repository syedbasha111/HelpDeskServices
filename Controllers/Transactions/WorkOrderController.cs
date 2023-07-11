using HelpDeskServices.BusinessAccessLayer.Transaction;
using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.Controllers.Transactions
{
    [RoutePrefix("api/WorkOrder")]
    public class WorkOrderController : ApiController
    {
        WorkOrderBAL BAL = new WorkOrderBAL();
        [HttpPost]
        [Route("WorkOrder")] //Matches POST api/products
        public HttpResponseMessage CreateWorkOrder(Workorder request)
        {
            HD_BaseModel responce = new HD_BaseModel();
            string status = "";

            if (request.Id > 0)
            {
                status = BAL.updateWorkOrder(request);
                responce.Id = Convert.ToInt32(status);
                responce.status = responce.Id > 0 ? "Update" : null;
            }
            else
            {
                status = BAL.CreateWorkOrder(request);
                responce.Id = Convert.ToInt32(status);
                responce.status = responce.Id > 0 ? "Inserted" : null;
            }
            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();
            responce.WoIdExp = FOrExPression.autoIdFormat(Convert.ToInt32(request.ServiceReqId), request.CompanyId, "Workorder");

            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }

        [HttpPost]
        [Route("File")]
        public HttpResponseMessage saveFile()
        {
            string sucess = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/WorkOrderDocs"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/WorkOrderDocs/" + httpPostedFile.FileName;
                    RaiseService image = new RaiseService();
                    image.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    image.ImagePath = filPath;
                    sucess = BAL.SaveWorkOrderdocuments(image);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("UpdateFile")]
        public HttpResponseMessage UpdateWorkOrderFile()
        {
            string sucess = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {

                    string filPath = string.Empty;
                    string fileSavePath = string.Empty;

                    var httpPostedFile = HttpContext.Current.Request.Files[i];

                    fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Holiday/WorkOrderDocs"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                    filPath = "/Holiday/WorkOrderDocs/" + httpPostedFile.FileName;
                    RaiseService image = new RaiseService();
                    image.Id = Convert.ToInt32(HttpContext.Current.Request.Params["Id"]);
                    image.CompanyId = Convert.ToInt32(HttpContext.Current.Request.Params["CompanyId"]);
                    image.ImagePath = filPath;
                    sucess = BAL.UpdateWorkOrderFile(image);
                }
            }
            else
            {
                sucess = " not Saved";
            }

            return Request.CreateResponse(HttpStatusCode.OK, sucess);
        }

        [HttpPost]
        [Route("GetWorkOrder")] //Matches POST api/products
        public HttpResponseMessage GetWorkOrderDetails(RaiseService request)
        {
            List<Workorder> List = new List<Workorder>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWorkOrderDetails(request));
        }

        /// <summary>
        /// Get WO details Status Complete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetComapleteWorkOrder")]
        public HttpResponseMessage GetCompleteWorkOrder(RaiseService request)
        {
            List<Workorder> List = new List<Workorder>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetCompleteWorkOrder(request));
        }


        [HttpPost]
        [Route("GetWorkOrderForUpdate")] //Matches POST api/products
        public HttpResponseMessage GetWorkOrderDetailsForUpdate(RaiseService request)
        {
            List<Workorder> List = new List<Workorder>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWorkOrderDetailsForUpdate(request));
        }

        [HttpGet]
        [Route("GetWorkOrderBYId")] //Matches POST api/products
        public HttpResponseMessage getWorkOrderByid(int Id)
        {
            List<Workorder> List = new List<Workorder>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.getWorkOrderByid(Id));
        }

        [HttpGet]
        [Route("GetWorkOrderIMages")] //Matches POST api/products
        public HttpResponseMessage GetWorkOrderIMages(int Id,int RaiseId)
        {
            listofimages List = new listofimages();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWorkOrderImages(Id, RaiseId));
        }

        [HttpPost]
        [Route("RejectWorkOrder")]
        public HttpResponseMessage RejectWorkOrder(List<Workorder> request)
        {
            string responce = BAL.RejectWorkOrder(request);
            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }


        [HttpPost]
        [Route("DeleteWOIMage")]
        public HttpResponseMessage DeleteWOIMage(Workorder request)
        {
            string responce = BAL.DeleteWOIMage(request);
            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }

        [HttpGet]
        [Route("StatusMaster")]
        public HttpResponseMessage GetWOStatusMaster(int Id)
        {
            List<WorkOrderStatus> List = new List<WorkOrderStatus>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWOStatusMaster(Id));
        }

        //[HttpPost]
        //[Route("WoResourse")]
        //public HttpResponseMessage CreateWoResorce(List<WoResource> request, int Id)
        //{
        //    string status = BAL.CreateWoResorce(request, Id);
        //    return Request.CreateResponse(HttpStatusCode.OK, status);
        //}
        //[HttpPost]
        //[Route("WOAddItems")]
        //public HttpResponseMessage CreateWOAddItems(List<WoAddItems> request, int Id)
        //{
        //    string status = BAL.CreateWOAddItems(request, Id);
        //    return Request.CreateResponse(HttpStatusCode.OK, status);
        //}

        [HttpGet]
        [Route("GetWoChilddetails")]
        public HttpResponseMessage GetWOchilddetsils(int Id)
        {
            listofresourcesandspares List = new listofresourcesandspares();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWOchilddetsils(Id));
        }



        [HttpPost]
        [Route("DeleteWOResourse")]
        public HttpResponseMessage DeleteWoresourse(WoResource request)
        {
            string responce = BAL.DeleteWoresourse(request);
            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }

        [HttpPost]
        [Route("DeleteWOSpares")]
        public IHttpActionResult DeleteWoSpares(WoResource request)
        {
            return Ok(BAL.DeleteWoSpares(request));
        }

        [HttpPost]
        [Route("DeleteWOTools")]
        public IHttpActionResult DeleteWoTools(WoResource request)
        {
            return Ok(BAL.DeleteWoTools(request));
        }

        [HttpPost]
        [Route("DeleteWOConsumabels")]
        public IHttpActionResult DeleteWoConsumabels(WoResource request)
        {
            return Ok(BAL.DeleteWoConsumabels(request));
        }



        /// <summary>
        /// Create Work Order History
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WorkOrderHistory")]
        public HttpResponseMessage CreateWorkOrderHistory(WOHistory request)
        {
            HD_BaseModel responce = new HD_BaseModel();
            string status = "";
            status = BAL.CreateWorkOrderHistory(request);
            //responce.Id = Convert.ToInt32(status);
            responce.status = status;
            return Request.CreateResponse(HttpStatusCode.OK, responce);
        }

        [HttpGet]
        [Route("GetWorkOrderHistory")]
        public HttpResponseMessage GetWorkOrderHistoryDetails(int Id, int companyId)
        {
            List<WOHistory> List = new List<WOHistory>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetWorkOrderHistoryDetails(Id, companyId));
        }
        /// <summary>
        /// Get all resources and spares, tools,Consumabels
        /// </summary>
        /// <param name="Id">ServiceId</param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetResourcesAndSpares")]
        public IHttpActionResult getResourcesdata(int Id, int companyId)
        {
            listofresourcesandspares responce = new listofresourcesandspares();

            return Ok(responce = BAL.getResourcesdata(Id, companyId));
        }

        [HttpPost]
        [Route("resourcesSpares")]
        public IHttpActionResult AddWOChilddata(listofresourcesandspares request)
        {
            return Ok(BAL.AddWOChilddata(request));
        }

        [HttpPost]
        [Route("print")]
        public IHttpActionResult printWO(List<printdata> request)
        {
            foreach(var parentdata in request)
            {
                var foldername = "";
                
                var filename = parentdata.PrintList.servicename+parentdata.PrintList.WorkOrderId + ".pdf";
                if (parentdata.PrintList.servicename == "Electronics")
                {
                    //foldername = "Service";
                }

                if (parentdata.PrintList.WorKorderStatus == "Complete" )
                {
                    foldername = @"C:\" + @"Users_WO\WO_Complete\" + filename;
                }
                else if (parentdata.PrintList.WorKorderStatus == "Close")
                {
                    foldername = @"C:\" + @"Users_WO\WO_Close\" + filename;

                }
                else {
                    foldername = @"C:\" + @"Users_WO\WO_Created\" + filename;
                }

                //Wo resource and consume tools details
                listofresourcesandspares List = new listofresourcesandspares();
                List= BAL.GetWOchilddetsils(parentdata.PrintList.WorkOrderId);


                StringBuilder sb = new StringBuilder();
                sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
                //sb.Append("<div class='Panel' id='testcontent'>");
                //sb.Append("<table style='border:1px solid black;width:100%;'>");
                //sb.Append("<tr>");
                //sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
                ////sb.Append("<hr/>");
                //sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
                //sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
                //sb.Append("</tr>");
                //sb.Append("<tr>");
                //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
                //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
                //sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
                //sb.Append("</tr></table></div>");
                sb.Append("<table style='width:90%;padding:0px 15px;'><tr>");
                sb.Append("<td><h2>REQUEST</h2><h3>Date :" + parentdata.PrintList.ReceivedDateTime + "</h3></td>");
                sb.Append("<td><h3>Service:"+parentdata.PrintList.servicename+"</h3></td>");
                sb.Append("<td><h3>Request Ref :</h3></td>");
                sb.Append("</tr></table>");
                // //sb.Append("<hr>");
                sb.Append("<table style='width:100%;padding:0px 15px;'>");
                sb.Append("<tr><td style='width:50%;'><h2>PROBLEM DETAILS</h2><h3>Sub Service :"+ parentdata.PrintList.Subservicename+ "</h3><h3>Problem:" + parentdata.PrintList.Problemdesc + "</h3></td>");
                sb.Append("<td><h3>Location:"+ parentdata.PrintList.LocationName + "</h3></td></tr></table>");
                sb.Append("<table style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> WO ASSIGNMENTS </h3><h3 style='padding: 9px;margin: 0px 13px;'> Resources </h3></thead>");
                sb.Append("<tr><td> Resource Id </td><td> Resource Name </td><td> From Date </td><td> To Date </td><td> Remarks </td></tr>");
                if (List.ResourcesList.Count > 0)
                {
                    foreach (var resource in List.ResourcesList)
                    {
                        sb.Append("<tr><td>" + resource.Code + "</td><td>" + resource.Name + "</td><td>" + resource.Fromdate + "</td><td>" + resource.Todate + "</td><td>" + resource.Remarks + "</td></tr> ");
                    }
                }
                sb.Append("</table>");
                sb.Append("<table style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h2 style='padding: 9px;margin: 0px 13px;'> Spares </h2></thead><tr><td> Item Code </td><td> Description </td><td> Req Qty </td ><td> Consume Qty </td><td> Remarks </td></tr>");
                sb.Append("<tr><td></td><td></td><td></td><td></td><td></td></tr>");

                if (List.SparesList.Count > 0)
                {
                    foreach (var spares in List.SparesList)
                    {
                        sb.Append("<tr><td> "+spares.code+" </td><td> "+spares.Name+" </td><td> "+spares.ReqQuantity+" </td><td>"+spares.ConsumeQty+" </td><td>"+spares.Remarks+"</td></tr> ");
                    }
                }

                sb.Append("</table>");
                sb.Append("<table style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h2 style='padding: 9px;margin: 0px 13px;'> Tools </h2></thead><tr><td> Item Code </td><td> Description </td><td> Req Qty </td><td> Remarks </td></tr>");
                sb.Append("<tr><td></td><td></td><td></td><td></td></tr>");
                if(List.ToolsList.Count>0)
                {
                    foreach (var tools in List.ToolsList)
                    {
                        sb.Append("<tr><td> " + tools.code + " </td><td> " + tools.Name + " </td><td> " + tools.ReqQuantity + " </td><td>" + tools.Remarks + " </td></tr> ");

                    }
                }
                sb.Append("</table>");
                // //sb.Append("<hr>");
                sb.Append("<table style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h2 style='padding:9px;margin:0px 13px;'> Consumables </h2></thead><tr><td> Item Code </td><td> Description </td><td> Req Qty </td><td> Consume qty </td><td> Remarks </td></tr>");
                sb.Append("<tr><td></td><td></td><td></td><td></td><td></td></tr>");
                if (List.ConsumabelsList.Count > 0)
                {
                    foreach (var consume in List.ConsumabelsList)
                    {
                        sb.Append("<tr><td>"+consume.code+"</td><td>"+consume.Name+"</td><td>"+consume.ReqQuantity+"</td><td>"+consume.ConsumeQty+"</td><td>"+consume.Remarks+"</td></tr>");
                    }
                }
                sb.Append("</table>");
                //// sb.Append("<hr>");
                sb.Append("<table style='width: 97%;padding: 9px;margin: 0px 13px;'><thead><h2 style = 'padding: 9px;margin: 0px 13px;'> Job Status </h2></thead><tr><td> Completed :</td><td> (Y / N / D)(in %) :</td><td> Date :</td><td> Time :</td></tr><tr><td> Close :</td><td> (Y / N / D)(in %) : </td><td> Date : </td><td> Time :</td></tr><tr><td style = 'width:50%;' > Reason :</td><td> Name : Mahendar </td></tr>");
                sb.Append("<br/>");
                sb.Append("<tr><td> Name :" + parentdata.PrintList.AssignId + '/' + parentdata.PrintList.Assignto + "</td><td> Name :</td><td> Name :</td></tr><tr><td> Signature 1 :</td><td> Signature 2 :</td><td> Signature 3 :</td></tr></table>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                // //sb.Append("<hr>");
                sb.Append("<div style=' text-align: center;'><label style='font-size: 19px;font-weight: 550;'> Reason:1 = Mian </label><label style='font-size: 19px;font-weight: 550;'> power 2 = Spares </label><label style='font-size: 19px;font-weight: 550;'> 3 = Tools </label><label style='font-size: 19px;font-weight: 550;'> 4 = Access </label><label style='font-size: 19px;font-weight: 550;'> 5 = Availability </label><label style='font-size: 19px;font-weight: 550;'> 6 = Not In Use </label><label style='font-size: 19px;font-weight: 550;'> 7 = Rejected </label><label style='font-size: 19px;font-weight: 550;'> 8 = Not needed </label></div></td></tr></table>");


               // string htmlHeader = "<!DOCTYPE html><html><body><table style=\"width: 100%; border: 1px solid black;\"><tr><td>A</td><td>B</td></tr></table></body></html>";


                string header= "<!DOCTYPE html><html><body>";
                //header += "<div class='Panel' id='testcontent'>";
                header+= "<table style='width: 100%; border: 1px solid black;padding-reight: 15px;'>";
                header+="<tr>";
                header+="<td style='width:30%;'><img  alt='Empty' /></td>";
                header+="<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>";
                header+="<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>";
                header+="</tr>";
                header+="<tr>";
                header+="<td><h3>Reg No. :" + parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression + " </h3></td>";
                header+="<td style='text-align:center; '><h3>Site:" + parentdata.PrintList.Sitename + "</h3></td>";
                header+="<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>";
                header+= "</tr></table></body></html>";

                //=====================================

                try
                {
                    //Document pdfDoc = new Document(PageSize.A4);
                    Document pdfDoc = new Document(PageSize.A4, 4f, 4f, 118f,10f);
                    //Document pdfDoc = new Document(iTextSharp.text.PageSize.LEDGER, 10, 10, 42, 35);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        
                        StringReader sr = new StringReader(sb.ToString());

                        //PdfWriter wri = PdfWriter.GetInstance();
                        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(foldername, FileMode.Create));
                        // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(@"E:\"+ "Service"+"\"+"+ filename, FileMode.Create));
                        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(HttpContext.Current.Server.MapPath("~/Holiday/RasieServiceDocuments/"+ filename), FileMode.Create));

                        writer.PageEvent = new HtmlPageEventHelper(header);
                        pdfDoc.Open();
                        
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();

                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            
            return Ok();
        }


        [HttpPost]
        [Route("printraisereq")]
        public IHttpActionResult printRaisReq(List<printraiselist> request)
        {
            foreach (var parentdata in request)
            {
                var foldername = "";

                var filename = parentdata.raiselist.servicename + parentdata.raiselist.Id + ".pdf";

                foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;


                //Wo resource and consume tools details



                StringBuilder sb = new StringBuilder();
                sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");

                sb.Append("<table style='width:90%;padding:0px 15px;'><tr>");
                sb.Append("<td><h2>REQUEST</h2><h3>Date :" + parentdata.raiselist.ReceivedDateTime + "</h3></td>");
                sb.Append("<td><h3>Service:" + parentdata.raiselist.servicename + "</h3></td>");
                sb.Append("<td><h3>Request Ref :</h3></td>");
                sb.Append("</tr></table>");
                // //sb.Append("<hr>");
                sb.Append("<table style='width:100%;padding:0px 15px;'>");
                sb.Append("<tr><td style='width:50%;'><h2>PROBLEM DETAILS</h2><h3>Sub Service :" + parentdata.raiselist.Subservicename + "</h3><h3>Problem:" + parentdata.raiselist.Problemdesc + "</h3></td>");
                sb.Append("<td><h3>Location:" + parentdata.raiselist.Businessname + "</h3></td></tr></table>");

                //// sb.Append("<hr>");
                sb.Append("<table style='width: 97%;padding: 9px;margin: 0px 13px;'><thead><h2 style = 'padding: 9px;margin: 0px 13px;'> Job Status </h2></thead><tr><td> Completed :</td><td> (Y / N / D)(in %) :</td><td> Date :</td><td> Time :</td></tr><tr><td> Close :</td><td> (Y / N / D)(in %) : </td><td> Date : </td><td> Time :</td></tr><tr><td style = 'width:50%;' > Reason :</td><td> Name : Mahendar </td></tr>");
                sb.Append("<br/>");
                sb.Append("<tr><td> Name :"  + parentdata.raiselist.AssignTo + "</td><td> Name :</td><td> Name :</td></tr><tr><td> Signature 1 :</td><td> Signature 2 :</td><td> Signature 3 :</td></tr></table>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                // //sb.Append("<hr>");
                sb.Append("<div style=' text-align: center;'><label style='font-size: 19px;font-weight: 550;'> Reason:1 = Mian </label><label style='font-size: 19px;font-weight: 550;'> power 2 = Spares </label><label style='font-size: 19px;font-weight: 550;'> 3 = Tools </label><label style='font-size: 19px;font-weight: 550;'> 4 = Access </label><label style='font-size: 19px;font-weight: 550;'> 5 = Availability </label><label style='font-size: 19px;font-weight: 550;'> 6 = Not In Use </label><label style='font-size: 19px;font-weight: 550;'> 7 = Rejected </label><label style='font-size: 19px;font-weight: 550;'> 8 = Not needed </label></div></td></tr></table>");


                // string htmlHeader = "<!DOCTYPE html><html><body><table style=\"width: 100%; border: 1px solid black;\"><tr><td>A</td><td>B</td></tr></table></body></html>";


                string header = "<!DOCTYPE html><html><body>";
                //header += "<div class='Panel' id='testcontent'>";
                header += "<table style='width: 100%; border: 1px solid black;padding-reight: 15px;'>";
                header += "<tr>";
                header += "<td style='width:30%;'><img  alt='Empty' /></td>";
                header += "<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>";
                header += "<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>";
                header += "</tr>";
                header += "<tr>";
                header += "<td><h3>Reg No. :" + parentdata.raiselist.Expression + "</h3><h3>  Id No. :" + parentdata.raiselist.Id + " </h3></td>";
                header += "<td style='text-align:center; '><h3>Site:" + parentdata.raiselist.Sitename + "</h3></td>";
                header += "<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>";
                header += "</tr></table></body></html>";

                //=====================================

                try
                {
                    //Document pdfDoc = new Document(PageSize.A4);
                    Document pdfDoc = new Document(PageSize.A4, 2f, 2f, 118f, -118f);
                    //Document pdfDoc = new Document(iTextSharp.text.PageSize.LEDGER, 10, 10, 42, 35);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {

                        StringReader sr = new StringReader(sb.ToString());

                        //PdfWriter wri = PdfWriter.GetInstance();
                        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(foldername, FileMode.Create));
                        // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(@"E:\"+ "Service"+"\"+"+ filename, FileMode.Create));
                        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(HttpContext.Current.Server.MapPath("~/Holiday/RasieServiceDocuments/"+ filename), FileMode.Create));

                        writer.PageEvent = new HtmlPageEventHelper(header);
                        pdfDoc.Open();

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();

                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return Ok();
        }




      


    }
    public class printdata
    {
        public Workorder PrintList { get; set; }

    }
    public class printraiselist
    {
        public RaiseService  raiselist { get; set; }

    }


    public class HtmlPageEventHelper : PdfPageEventHelper
    {
        public HtmlPageEventHelper(string html)
        {
            this.html = html;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            ColumnText ct = new ColumnText(writer.DirectContent);
            XMLWorkerHelper.GetInstance().ParseXHtml(new ColumnTextElementHandler(ct), new StringReader(html));
           //ct.SetSimpleColumn(new Rectangle(39, 832, 559, -700));
            ct.SetSimpleColumn(5,5,590,835,0,Element.ALIGN_TOP);
            //ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-10), 0, Element.ALIGN_MIDDLE);
            ct.Go();
        }

        string html = null;
    }

    public class ColumnTextElementHandler : IElementHandler
    {
        public ColumnTextElementHandler(ColumnText ct)
        {
            this.ct = ct;
        }

        ColumnText ct = null;

        public void Add(IWritable w)
        {
            if (w is WritableElement)
            {
                foreach (IElement e in ((WritableElement)w).Elements())
                {
                    ct.AddElement(e);
                }
            }
        }
    }
}
