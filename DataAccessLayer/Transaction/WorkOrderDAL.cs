using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.DataAccessLayer.Transaction
{
    public class WorkOrderDAL
    {
        public string CreateWorkOrder(Workorder request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", "");
                        cmd.Parameters.AddWithValue("@RequesterName", request.RequesterName);
                        cmd.Parameters.AddWithValue("@RequestReceivedby", request.RequestReceivedby);
                        cmd.Parameters.AddWithValue("@ReceivedDateTime", request.ReceivedDateTime);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@ReportingDateTime", request.ReportingDateTime);
                        cmd.Parameters.AddWithValue("@RequestForm", request.RequestForm);
                        cmd.Parameters.AddWithValue("@AssignTo", request.AssignTo);
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
                        cmd.Parameters.AddWithValue("@Locationpriority", request.Locationpriority);
                        cmd.Parameters.AddWithValue("@ServicePriority", request.ServicePriority);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@RejectRemarks", request.RejectRemarks);
                        //cmd.Parameters.AddWithValue("@WorKorderStatus", "3");
                        cmd.Parameters.AddWithValue("@WorKorderStatus", request.WorKorderStatus);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@UniqueAssetId", request.UniqueAssetId);
                        cmd.Parameters.AddWithValue("@ServiceReqId", request.ServiceReqId);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            int message = Convert.ToInt32(dt.Rows[0][0]);
                            if (message > 0)
                            {
                                RaiseServiceDAL Service = new RaiseServiceDAL();
                                string status = Service.updateRaiseSatus(Convert.ToInt32(request.ServiceReqId));
                                if (status == "Status Updated")
                                {
                                    return dt.Rows[0][0].ToString();
                                }
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string updateWorkOrder(Workorder request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@RequesterName", request.RequesterName);
                        cmd.Parameters.AddWithValue("@RequestReceivedby", request.RequestReceivedby);
                        cmd.Parameters.AddWithValue("@ReceivedDateTime", request.ReceivedDateTime);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@ReportingDateTime", request.ReportingDateTime);
                        cmd.Parameters.AddWithValue("@RequestForm", request.RequestForm);
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
                        cmd.Parameters.AddWithValue("@Locationpriority", request.Locationpriority);
                        cmd.Parameters.AddWithValue("@ServicePriority", request.ServicePriority);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@RejectRemarks", request.RejectRemarks);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", request.WorKorderStatus);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", request.Modifiedby);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;


            }

            return Convert.ToString(request.Id);

        }


        public string SaveWorkOrderdocuments(RaiseService request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@ImagePath", request.ImagePath);
                        cmd.Parameters.AddWithValue("@Type", "WorkOrderImage");

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string UpdateWorkOrderFile(RaiseService request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@ImagePath", request.ImagePath);
                        cmd.Parameters.AddWithValue("@Type", "WorkOrderImage");

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public List<Workorder> GetWorkOrderDetails(RaiseService request)
        {
            List<Workorder> baseModel = new List<Workorder>();
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
                    request.Status1.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                       // cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@RequesterName", "");
                        cmd.Parameters.AddWithValue("@RequestReceivedby", "");
                        cmd.Parameters.AddWithValue("@ReceivedDateTime", "");
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@ReportingDateTime", "");
                        cmd.Parameters.AddWithValue("@RequestForm", "");
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
                        cmd.Parameters.AddWithValue("@Locationpriority", "");
                        cmd.Parameters.AddWithValue("@ServicePriority", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                        cmd.Parameters.AddWithValue("@Status1", request.Status1);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);
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
                                Workorder data = new Workorder();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.WorkOrderId = Convert.ToInt32(dr["WOId"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.WorKorderStatus = dr["Status"].ToString();
                                //bool Test = dr["ModifiedOn"].Equals(DBNull.Value);
                                if (dr["ModifiedOn"].Equals(DBNull.Value))
                                {
                                    data.ModifiedOn = null;
                                }
                                else
                                {
                                    data.ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]);
                                }
                                data.CloseStatus = dr["CloseStatus"].ToString();

                                // data.ModifiedOn = (dr["ModifiedOn"].Equals(DBNull.Value)) ? null : (Convert.ToDateTime(dr["ModifiedOn"]));
                                data.LocationName = dr["LocationName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.Systemaname = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.RequestfromName = dr["FormName"].ToString();
                                data.UniqueAssetId = (dr["UniqueAssetId"]).ToString();
                                data.Assignto = (dr["Assign"]).ToString();
                                data.AssignId = (dr["AssignId"]).ToString();
                                data.Isdownload = dr["IsDownload"].Equals(DBNull.Value)? false :Convert.ToBoolean(dr["IsDownload"]);

                                data.Expression = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "Workorder");
                                data.ServiceIdFormat = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "ServiceRequest");

                                baseModel.Add(data);
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


        /// <summary>
        /// Get WO details Status Complete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<Workorder> GetCompleteWorkOrder(RaiseService request)
        {
            List<Workorder> baseModel = new List<Workorder>();
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
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 14);
                        cmd.Parameters.AddWithValue("@Id", "");
                        cmd.Parameters.AddWithValue("@RequesterName", "");
                        cmd.Parameters.AddWithValue("@RequestReceivedby", "");
                        cmd.Parameters.AddWithValue("@ReceivedDateTime", "");
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@ReportingDateTime", "");
                        cmd.Parameters.AddWithValue("@RequestForm", "");
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
                        cmd.Parameters.AddWithValue("@Locationpriority", "");
                        cmd.Parameters.AddWithValue("@ServicePriority", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Workorder data = new Workorder();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.WorKorderStatus = dr["Status"].ToString();
                                //bool Test = dr["ModifiedOn"].Equals(DBNull.Value);
                                if (dr["ModifiedOn"].Equals(DBNull.Value))
                                {
                                    data.ModifiedOn = null;
                                }
                                else
                                {
                                    data.ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]);
                                }
                                // data.ModifiedOn = (dr["ModifiedOn"].Equals(DBNull.Value)) ? null : (Convert.ToDateTime(dr["ModifiedOn"]));
                                data.LocationName = dr["LocationName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.Systemaname = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.RequestfromName = dr["FormName"].ToString();
                                data.UniqueAssetId = (dr["UniqueAssetId"]).ToString();
                                data.Assignto = (dr["Assign"]).ToString();
                                data.Expression = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "Workorder");

                                baseModel.Add(data);
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

        /// <summary>
        /// Getting Wo Datils fro update
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<Workorder> GetWorkOrderDetailsForUpdate(RaiseService request)
        {
            List<Workorder> baseModel = new List<Workorder>();
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
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 10);
                        cmd.Parameters.AddWithValue("@Id", "");
                        cmd.Parameters.AddWithValue("@RequesterName", "");
                        cmd.Parameters.AddWithValue("@RequestReceivedby", "");
                        cmd.Parameters.AddWithValue("@ReceivedDateTime", "");
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@ReportingDateTime", "");
                        cmd.Parameters.AddWithValue("@RequestForm", "");
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
                        cmd.Parameters.AddWithValue("@Locationpriority", "");
                        cmd.Parameters.AddWithValue("@ServicePriority", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", "6");
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        //cmd.Parameters.AddWithValue("@Close","Close");
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);

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
                                Workorder data = new Workorder();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.WorKorderStatus = dr["Status"].ToString();
                                data.RequestfromName = dr["FormName"].ToString();
                                data.UniqueAssetId = dr["UniqueAssetId"].ToString();
                                data.Systemaname = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.ZoneName = dr["ZoneName"].ToString();
                                data.BuildingName = dr["BuildingName"].ToString();
                                data.FloorName = dr["FloorName"].ToString();
                                data.AreaName = dr["AreaName"].ToString();
                                data.RoomName = dr["RoomName"].ToString();
                                data.Assignto = dr["Assign"].ToString();
                                data.RefWOId = dr["RefWOId"].ToString();
                                data.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                                data.Expression = FOrExPression.autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "Workorder");

                                if (dr["ModifiedOn"].Equals(DBNull.Value))
                                {
                                    data.ModifiedOn = null;
                                }
                                else
                                {
                                    data.ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]);
                                }
                                baseModel.Add(data);
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

        public List<Workorder> getWorkOrderByid(int id)
        {
            List<Workorder> baseModel = new List<Workorder>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Workorder data = new Workorder();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.RequestReceivedby = dr["RequestReceivedby"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.ReportingDateTime = Convert.ToDateTime(dr["ReportingDateTime"].ToString());
                                data.RequestForm = Convert.ToInt32(dr["RequestForm"]);
                                data.Site = Convert.ToInt32(dr["Site"]);
                                data.Zone = Convert.ToInt32(dr["Zone"]);
                                data.Building = Convert.ToInt32(dr["Building"]);
                                data.Floor = Convert.ToInt32(dr["Floor"]);
                                data.Area = Convert.ToInt32(dr["Area"]);
                                data.Room = Convert.ToInt32(dr["Room"]);
                                data.BussinessUnit = Convert.ToInt32(dr["BussinessUnit"]);
                                data.Service = Convert.ToInt32(dr["Service"]);
                                data.SubService = Convert.ToInt32(dr["SubService"]);
                                data.Problem = Convert.ToInt32(dr["Problem"]);
                                data.System = Convert.ToInt32(dr["System"]);
                                data.SubSystem = Convert.ToInt32(dr["SubSystem"]);
                                data.Locationpriority = Convert.ToInt32(dr["Locationpriority"]);
                                data.ServicePriority = Convert.ToInt32(dr["ServicePriority"]);
                                data.Remarks = dr["Remarks"].ToString();
                                data.ImagePath = dr["ImagePath"].ToString();
                                data.RejectRemarks = dr["RejectRemarks"].ToString();
                                data.Status = Convert.ToInt32(dr["WorKorderStatus"]);
                                data.UniqueAssetId = (dr["Unique AssetId"]).ToString();
                                data.AssignTo = (dr["AssignTo"]).ToString();
                                baseModel.Add(data);
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

        public listofimages GetWorkOrderImages(int id,int RaiseId)
        {
            listofimages baseModel = new listofimages();
            List<WoImages> Woimages = new List<WoImages>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                if (id>0)
                {
                    using (SqlConnection conn = new SqlConnection(ConString))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 7);
                            cmd.Parameters.AddWithValue("@Id", id);

                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    WoImages data = new WoImages();
                                    data.ImagesPath = dr["ImagePath"].ToString();
                                    Woimages.Add(data);
                                }

                            }


                        }
                    }

                }

                RaiseServiceDAL RaiseDAL = new RaiseServiceDAL();
                baseModel.Raiseimageslist = RaiseDAL.ServiceImages(RaiseId);
                baseModel.Woimageslist = Woimages;

            }
            catch (Exception ex)
            {
                throw;
            }

            return baseModel;

        }

        public string RejectWorkOrder(List<Workorder> data)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var request in data)
                    {
                        using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 8);
                            cmd.Parameters.AddWithValue("@Id", request.Id);
                            cmd.Parameters.AddWithValue("@WorKorderStatus", "4");
                            cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                            cmd.Parameters.AddWithValue("@Modifiedby", request.CreatedBy);

                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }

                        WorkOrderDAL Dal = new WorkOrderDAL();
                        WOHistory model = new WOHistory();
                        model.ServiceId = Convert.ToInt32(request.ServiceReqId);
                        model.AssignTo = request.AssignTo;
                        model.WorKorderStatus = "12";
                        model.CompanyId = request.CompanyId;
                        model.CreatedBy = request.Modifiedby;
                        Dal.CreateWorkOrderHistory(model);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string DeleteWOIMage(Workorder request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 9);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public List<WorkOrderStatus> GetWOStatusMaster(int id)
        {
            List<WorkOrderStatus> baseModel = new List<WorkOrderStatus>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd-Tbl-WorkOrderStatus] where CompanyId=@Id and IsVisible is null", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@Id", id);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        conn.Open();

                        da.SelectCommand = cmd;
                        conn.Close();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                WorkOrderStatus data = new WorkOrderStatus();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Status = dr["Status"].ToString();
                                baseModel.Add(data);
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

        public listofresourcesandspares GetWOchilddetsils(int id)
        {
            listofresourcesandspares baseModel = new listofresourcesandspares();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                    {

                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        DataTable resource = ds.Tables[0];
                        DataTable Tools = ds.Tables[3];
                        DataTable consumbels = ds.Tables[2];
                        DataTable Spares = ds.Tables[1];
                        if (ds.Tables.Count > 0)
                        {
                            baseModel.ResourcesList = WoResourceList(resource);
                            baseModel.SparesList = WOSparesndtollsList(Spares);
                            baseModel.ToolsList = WOSparesndtollsList(Tools);
                            baseModel.ConsumabelsList = WOSparesndtollsList(consumbels);



                            //foreach (DataRow dr in resource.Rows)
                            //{
                            //    Resources data = new Resources();
                            //    data.Id = Convert.ToInt32(dr["Id"]);
                            //    data.WorkOrderId = Convert.ToInt32(dr["WorkOrderId"]);
                            //    data.Code = (dr["Code"]).ToString();
                            //    data.Name = (dr["Name"]).ToString();
                            //    data.Fromdate = Convert.ToDateTime(dr["Fromdate"]);
                            //    data.Todate = Convert.ToDateTime(dr["Todate"]);
                            //    baseModel.Add(data);
                            //}
                            //foreach (DataRow dr in Spares.Rows)
                            //{
                            //    WoAddItems data = new WoAddItems();
                            //    data.Code = (dr["Code"]).ToString();
                            //    data.Id = Convert.ToInt32(dr["Id"]);
                            //    data.WorkOrderId = Convert.ToInt32(dr["WorkOrderId"]);
                            //    data.Quantity = Convert.ToDecimal(dr["Quantity"]);
                            //    data.Name = (dr["Name"]).ToString();
                            //    data.Category = (dr["Category"]).ToString();
                            //    data.SubCategory = (dr["SubCategory"]).ToString();
                            //    data.Services = (dr["Services"]).ToString();
                            //    data.InventoryType = (dr["InventoryType"]).ToString();
                            //    baseModel.Add(data);
                            //}
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

        internal List<Resources> WoResourceList(DataTable request)
        {
            List<Resources> baseresponce = new List<Resources>();
            foreach (DataRow dr in request.Rows)
            {
                Resources responce = new Resources();
                responce.Id = Convert.ToInt32(dr["Id"]);
                responce.resourceId = (dr["ResourceId"]).ToString();
                responce.WorkOrderId = Convert.ToInt32(dr["WorkOrderId"]);
                responce.Code = (dr["Code"]).ToString();
                responce.Name = (dr["Name"]).ToString();
                responce.Remarks = (dr["Remarks"]).ToString();
                responce.TimeTaken = (dr["TimeTaken"]).ToString();
                responce.Fromdate = Convert.ToDateTime(dr["Fromdate"]);
                responce.Todate = Convert.ToDateTime(dr["Todate"]);
                responce.TotalTime = addresourcetimes(Convert.ToInt32(dr["WorkOrderId"]), (dr["ResourceId"]).ToString());
                if (responce.TotalTime != "00:00:00")
                {
                    responce.Visible = true;
                }
                responce.IsDone = Convert.ToBoolean((dr["IsDone"]));
                baseresponce.Add(responce);
            }

            return baseresponce;
        }
        internal List<ToolsSpresConsumables> WOSparesndtollsList(DataTable request)
        {
            List<ToolsSpresConsumables> baseresponce = new List<ToolsSpresConsumables>();
            foreach (DataRow dr in request.Rows)
            {
                ToolsSpresConsumables responce = new ToolsSpresConsumables();
                responce.code = (dr["Code"]).ToString();
                responce.ItemId = (dr["ItemId"]).ToString();
                responce.Id = Convert.ToInt32(dr["Id"]);
                responce.WorkOrderId = Convert.ToInt32(dr["WorkOrderId"]);
                responce.ReqQuantity = Convert.ToDecimal(dr["Quantity"]);
                responce.Remarks = (dr["Remarks"]).ToString();
                //responce.ConsumeQty = Convert.ToDecimal(dr["ConsumeQty"]);
                if (dr["ConsumeQty"].Equals(DBNull.Value))
                {
                    responce.ConsumeQty = 0;
                }
                else
                {
                    responce.ConsumeQty = Convert.ToDecimal(dr["ConsumeQty"]);
                }
                if (dr["IsDone"].Equals(DBNull.Value))
                {
                    responce.IsDone = false;
                }
                else
                {

                    responce.IsDone = Convert.ToBoolean(dr["IsDone"]);
                    responce.TotalQuantity = AddSubItemsQuantity(request, Convert.ToInt32(dr["WorkOrderId"]));

                }
                responce.Name = (dr["Name"]).ToString();
                responce.Category = (dr["Category"]).ToString();
                responce.SubCategory = (dr["SubCategory"]).ToString();
                responce.ServiceDescription = (dr["Services"]).ToString();
                responce.InventoryType = (dr["InventoryType"]).ToString();
                baseresponce.Add(responce);
            }

            return baseresponce;
        }

        public string DeleteWoresourse(WoResource request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string DeleteWoSpares(WoResource request)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("[HD_SP_WOAddItems]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string DeleteWoTools(WoResource request)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("[HD_SP_WOAddItems]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 8);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string DeleteWoConsumabels(WoResource request)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("[HD_SP_WOAddItems]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }


        public string DeleteWOAddItems(WoAddItems request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@WorkOrderId", request.WorkOrderId);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string CreateWorkOrderHistory(WOHistory request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 12);
                        cmd.Parameters.AddWithValue("@ServiceReqId", request.ServiceId);
                        cmd.Parameters.AddWithValue("@Id", request.WOId);
                        cmd.Parameters.AddWithValue("@RequesterName", request.RequesterName);
                        cmd.Parameters.AddWithValue("@RequestReceivedby", request.RequestReceivedby);
                        cmd.Parameters.AddWithValue("@RequestForm", request.RequestForm);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@AssignTo", request.AssignTo);
                        cmd.Parameters.AddWithValue("@UniqueAssetId", request.UniqueAssetId);
                        cmd.Parameters.AddWithValue("@WorKorderStatus", request.WorKorderStatus);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);


                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public List<WOHistory> GetWorkOrderHistoryDetails(int Id, int companyId)
        {
            List<WOHistory> baseModel = new List<WOHistory>();
            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 13);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                WOHistory data = new WOHistory();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.WOId = Convert.ToInt32(dr["WOId"]);
                                data.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.RequestReceivedby = dr["RequestReceivedby"].ToString();
                                data.WorKorderStatus = dr["Status"].ToString();
                                data.AssignTo = dr["Assign"].ToString();
                                //bool Test = dr["ModifiedOn"].Equals(DBNull.Value);
                                if (dr["CreatedOn"].Equals(DBNull.Value))
                                {
                                    data.CreatedOn = null;
                                }
                                else
                                {
                                    data.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                                }
                                // data.ModifiedOn = (dr["ModifiedOn"].Equals(DBNull.Value)) ? null : (Convert.ToDateTime(dr["ModifiedOn"]));
                                data.RequestfromName = dr["FormName"].ToString();
                                data.UniqueAssetId = (dr["Unique AssetId"]).ToString();
                                data.UserName = (dr["UserName"]).ToString();
                                //data.Assignto = (dr["Assign"]).ToString();
                                data.WoIdFormat = FOrExPression.autoIdFormat(Convert.ToInt32(dr["ServiceId"]), companyId, "Workorder");
                                data.ServiceIdFormat = FOrExPression.autoIdFormat(Convert.ToInt32(dr["ServiceId"]), companyId, "ServiceRequest");

                                baseModel.Add(data);
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

        public listofresourcesandspares getResourcesdata(int Id, int companyId)
        {
            listofresourcesandspares baseModel = new listofresourcesandspares();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable resource = ds.Tables[0];
                        DataTable Tools = ds.Tables[1];
                        DataTable consumbels = ds.Tables[2];
                        DataTable Spares = ds.Tables[3];

                        if (ds.Tables.Count > 0)
                        {
                            baseModel.ResourcesList = ResourceList(resource);
                            baseModel.SparesList = SparesndtollsList(Spares);
                            baseModel.ToolsList = SparesndtollsList(Tools);
                            baseModel.ConsumabelsList = SparesndtollsList(consumbels);
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
        internal List<Resources> ResourceList(DataTable request)
        {
            List<Resources> baseresponce = new List<Resources>();
            foreach (DataRow dr in request.Rows)
            {
                Resources responce = new Resources();
                responce.Id = Convert.ToInt32(dr["ID"]);
                responce.Code = (dr["EmpCode"]).ToString();
                responce.Name = (dr["EmpName"]).ToString();
                responce.ServiceDescription = (dr["ServiceDescription"]).ToString();
                //responce.Remarks = (dr["Remarks"]).ToString();
                baseresponce.Add(responce);
            }

            return baseresponce;
        }
        internal List<ToolsSpresConsumables> SparesndtollsList(DataTable request)
        {
            List<ToolsSpresConsumables> baseresponce = new List<ToolsSpresConsumables>();
            foreach (DataRow dr in request.Rows)
            {
                ToolsSpresConsumables responce = new ToolsSpresConsumables();
                responce.Id = Convert.ToInt32(dr["ID"]);
                responce.code = (dr["Itemcode"]).ToString();
                responce.Name = (dr["ItemDescription"]).ToString();
                responce.ServiceDescription = (dr["ServiceDescription"]).ToString();
                responce.Category = (dr["SystemFamily"]).ToString();

                responce.SubCategory = (dr["SubSystemFamily"]).ToString();
                responce.InventoryType = (dr["ItemclassTypeDescription"]).ToString();
                //responce.ReqQuantity = Convert.ToDecimal((dr["Quantity"]).ToString());
                //responce.ConsumeQty=Convert.ToDecimal((dr["ConsumeQty"]).ToString());
                baseresponce.Add(responce);
            }

            return baseresponce;
        }



        public string AddWOChilddata(listofresourcesandspares request)
        {
            if (request.ResourcesList.Count > 0)
            {
                string resourcesdat = CreateWoResorce(request.ResourcesList, request.WOId, request.CompanyId);
            }
            //string Spares = CreateWOSpares(request.SparesList, request.WOId, request.CompanyId);
            if (request.SparesList.Count > 0) { string Spares = CreateWOSpares(request.SparesList, request.WOId, request.CompanyId); }

            if (request.ToolsList.Count > 0)
            { string tools = CreateWOtools(request.ToolsList, request.WOId, request.CompanyId); }
            if (request.ConsumabelsList.Count>0)
            { string consumbels = CreateWOConsumbels(request.ConsumabelsList, request.WOId, request.CompanyId); }

            return "";

        }

        public string CreateWoResorce(List<Resources> request, int Id, int CompanyId)
        {
            

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        //Inserting new record
                        if (data.Id == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 1);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ResourceId", data.resourceId);
                                cmd.Parameters.AddWithValue("@Code", data.Code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Fromdate", data.Fromdate);
                                cmd.Parameters.AddWithValue("@Todate", data.Todate);
                                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@TimeTaken", data.TimeTaken);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.Parameters.AddWithValue("@IsDone", false);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);

                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                        else if (data.IsDone == false)
                        {
                            //Update Exist record
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 5);
                                cmd.Parameters.AddWithValue("@Id", data.Id);
                                cmd.Parameters.AddWithValue("@ResourceId", data.resourceId);
                                cmd.Parameters.AddWithValue("@Code", data.Code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Fromdate", data.Fromdate);
                                cmd.Parameters.AddWithValue("@Todate", data.Todate);
                                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@TimeTaken", data.TimeTaken);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string CreateWOSpares(List<ToolsSpresConsumables> request, int Id, int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        if (data.Id == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 3);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.Parameters.AddWithValue("@IsDone", false);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);


                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                        else if (data.IsDone == false)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 9);
                                cmd.Parameters.AddWithValue("@Id", data.Id);
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);

                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);

                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }

                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return "";

        }

        public string CreateWOtools(List<ToolsSpresConsumables> request, int Id, int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        if (data.Id == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 5);
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 11);
                                //cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Id", data.Id);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }

                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string CreateWOConsumbels(List<ToolsSpresConsumables> request, int Id, int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        if (data.Id == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 4);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.Parameters.AddWithValue("@IsDone", false);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);

                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                        else if (data.IsDone == false)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 10);
                                cmd.Parameters.AddWithValue("@Id", data.Id);
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", Id);
                                cmd.Parameters.AddWithValue("@Remarks", data.Remarks);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        internal string addresourcetimes(int WOId, string ResourceId)
        {

            TimeSpan totaltime = TimeSpan.FromHours(0);

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataTable ds = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                    {

                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@Id", WOId);
                        cmd.Parameters.AddWithValue("@ResourceId", ResourceId);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds.Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Rows)
                            {
                                string t1 = (dr["TimeTaken"].ToString());
                                //TimeSpan t2= TimeSpan.FromHours(28);
                                string[] values = t1.Split(':');
                                TimeSpan ts = new TimeSpan(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), 0);


                                totaltime = ts.Add(totaltime);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return totaltime.ToString();
        }

        internal decimal AddSubItemsQuantity(DataTable request, int WoId)
        {
            decimal responce = 0;
            foreach (DataRow data in request.Rows)
            {
                if (Convert.ToInt32(data["WorkOrderId"]) == WoId && !data["IsDone"].Equals(DBNull.Value) && Convert.ToBoolean(data["IsDone"]) == true)
                {
                    responce += Convert.ToDecimal(data["ConsumeQty"]);
                }
            }
            return responce;

        }
    }
}