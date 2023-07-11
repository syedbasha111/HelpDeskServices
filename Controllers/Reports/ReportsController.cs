using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDeskServices.BusinessAccessLayer.Reports;
using HelpDeskServices.DataModels.Reports;
using System.Text;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline;
using HelpDeskServices.DataModels;
using System.Web;
using System.Threading.Tasks;

namespace HelpDeskServices.Controllers.Reports
{
    [RoutePrefix("api/Reports")]
    public class ReportsController : ApiController
    {
        Reportsclass BAL = new Reportsclass();

        #region CMPerformance Report
        [HttpPost]
        [Route("CMPerformsnce")]
        public HttpResponseMessage CMPerformanceReport(RaiseService request)
        {
            List<CM_Performance> List = new List<CM_Performance>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.CMPerformanceReport(request));
        }

        [HttpPost]
        [Route("Cm_Performance_PDF")]
        public IHttpActionResult printRaisReq(List<CM_Performance> request)
        {
            var foldername = "";

            var filename = "CM_performance.pdf";

            foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;


            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> CM-Performance Report </h3><h3 style='border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'>  </h3></thead>");
            sb.Append("<tr><td> Location </td><td> Service</td><td>Total </td><td> Request Submited </td><td> Create W.O </td><td> Complete W.O </td><td> Complete W.O % </td></tr>");
            CM_Performance total = new CM_Performance();

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.Location + "</td><td>" + Data.Service + "</td><td>" + Data.total + "</td><td>" + Data.ReqSubmited + "</td><td>" + Data.CreateWO + "</td><td>" + Data.CreateWO + "</td><td>" + Data.CloseWo + "</td><td>" + Data.CompletePercentage + "</td></tr> ");
                    total.total += Data.total;
                    total.ReqSubmited += Data.ReqSubmited;
                    total.CreateWO += Data.CreateWO;
                    total.CloseWo += Data.CloseWo;
                }
            }
            sb.Append("<tr style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><td></td><td>" + " Total" + "</td><td>" + total.total + "</td><td>" + total.ReqSubmited + "</td><td>" + total.CreateWO + "</td><td>" + total.CreateWO + "</td><td>" + total.CloseWo + "</td><td>" + total.CompletePercentage + "</td></tr> ");

            sb.Append("</table>");
          

            sb.Append("</td></tr></table>");



            try
            {
                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(foldername, FileMode.Create));
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();

            }
            catch (Exception ex)
            {
                throw;
            }


            return Ok();
        }

        public class CM_PerformanceList
        {
            public CM_Performance CM_Performance { get; set; }

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
                ct.SetSimpleColumn(new Rectangle(39, 832, 559, -700));
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

        #endregion
        #region  CM Status Details Report

        [HttpPost]
        [Route("CMstatusdetails")]
        public HttpResponseMessage CMStatusDetails(RaiseService request)
         {
            List<CM_status_details> List = new List<CM_status_details>();
            Common.InfoLogs("Cm Status Details");

            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.CMStatusDetails(request));

        }

        [HttpPost]
        [Route("Cmstatusdetails_pdf")]
        public IHttpActionResult printCMstatusdetails(List<CM_status_details> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date=  dateTime.ToString("ddMMyyyy");
            var filename = "CM_Status_details"+ date+".pdf";

           //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
           foldername = @"E:\" + @"Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table border='1' style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> CM-Status-Details Report </h3></thead>");
            sb.Append("<tr><td> Request Id </td><td> WO Id </td><td> Location </td><td> Service</td><td> Request Submited </td><td> Create W.O </td><td> Complete W.O </td><td> Close WO </td><td> Reject WO </td></tr>");

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.reqorderexp + "/"+Data.RequestID+ "</td><td>" + Data.workorderexp + "/" + Data.WOID + "</td><td>" + Data.Site + "</td><td>" + Data.Service + "</td><td>" + Data.RequestSubmitted + "</td><td>" + Data.WOCreated + "</td><td>" + Data.WOCompleted + "</td><td>" + Data.WOClosed + "</td><td>" + Data.WORejected + "</td></tr> ");
                  
                }
            }

            sb.Append("</table>");


            sb.Append("</td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


               // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
               PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Sucess"+filename+sb.ToString();

            }
            catch (Exception ex)
            {
               
                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception"+ ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }


        #endregion

        [HttpPost]
        [Route("CmperformancebySite")]
        public IHttpActionResult performancedatabySite(RaiseService request)
        {
            return Ok(BAL.performancedatabySite(request));
        }


        [HttpPost]
        [Route("CMperformancebysite_pdf")]
        public IHttpActionResult printCMperformancebysite(List<site_performance> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("ddMMyyyy");
            var filename = "CM_performancebySite" + date + ".pdf";

            //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
            foldername = @"Cs:\" + @"Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<div class='row'>");
            foreach (var responce1 in request)
            {
                sb.Append("<div class='col-md-12'> <table border='1' style='width: 100 %; margin - top: 10px; ' ><tr><th  colspan = '4' > Site </th>< th colspan = '8' >"+ responce1.SiteName + "</th></tr><tr><td  colspan = '4' > Service </ td > < td > Total </ td >< td > Request Submitted </ td > < td > Created W.O </ td >< td > Completed W.O </ td > < td > Percentage </ td ></ tr > ");
                foreach(var responce2 in responce1.Servicesdetails)
                {
                    sb.Append("<tr><td colspan='4'>"+responce2.ServiceName+"</td > < td >"+ responce2.CmPerformanceList.total+"</ td>< td >"+responce2.CmPerformanceList.ReqSubmited+"</ td > < td >"+ responce2.CmPerformanceList.CreateWO+"</ td >< td >"+responce2.CmPerformanceList.CloseWo+"</ td >< td >"+responce2.CmPerformanceList.CompletePercentage+"</ td ></ tr > ");
                }
                sb.Append("</table></div>");
            }


            sb.Append("</div></td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Success" + filename + sb.ToString();

            }
            catch (Exception ex)
            {

                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception" + ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }


        [HttpPost]
        [Route("pendingWo_Report")]
        public IHttpActionResult PendingWO_Report(pending_Wo_request request)
        {
            return Ok(BAL.PendingWO_Report(request));
        }


        [HttpPost]
        [Route("PendingWo_pdf")]
        public IHttpActionResult pendingWoreportpdf(List<pending_Wo_responce> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("ddMMyyyy");
            var filename = "PendingWO" + date + ".pdf";

            //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
            foldername = @"~/Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table border='1' style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> CM-Status-Details Report </h3></thead>");
            sb.Append("<tr><td> WO </td><td> System </td><td> Sub Sytem </td><td> Location</td><td>  Service</td><td> Start date Of </td><td> Hours Spent </td><td>Remarks  </td></tr>");

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.woexp + "/" + Data.WOId + "</td><td>" + Data.System + "/" + Data.SubSystem + "</td><td>" + Data.Locatoon + "</td><td>" + Data.Service + "</td><td>" + Data.Startdate + "</td><td>" + Data.Hoursspent + "</td><td>" + Data.Remarks + "</td></tr> ");

                }
            }

            sb.Append("</table>");


            sb.Append("</td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Sucess" + filename + sb.ToString();

            }
            catch (Exception ex)
            {

                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception" + ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }

        #region  Re-cap for Closed W.O.s

        [HttpPost]
        [Route("Re_cap_for_Closed_WO")]
        public IHttpActionResult RecapCloseWo_report(RaiseService request)
        {
            return Ok(BAL.RecapCloseWo_report(request));
        }

        [HttpPost]
        [Route("recapcompletWo_pdf")]
        public IHttpActionResult recapcompletWopdf(List<RE_cap_closeWO> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("ddMMyyyy");
            var filename = "PendingWO" + date + ".pdf";

            //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
            foldername = @"~/Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table border='1' style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> Re-cap complete W.O </h3></thead>");
            sb.Append("<tr><td> W.O. </td><td> P.M.Group </td><td> Equipment  </td><td> Job description</td><td>  Requested service</td><td> Start date of Work order </td><td> Executed Date </td><td>Hours Spent  </td></tr>");

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.woexp + "/" + Data.Id + "</td><td></td><td>" + Data.Subsystem + "</td><td></td><td>" + Data.Service + "</td><td>" + Data.StartWODate + "</td><td>" + Data.ExecutedDate + "</td><td></td></tr> ");

                }
            }

            sb.Append("</table>");


            sb.Append("</td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Sucess" + filename + sb.ToString();

            }
            catch (Exception ex)
            {

                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception" + ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }


        #endregion

        #region  Key Performance Index report

        [HttpPost]
        [Route("Key_Performance_Index_report")]
        public IHttpActionResult Key_Performance_report(RaiseService request)
        {
            return Ok(BAL.Key_Performance_report(request));
        }

        [HttpPost]
        [Route("Key_Performance_pdf")]
        public IHttpActionResult Key_Performancepdf(List<Keyperformance> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("ddMMyyyy");
            var filename = "PendingWO" + date + ".pdf";

            //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
            foldername = @"~/Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table border='1' style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> Re-cap complete W.O </h3></thead>");
            sb.Append("<tr><td> service </td><td> Total P.M.W.O.s </td><td> Completed  </td><td> Total Estimated Hrs</td><td>  Total actual Spent Hours</td><td> % of Spent Hours </td><td> %of Completed W.Os </td><td>Year/month  </td></tr>");

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.Service  + "</td><td>" + Data.ToatalWO + "</td><td>" + Data.ComapletedWO + "</td><td></td><td></td><td></td><td></td><td>" + Data.year+"/"+Data.month+"</td></tr> ");

                }
            }

            sb.Append("</table>");


            sb.Append("</td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Sucess" + filename + sb.ToString();

            }
            catch (Exception ex)
            {

                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception" + ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }

        #endregion

        #region  Reports by technician

        [HttpPost]
        [Route("ReportbyTechnician")]
        public async Task<IEnumerable<Workorder>> ReportByTechnician(allassetsreq request)
        {
            return await BAL.ReportByTechnician(request);
        }

        [HttpPost]
        [Route("ReportbyTechnician_pdf")]
        public IHttpActionResult ReportbyTechnicianpdf(List<Workorder> request)
        {

            Common.InfoLogs("Pdf method started " + request);

            HD_BaseModel RESPONCE = new HD_BaseModel();
            var foldername = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("ddMMyyyy");
            var filename = "PendingWO" + date + ".pdf";

            //foldername = @"C:\" + @"Users_WO\RaiseReq\" + filename;
            foldername = @"~/Users_WO\RaiseReq\" + filename;
            Common.InfoLogs("Folder Path " + foldername);



            //Wo resource and consume tools details



            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='border:1px solid black;width:100%;'><tr><td>");
            sb.Append("<div class='Panel' id='testcontent'>");
            sb.Append("<table style='border:1px solid black;width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td style='width:30%;'><img  alt='Empty' /></td>");
            //sb.Append("<hr/>");
            sb.Append("<td style='text-align:center;width:30%'><h1>QuickFMS</h1></td>");
            sb.Append("<td style='width:30%;'><h4 style='padding:9px;'>CM Work Order</h4></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            //sb.Append("<td><h3>Reg No. :"+ parentdata.PrintList.ServiceIdFormat + "</h3><h3> WO Id No. :" + parentdata.PrintList.Expression+" </h3></td>");
            //sb.Append("<td style='text-align:center; '><h3>Site:"+ parentdata.PrintList.Sitename+"</h3></td>");
            sb.Append("<td style='width:19%;'><h3>Start Date :</h3><h3> Time : </h3></td>");
            sb.Append("</tr></table></div>");
            // //sb.Append("<hr>");
            sb.Append("<table border='1' style='width: 97%;border-top: 1px solid #d4d2d2!important;padding: 9px;margin: 0px 13px;'><thead><h3> Re-cap complete W.O </h3></thead>");
            sb.Append("<tr><td> service </td><td> WO Id </td><td> Assign to  </td><td> Requester Name</td><td>  Request from Name</td><td> Site name </td><td> Business Unit </td><td>Problemdesc  </td></tr>");

            if (request.Count > 0)
            {

                foreach (var Data in request)
                {
                    sb.Append("<tr><td>" + Data.Service + "</td><td>"+Data.WorkOrderId+"</td><td>"+Data.Assignto + "</td><td>"+Data.RequesterName + "</td><td>"+Data.RequestfromName + "</td><td>"+Data.Sitename + "</td><td>"+Data.Businessname + "</td><td>"+Data.Problemdesc + "</td></tr> ");

                }
            }

            sb.Append("</table>");


            sb.Append("</td></tr></table>");



            try
            {
                Common.InfoLogs("pdf functionality start ");

                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream( foldername, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("C:/Users_WO/RaiseReq/" + filename, FileMode.Create));

                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                RESPONCE.status = "Sucess" + filename + sb.ToString();

            }
            catch (Exception ex)
            {

                RESPONCE.status = ex.Message.ToString();
                Common.InfoLogs("Exxception" + ex.Message.ToString());

            }


            return Ok(RESPONCE);
        }


        #endregion


        #region  Customized reports
        [HttpPost]
        [Route("CustomizedReports")]
        public async Task<IEnumerable<Workorder>> CustomizedReports(allassetsreq request)
        {
            return await BAL.CustomizedReports(request);
        }


        #endregion

        #region  TAT reports
        [HttpPost]
        [Route("TATReports")]
        public async Task<IEnumerable<TATResponce>> TATReports(allassetsreq request)
        {
            return await BAL.TATReports(request);
        }


        #endregion



        #region  Daily Operation Room Report
        [HttpPost]
        [Route("DailyOperationReports")]
        public async Task<IEnumerable<object>> DailyOperationReports(allassetsreq request)
        {
            return await BAL.DailyOperationReports(request);
        }


        #endregion



    }
}