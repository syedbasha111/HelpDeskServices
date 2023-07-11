using AutoMapper;
using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Reports;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HelpDeskServices.DataAccessLayer.Reports
{
    public class ReportsDALClass
    {

        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public List<CM_Performance> CMPerformanceReport(RaiseService request)
        {
            // return DAL.GetWorkOrderDetails(obj);

            List<CM_Performance> baseModel = new List<CM_Performance>();

            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            if (request.fromdate == Convert.ToDateTime("01-01-0001") || request.todate == Convert.ToDateTime("01-01-0001"))
            {
                request.fromdate = null;//Convert.ToDateTime("01-10-1753");
                request.todate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataSet dt = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BussinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Problem", request.Problem);
                        cmd.Parameters.AddWithValue("@SubService ", request.SubService);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Tables.Count > 0)
                        {
                            DataTable wototalcount = dt.Tables[0];
                            DataTable RaisereqTotalcount = dt.Tables[1];
                            DataTable Wopending = dt.Tables[2];
                            DataTable WoComplete = dt.Tables[3];
                            DataTable Raisereqcreate = dt.Tables[4];
                            DataTable servicedetails = dt.Tables[5];

                            List<MyObj> reqtotalmodel = ConvertDtToModel(RaisereqTotalcount);
                            List<MyObj> WoTotalmodel = ConvertDtToModel(wototalcount);
                            List<MyObj> WopendingModel = ConvertDtToModel(Wopending);
                            List<MyObj> WoCompleteModel = ConvertDtToModel(WoComplete);
                            List<MyObj> RaisereqcreateModel = ConvertDtToModel(Raisereqcreate);
                            List<MyObj> servicedetailsmodel = Convertservicemodel(servicedetails);

                            foreach (var servicedata in servicedetailsmodel)
                            {
                                CM_Performance responce = new CM_Performance();
                                responce.Service = servicedata.ServiceDescription;
                                responce.Location = servicedata.Description;

                                var reqmodelcount = reqtotalmodel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                                responce.total = reqmodelcount != null ? reqmodelcount.total : 0;


                                var Wotoatalcount = WoTotalmodel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                                responce.total = Wotoatalcount != null ? responce.total + Wotoatalcount.total : 0;


                                var wopendingCount = WopendingModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                                responce.CreateWO = wopendingCount != null ? wopendingCount.total : 0;


                                var wocloseCount = WoCompleteModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                                if (wocloseCount != null)
                                {
                                    responce.CloseWo = wocloseCount.total;
                                    if (Convert.ToInt32(responce.total) > 0)
                                    {

                                        responce.CompletePercentage = Math.Round((wocloseCount.total / responce.total) * 100);
                                    }
                                }

                                var Raiserequestcount = RaisereqcreateModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();

                                responce.ReqSubmited = Raiserequestcount != null ? Raiserequestcount.total : 0;


                                baseModel.Add(responce);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return baseModel;
        }


        private List<MyObj> ConvertDtToModel(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new MyObj()
                                 {
                                     ID = Convert.ToInt32(rw["ID"]),
                                     ServiceDescription = Convert.ToString(rw["ServiceDescription"]),
                                     total = Convert.ToDecimal(rw["total"])
                                 }).ToList();

            return convertedList;
        }
        private List<MyObj> Convertservicemodel(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new MyObj()
                                 {
                                     ID = Convert.ToInt32(rw["ID"]),
                                     ServiceDescription = Convert.ToString(rw["ServiceDescription"]),
                                     Description = Convert.ToString(rw["Description"]),
                                 }).ToList();

            return convertedList;
        }

        public List<CM_status_details> CMStatusDetails(RaiseService request)
        {

            List<CM_status_details> baseModel = new List<CM_status_details>();

            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            if (request.fromdate == Convert.ToDateTime("01-01-0001") || request.todate == Convert.ToDateTime("01-01-0001"))
            {
                request.fromdate = null;//Convert.ToDateTime("01-10-1753");
                request.todate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BussinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Problem", request.Problem);
                        cmd.Parameters.AddWithValue("@SubService ", request.SubService);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                CM_status_details responce = new CM_status_details();

                                responce.RequestID = Convert.ToInt32(dr["Id"]);
                                responce.WOID = Convert.ToInt32(dr["WOId"]);
                                responce.Requester = dr["RequesterName"].ToString();
                                responce.ReceivedDate = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                responce.Site = dr["SiteName"].ToString();
                                responce.BusinessUnit = dr["Description"].ToString();
                                responce.Service = dr["ServiceDescription"].ToString();
                                responce.SubService = dr["SubServiceDescription"].ToString();
                                responce.Status = dr["Status"].ToString();
                                responce.ReceivedBy = dr["FormName"].ToString();
                                responce.System = dr["SystemName"].ToString();
                                responce.SubSystem = dr["SubSystemName"].ToString();
                                responce.ProblemDesc = dr["ProblemDescription"].ToString();
                                responce.Zone = dr["ZoneName"].ToString();
                                responce.Building = dr["BuildingName"].ToString();
                                responce.Floor = dr["FloorName"].ToString();
                                responce.Area = dr["AreaName"].ToString();
                                responce.Room = dr["RoomName"].ToString();
                                responce.AssignedTo = dr["Assign"].ToString();
                                responce.workorderexp = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "Workorder");
                                responce.reqorderexp = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "ServiceRequest");

                                DataTable historydetails = WOHistorydetails(responce.RequestID);
                                if (historydetails.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in historydetails.Rows)
                                    {
                                        int statuscode = Convert.ToInt32(dr1["workorderStatus"]);

                                        switch (statuscode)
                                        {
                                            case 8:
                                                responce.RequestSubmitted = dr1["CreatedOn"].ToString();
                                                break;
                                            case 7:
                                                responce.ProceedforWOCreation = dr1["CreatedOn"].ToString();
                                                break;
                                            case 3:
                                                responce.WOCreated = dr1["CreatedOn"].ToString();
                                                if (statuscode == 1 || statuscode == 2 || statuscode == 3)
                                                {
                                                    responce.WOInProgress = dr1["CreatedOn"].ToString();
                                                }
                                                break;
                                            case 6:
                                                responce.WOCompleted = dr1["CreatedOn"].ToString();
                                                break;
                                            case 9:
                                                responce.WOClosed = dr1["CreatedOn"].ToString();
                                                break;
                                            case 10:
                                                responce.WORejected = dr1["CreatedOn"].ToString();
                                                break;
                                        }


                                        //responce.RequestSubmitted =Convert.ToInt32(dr["workorderStatus"])==8 ? (dr["CreatedOn"].ToString()) : string.Empty;

                                    }

                                }
                                baseModel.Add(responce);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return baseModel;
        }
        internal DataTable WOHistorydetails(int serviceReqId)
        {
            DataTable dt = new DataTable();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", serviceReqId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public CM_Performance databyservice(RaiseService request)
        {
            CM_Performance responce = new CM_Performance();

            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            if (request.fromdate == Convert.ToDateTime("01-01-0001") || request.todate == Convert.ToDateTime("01-01-0001"))
            {
                request.fromdate = null;//Convert.ToDateTime("01-10-1753");
                request.todate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataSet dt = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Tables.Count > 0)
                        {
                            DataTable wototalcount = dt.Tables[0];
                            DataTable RaisereqTotalcount = dt.Tables[1];
                            DataTable Wopending = dt.Tables[2];
                            DataTable WoComplete = dt.Tables[3];
                            DataTable Raisereqcreate = dt.Tables[4];
                            //DataTable servicedetails = dt.Tables[5];

                            List<MyObj> reqtotalmodel = ConvertDtToModel(RaisereqTotalcount);
                            List<MyObj> WoTotalmodel = ConvertDtToModel(wototalcount);
                            List<MyObj> WopendingModel = ConvertDtToModel(Wopending);
                            List<MyObj> WoCompleteModel = ConvertDtToModel(WoComplete);
                            List<MyObj> RaisereqcreateModel = ConvertDtToModel(Raisereqcreate);
                            // List<MyObj> servicedetailsmodel = Convertservicemodel(servicedetails);



                            responce.total = reqtotalmodel.Count > 0 ? (reqtotalmodel[0].total) : 0;
                            responce.total = WoTotalmodel.Count > 0 ? (responce.total + WoTotalmodel[0].total) : 0;
                            responce.CreateWO = WopendingModel.Count > 0 ? (WopendingModel[0].total) : 0;
                            responce.CloseWo = WoCompleteModel.Count > 0 ? (WoCompleteModel[0].total) : 0;
                            responce.ReqSubmited = RaisereqcreateModel.Count > 0 ? (RaisereqcreateModel[0].total) : 0;
                            responce.CompletePercentage = responce.total != 0 && responce.total != null ? Math.Round((responce.CloseWo / responce.total) * 100) : 0;


                            //var reqmodelcount = reqtotalmodel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                            //responce.total = reqmodelcount != null ? reqmodelcount.total : 0;


                            //var Wotoatalcount = WoTotalmodel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                            //responce.total = Wotoatalcount != null ? responce.total + Wotoatalcount.total : 0;


                            //var wopendingCount = WopendingModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                            //responce.CreateWO = wopendingCount != null ? wopendingCount.total : 0;


                            //var wocloseCount = WoCompleteModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();
                            //if (wocloseCount != null)
                            //{
                            //    responce.CloseWo = wocloseCount.total;
                            //    if (Convert.ToInt32(responce.total) > 0)
                            //    {

                            //        responce.CompletePercentage = Math.Round((wocloseCount.total / responce.total) * 100);
                            //    }
                            //}

                            //var Raiserequestcount = RaisereqcreateModel.Where(x => x.ID == servicedata.ID).FirstOrDefault();

                            //responce.ReqSubmited = Raiserequestcount != null ? Raiserequestcount.total : 0;


                            //baseModel.Add(responce);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return responce;

        }


        public List<site_performance> performancedatabySite(RaiseService request)
        {

            SiteMasterDAL Sitedal = new SiteMasterDAL();
            MasterServiceDAL ServiceDAL = new MasterServiceDAL();
            List<SiteMasterModel> Sitelist = Sitedal.GetSiteMaster(request.CompanyId);
            List<ServiceObject> ServiceList = ServiceDAL.GetServiceUnit(request.CompanyId);

            List<site_performance> baseresult = new List<site_performance>();

            foreach (var site in Sitelist)
            {

                site_performance sitechildresults = new site_performance();
                List<service_performance> result = new List<service_performance>();

                foreach (var Service in ServiceList)
                {

                    service_performance servicechildresult = new service_performance();
                    request.Site = site.ID;
                    request.Service = Service.ServiceID;
                    CM_Performance report = databyservice(request);
                    servicechildresult.ServiceName = Service.ServiceDescription;
                    servicechildresult.CmPerformanceList = report;
                    result.Add(servicechildresult);

                }
                service_performance servicechildresult1 = new service_performance();
                CM_Performance Totalreport = gettotalrecords(result);
                servicechildresult1.CmPerformanceList = Totalreport;
                servicechildresult1.ServiceName = "Total";
                result.Add(servicechildresult1);
                sitechildresults.SiteName = site.SiteName;
                sitechildresults.Servicesdetails = result;
                baseresult.Add(sitechildresults);
            }



            return baseresult;
        }

        public CM_Performance gettotalrecords(List<service_performance> request)
        {
            CM_Performance responce = new CM_Performance();

            foreach (var data in request)
            {
                responce.total += data.CmPerformanceList.total;
                responce.ReqSubmited += data.CmPerformanceList.ReqSubmited;
                responce.CreateWO += data.CmPerformanceList.CreateWO;
                responce.CloseWo += data.CmPerformanceList.CloseWo;
            }
            responce.CompletePercentage = responce.total != 0 && responce.total != null ? Math.Round((responce.CloseWo / responce.total) * 100) : 0;


            return responce;
        }



        public List<pending_Wo_responce> PendingWO_Report(pending_Wo_request request)
        {
            //  List<pending_Wo_responce> responce = new List<pending_Wo_responce>();
            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            if (request.FromDate == Convert.ToDateTime("01-01-0001") || request.ToDate == Convert.ToDateTime("01-01-0001"))
            {
                request.FromDate = null;//Convert.ToDateTime("01-10-1753");
                request.ToDate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Site", request.locationId);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BusinessId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@fromdate", request.FromDate);
                        cmd.Parameters.AddWithValue("@todate", request.ToDate);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            var childresponce = (from rw in dt.AsEnumerable()
                                                 select new pending_Wo_responce()
                                                 {
                                                     woexp = FOrExPression.autoIdFormat(Convert.ToInt32(rw["ServiceReqId"]), request.CompanyId, "Workorder"),
                                                     System = Convert.ToString(rw["System"]),
                                                     SubSystem = Convert.ToString(rw["SubSystem"]),
                                                     Locatoon = Convert.ToString(rw["sitename"]),
                                                     Service = Convert.ToString(rw["servicedescription"]),
                                                     Remarks = Convert.ToString(rw["Remarks"]),
                                                     Startdate = Convert.ToString(rw["createdOn"]),
                                                     WOId = Convert.ToString(rw["Id"])

                                                 }).ToList();

                            return childresponce;

                        }



                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }


        public List<RE_cap_closeWO> RecapCloseWo_report(RaiseService request)
        {
            List<RE_cap_closeWO> baseModel = new List<RE_cap_closeWO>();

            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            if (request.fromdate == Convert.ToDateTime("01-01-0001") || request.todate == Convert.ToDateTime("01-01-0001"))
            {
                request.fromdate = null;//Convert.ToDateTime("01-10-1753");
                request.todate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BussinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Problem", request.Problem);
                        cmd.Parameters.AddWithValue("@SubService ", request.SubService);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new RE_cap_closeWO()
                                                 {
                                                     Id = (rw["Id"]).ToString(),
                                                     woexp = FOrExPression.autoIdFormat(Convert.ToInt32(rw["reqid"]), request.CompanyId, "Workorder"),
                                                     Subsystem = Convert.ToString(rw["subsystem"]),
                                                     Service = (rw["servicedescription"]).ToString(),
                                                     StartWODate = (rw["modifiedOn"]).ToString(),
                                                     ExecutedDate = (rw["createdon"]).ToString()
                                                 }).ToList();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public List<Keyperformance> Key_Performance_report(RaiseService request)
        {
            List<Keyperformance> baseModel = new List<Keyperformance>();


            if (request.fromdate == Convert.ToDateTime("01-01-0001") || request.todate == Convert.ToDateTime("01-01-0001"))
            {
                request.fromdate = null;//Convert.ToDateTime("01-10-1753");
                request.todate = null;// Convert.ToDateTime("01-10-1753");
            }
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-CMPerformance]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BussinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Problem", request.Problem);
                        cmd.Parameters.AddWithValue("@SubService ", request.SubService);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new Keyperformance()
                                                 {
                                                     Service = (rw["ServiceDescription"]).ToString(),
                                                     ToatalWO = (rw["total"]).ToString(),
                                                     ComapletedWO = Convert.ToString(rw["closerecords"]),
                                                     year = (rw["year"]).ToString(),
                                                     month = (rw["month"]).ToString(),
                                                 }).ToList();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }


        public IEnumerable<Workorder> ReportByTechnician(allassetsreq req)
        {
            List<Workorder> baseModel = new List<Workorder>();
            RaiseServiceDAL format = new RaiseServiceDAL();

            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Reports]", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@location", req.Locations);
                        cmd.Parameters.AddWithValue("@Companyid", req.Companyid);
                        cmd.Parameters.AddWithValue("@zone", req.Zone);
                        cmd.Parameters.AddWithValue("@building", req.Building);
                        cmd.Parameters.AddWithValue("@Business", req.Businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.system);
                        cmd.Parameters.AddWithValue("@Floorreq", req.Floor);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsystem);
                        cmd.Parameters.AddWithValue("@Employee", req.Employeelist);
                        cmd.Parameters.AddWithValue("@pageno", req.Pageno);
                        cmd.Parameters.AddWithValue("@pagesize", req.pagesize);

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {

                            IEnumerable<Workorder> convertedList = (from rw in dt.AsEnumerable()
                                                                    select new Workorder()
                                                                    {
                                                                        Id = Convert.ToInt32(rw["Id"]),
                                                                        WorkOrderId = Convert.ToInt32(rw["WOId"]),
                                                                        RequesterName = rw["RequesterName"].ToString(),
                                                                        ReceivedDateTime = Convert.ToDateTime(rw["ReceivedDateTime"].ToString()),
                                                                        Sitename = rw["SiteName"].ToString(),
                                                                        Businessname = rw["Description"].ToString(),
                                                                        servicename = rw["ServiceDescription"].ToString(),
                                                                        Subservicename = rw["SubServiceDescription"].ToString(),
                                                                        WorKorderStatus = rw["Status"].ToString(),
                                                                        //bool Test = rw["ModifiedOn"].Equals(DBNull.Value),

                                                                        CloseStatus = rw["CloseStatus"].ToString(),

                                                                        // data.ModifiedOn = (rw["ModifiedOn"].Equals(DBNull.Value)) ? null : (Convert.ToDateTime(rw["ModifiedOn"])),
                                                                        LocationName = rw["LocationName"].ToString(),
                                                                        Problemdesc = rw["ProblemDescription"].ToString(),
                                                                        Systemaname = rw["SystemName"].ToString(),
                                                                        SubSystemName = rw["SubSystemName"].ToString(),
                                                                        RequestfromName = rw["FormName"].ToString(),
                                                                        UniqueAssetId = (rw["UniqueAssetId"]).ToString(),
                                                                        Assignto = (rw["Assign"]).ToString(),
                                                                        AssignId = (rw["AssignId"]).ToString(),
                                                                        Isdownload = rw["IsDownload"].Equals(DBNull.Value) ? false : Convert.ToBoolean(rw["IsDownload"]),

                                                                        Expression = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "Workorder"),
                                                                        ServiceIdFormat = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "ServiceRequest"),

                                                                    }).ToList().Distinct();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return baseModel;
        }

        public IEnumerable<Workorder> CustomizedReports(allassetsreq req)
        {
            List<Workorder> baseModel = new List<Workorder>();
            RaiseServiceDAL format = new RaiseServiceDAL();

            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Reports]", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@location", req.Locations);
                        cmd.Parameters.AddWithValue("@Companyid", req.Companyid);
                        cmd.Parameters.AddWithValue("@zone", req.Zone);
                        cmd.Parameters.AddWithValue("@building", req.Building);
                        cmd.Parameters.AddWithValue("@Business", req.Businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.system);
                        cmd.Parameters.AddWithValue("@Floorreq", req.Floor);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsystem);
                        cmd.Parameters.AddWithValue("@Employee", req.Employeelist);
                        cmd.Parameters.AddWithValue("@pageno", req.Pageno);
                        cmd.Parameters.AddWithValue("@pagesize", req.pagesize);

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {

                            IEnumerable<Workorder> convertedList = (from rw in dt.AsEnumerable()
                                                                    select new Workorder()
                                                                    {
                                                                        Id = Convert.ToInt32(rw["Id"]),
                                                                        WorkOrderId = Convert.ToInt32(rw["WOId"]),
                                                                        RequesterName = rw["RequesterName"].ToString(),
                                                                        ReceivedDateTime = Convert.ToDateTime(rw["ReceivedDateTime"].ToString()),
                                                                        Sitename = rw["SiteName"].ToString(),
                                                                        Businessname = rw["Description"].ToString(),
                                                                        servicename = rw["ServiceDescription"].ToString(),
                                                                        Subservicename = rw["SubServiceDescription"].ToString(),
                                                                        WorKorderStatus = rw["Status"].ToString(),
                                                                        //bool Test = rw["ModifiedOn"].Equals(DBNull.Value),

                                                                        CloseStatus = rw["CloseStatus"].ToString(),

                                                                        // data.ModifiedOn = (rw["ModifiedOn"].Equals(DBNull.Value)) ? null : (Convert.ToDateTime(rw["ModifiedOn"])),
                                                                        LocationName = rw["LocationName"].ToString(),
                                                                        Problemdesc = rw["ProblemDescription"].ToString(),
                                                                        Systemaname = rw["SystemName"].ToString(),
                                                                        SubSystemName = rw["SubSystemName"].ToString(),
                                                                        RequestfromName = rw["FormName"].ToString(),
                                                                        UniqueAssetId = (rw["UniqueAssetId"]).ToString(),
                                                                        Assignto = (rw["Assign"]).ToString(),
                                                                        AssignId = (rw["AssignId"]).ToString(),
                                                                        Isdownload = rw["IsDownload"].Equals(DBNull.Value) ? false : Convert.ToBoolean(rw["IsDownload"]),

                                                                        Expression = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "Workorder"),
                                                                        ServiceIdFormat = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "ServiceRequest"),

                                                                    }).ToList().Distinct();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return baseModel;
        }


        public IEnumerable<TATResponce> TATReports(allassetsreq req)
        {
            List<TATResponce> baseModel = new List<TATResponce>();
            RaiseServiceDAL format = new RaiseServiceDAL();

            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Reports]", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@location", req.Locations);
                        cmd.Parameters.AddWithValue("@Companyid", req.Companyid);
                        cmd.Parameters.AddWithValue("@zone", req.Zone);
                        cmd.Parameters.AddWithValue("@building", req.Building);
                        cmd.Parameters.AddWithValue("@Business", req.Businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.system);
                        cmd.Parameters.AddWithValue("@Floorreq", req.Floor);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsystem);
                        cmd.Parameters.AddWithValue("@Employee", req.Employeelist);
                        cmd.Parameters.AddWithValue("@pageno", req.Pageno);
                        cmd.Parameters.AddWithValue("@pagesize", req.pagesize);
                        cmd.Parameters.AddWithValue("@fromdate", req.fromdate);
                        cmd.Parameters.AddWithValue("@todate", req.todate);

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {

                            IEnumerable<TATResponce> convertedList = (from rw in dt.AsEnumerable()
                                                                      select new TATResponce()
                                                                      {
                                                                          Format = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "ServiceRequest"),
                                                                          Reqid = rw["Id"].ToString(),
                                                                          Status = returnstatus(rw),
                                                                          Remarks = returnremark(rw)
                                                                      }).ToList().Distinct();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return baseModel;
        }


        public IEnumerable<object> DailyOperationReports(allassetsreq req)
        {
            List<TATResponce> baseModel = new List<TATResponce>();
            RaiseServiceDAL format = new RaiseServiceDAL();

            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Reports]", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@location", req.Locations);
                        cmd.Parameters.AddWithValue("@Companyid", req.Companyid);
                        cmd.Parameters.AddWithValue("@zone", req.Zone);
                        cmd.Parameters.AddWithValue("@building", req.Building);
                        cmd.Parameters.AddWithValue("@Business", req.Businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.system);
                        cmd.Parameters.AddWithValue("@Floorreq", req.Floor);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsystem);
                        cmd.Parameters.AddWithValue("@Employee", req.Employeelist);
                        cmd.Parameters.AddWithValue("@pageno", req.Pageno);
                        cmd.Parameters.AddWithValue("@pagesize", req.pagesize);
                        cmd.Parameters.AddWithValue("@fromdate", req.fromdate);
                        cmd.Parameters.AddWithValue("@todate", req.todate);

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {

                            var convertedList = (from rw in dt.AsEnumerable()
                                                    select new 
                                                    {
                                                        Expression = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "Workorder"),
                                                        ServiceIdFormat = format.autoIdFormat(Convert.ToInt32(rw["Id"]), Convert.ToInt32(req.Companyid), "ServiceRequest"),
                                                        Reqfromname= rw["FormName"].ToString(),
                                                        RefWOId= rw["RefWOId"].ToString(),
                                                        UniqueAssetId= rw["UniqueAssetId"].ToString(),
                                                        System= rw["System"].ToString(),
                                                        SubSystem = rw["SubSystem"].ToString(),
                                                        BuildingCode = rw["BuildingCode"].ToString(),
                                                        ServiceDescription = rw["ServiceDescription"].ToString(),
                                                        RequestReceivedby = rw["RequestReceivedby"].ToString(),
                                                        ReceivedDateTime = rw["ReceivedDateTime"].ToString(),
                                                        ReportingDateTime = rw["ReportingDateTime"].ToString(),
                                                        ProblemCode = rw["ProblemCode"].ToString(),
                                                        ProblemDescription = rw["ProblemDescription"].ToString(),
                                                        SiteName = rw["SiteName"].ToString(),
                                                        Locationpriority = rw["Location"].ToString(),
                                                        Servicepriority = rw["Service"].ToString(),
                                                        CreatedOn = rw["CreatedOn"].ToString(),
                                                        ModifiedOn = rw["ModifiedOn"].ToString(),
                                                        WoID = rw["ServiceReqId"].ToString(),
                                                        Reqid = rw["Id"].ToString(),
                                                        WOStatus  = returnstatus(rw),
                                                    }).ToList().Distinct();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return baseModel;
        }


        private string returnstatus(DataRow r)
        {

            if (r["Id"].ToString() == r["ServiceReqId"].ToString())
            {
                return r["wostatus"].ToString();
            }
            else
            {
                if (r["reqstatus"].ToString() != null)
                {
                    return "Proceed to Workorder";
                }
                else
                {
                    return "Request Submited";

                }

            }
        }

        private string returnremark(DataRow r)
        {

            if (r["Id"].ToString() == r["ServiceReqId"].ToString())
            {
                return r["woremarks"].ToString();
            }
            else
            {
                return r["reqremarks"].ToString();
            }
        }
    }





    public class MyObj
    {
        public int ID { get; set; }
        public string ServiceDescription { get; set; }
        public string Description { get; set; }
        public decimal total { get; set; }
    }
}