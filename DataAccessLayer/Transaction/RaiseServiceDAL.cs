using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.Transaction
{
    public class RaiseServiceDAL
    {

        public string CreateRaiseService(RaiseService request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
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
                        cmd.Parameters.AddWithValue("@Type", request.Type);
                        cmd.Parameters.AddWithValue("@SLA", request.SLA);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", "");
                        cmd.Parameters.AddWithValue("@todate", "");
                        cmd.Parameters.AddWithValue("@RefWOId", request.RefWOId);
                        cmd.Parameters.AddWithValue("@UniqueAssetId", request.UniqueAssetId);
                        cmd.Parameters.AddWithValue("@WorkOrderStatus", request.WorkOrderStatus);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



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


        public string updateRaiseService(RaiseService request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
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
                        cmd.Parameters.AddWithValue("@AssignTo", request.AssignTo);
                        cmd.Parameters.AddWithValue("@ImagePath", "");
                        cmd.Parameters.AddWithValue("@Type", request.Type);
                        cmd.Parameters.AddWithValue("@SLA", request.SLA);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", request.Modifiedby);
                        cmd.Parameters.AddWithValue("@area", request.Area);
                        cmd.Parameters.AddWithValue("@fromdate", "");
                        cmd.Parameters.AddWithValue("@todate", "");
                        cmd.Parameters.AddWithValue("@UniqueAssetId", request.UniqueAssetId);

                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return request.Id.ToString();
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

        public string UpdateAssignList(List<RaiseService> request)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request)
                {
                    using (SqlConnection conn = new SqlConnection(ConString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 6);
                            cmd.Parameters.AddWithValue("@Id", data.Id);
                            cmd.Parameters.AddWithValue("@AssignTo", data.AssignTo);
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId);
                            cmd.Parameters.AddWithValue("@Modifiedby", data.Modifiedby);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                    WorkOrderDAL Dal = new WorkOrderDAL();
                    WOHistory model = new WOHistory();
                    model.ServiceId = data.Id;
                    model.AssignTo = data.AssignTo;
                    model.WorKorderStatus = "7";
                    model.CompanyId = data.CompanyId;
                    model.CreatedBy = data.Modifiedby;
                    Dal.CreateWorkOrderHistory(model);
                }
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public string SaveRaisedocumentPath(RaiseService request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@ImagePath", request.ImagePath);



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

        public List<RaiseService> getserviceRequestDetails(RaiseService request)
        {
            List<RaiseService> baseModel = new List<RaiseService>();

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
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
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
                        cmd.Parameters.AddWithValue("@Type", "");
                        cmd.Parameters.AddWithValue("@SLA", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", "");
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RaiseService data = new RaiseService();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                data.RequestFormName = dr["FormName"].ToString();
                                data.UniqueAssetId = dr["UniqueAssetId"].ToString();
                                data.SystemName = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.Expression = autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "ServiceRequest");
                                data.AssignTo = dr["AssignTo"].ToString();
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

        public List<RaiseService> getAssignData(RaiseService request)
        {
            List<RaiseService> baseModel = new List<RaiseService>();
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
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 11);
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
                        cmd.Parameters.AddWithValue("@Type", "");
                        cmd.Parameters.AddWithValue("@SLA", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", "");
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RaiseService data = new RaiseService();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                data.RequestFormName = dr["FormName"].ToString();
                                data.UniqueAssetId = dr["UniqueAssetId"].ToString();
                                data.SystemName = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                SRAssignMasterDAL emp = new SRAssignMasterDAL();
                                data.EmployeeList = emp.GetEmployeebyService(Convert.ToInt32(dr["SericeId"]), request.CompanyId);
                                
                                data.Expression = autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "ServiceRequest");

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

        public List<RaiseService> getserviceRequestDetailsforWO(RaiseService request)
        {
            List<RaiseService> baseModel = new List<RaiseService>();
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
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 9);
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
                        cmd.Parameters.AddWithValue("@Type", "");
                        cmd.Parameters.AddWithValue("@SLA", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@ModifiedOn", "");
                        cmd.Parameters.AddWithValue("@Modifiedby", "");
                        cmd.Parameters.AddWithValue("@area", "");
                        cmd.Parameters.AddWithValue("@fromdate", request.fromdate);
                        cmd.Parameters.AddWithValue("@todate", request.todate);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.CommandTimeout=1;
                        SqlDataAdapter da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        conn.Close();
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RaiseService data = new RaiseService();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.RequesterName = dr["RequesterName"].ToString();
                                data.ReceivedDateTime = Convert.ToDateTime(dr["ReceivedDateTime"].ToString());
                                data.Sitename = dr["SiteName"].ToString();
                                data.Businessname = dr["Description"].ToString();
                                data.servicename = dr["ServiceDescription"].ToString();
                                data.Subservicename = dr["SubServiceDescription"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                data.RequestFormName = dr["FormName"].ToString();
                                data.UniqueAssetId = dr["UniqueAssetId"].ToString();
                                data.SystemName = dr["SystemName"].ToString();
                                data.SubSystemName = dr["SubSystemName"].ToString();
                                data.Problemdesc = dr["ProblemDescription"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                //data.CreatedOn=Convert.ToDateTime(dr["CreatedOn"]);
                                data.Expression = autoIdFormat(Convert.ToInt32(dr["Id"]), request.CompanyId, "ServiceRequest");

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


        public List<RaiseService> getserviceRequestByid(int id)
        {
            List<RaiseService> baseModel = new List<RaiseService>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
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
                                RaiseService data = new RaiseService();
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
                                data.Type = dr["Type"].ToString();
                                data.SLA = dr["SLA"].ToString();
                                data.AssignTo = dr["AssignTo"].ToString();
                                data.ImagePath = dr["ImagePath"].ToString();
                                data.Images = ServiceImages(data.Id);
                                data.UniqueAssetId = dr["UniqueAssetId"].ToString();
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
        public List<imageslist> ServiceImages(int Id)
        {
            List<imageslist> imagesresponce = new List<imageslist>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 12);
                        cmd.Parameters.AddWithValue("@Id",Id);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new imageslist()
                                                 {
                                                     ImagesPath = Convert.ToString(rw["ImagePath"]),
                                                     //Type = Convert.ToString(rw["ServiceDescription"]),
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

            return imagesresponce;
        }



        public List<RequestForm> getRequestFormMaster()
        {
            List<RequestForm> baseModel = new List<RequestForm>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd_tbl-RequestForm]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

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
                                RequestForm data = new RequestForm();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.FormName = dr["FormName"].ToString();
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

        public List<SystemName> getSystemMaster()
        {
            List<SystemName> baseModel = new List<SystemName>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd_tbl_System]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

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
                                SystemName data = new SystemName();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.System = dr["System"].ToString();
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

        public List<SubSystem> getSubSystemMaster()
        {
            List<SubSystem> baseModel = new List<SubSystem>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd_tbl_SubSystem]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

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
                                SubSystem data = new SubSystem();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.SubSystemName = dr["SubSystem"].ToString();
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

        public List<Locationpriority> GetLocationPriority()
        {
            List<Locationpriority> baseModel = new List<Locationpriority>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd_tbl_Locationpriority]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Locationpriority data = new Locationpriority();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Location = dr["Location"].ToString();
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

        public List<Servicepriority> GetServicePriority()
        {
            List<Servicepriority> baseModel = new List<Servicepriority>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd_tbl_Servicepriority]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Servicepriority data = new Servicepriority();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Service = dr["Service"].ToString();
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

        public string SaveAssertlabelId(List<AssertLabelModel> request)
        {
            string Status = "";


            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                foreach (var data in request)
                {
                    using (SqlConnection conn = new SqlConnection(ConString))
                    {

                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlCommand cmd = new SqlCommand("hd-sp-AssertLabel", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@Id", "");
                            cmd.Parameters.AddWithValue("@Asserts", data.Asserts);
                            cmd.Parameters.AddWithValue("@AssertId", data.AssertId);
                            cmd.Parameters.AddWithValue("@IsChecked", data.IsChecked);
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            Status = dt.Rows[0][0].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return Status;

        }


        public List<AssertLabelModel> GetassertLabelMaster()
        {
            List<AssertLabelModel> baseModel = new List<AssertLabelModel>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd-tbl-AsserrLabelmaster]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Fcase", 7);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                AssertLabelModel data = new AssertLabelModel();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Asserts = dr["Asserts"].ToString();
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

        public List<AssertLabelModel> GetassertLabelMasterId(int Id)
        {
            List<AssertLabelModel> baseModel = new List<AssertLabelModel>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [Hd-tbl-AssertLableIdmaster] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);

                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                AssertLabelModel data = new AssertLabelModel();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.AssertId = Convert.ToInt32(dr["Asertid"]);
                                data.IsChecked = Convert.ToBoolean(dr["IsChecked"]);
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

        public List<AssignRequest> GetassignList(int Id)
        {
            List<AssignRequest> baseModel = new List<AssignRequest>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from  [dbo].[Hd-tbl-AssignRequest] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);

                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                AssignRequest data = new AssignRequest();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Assign = (dr["Assign"].ToString());
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


        public string autoIdFormat(int Id, int companyId, string type)
        {
            string responce = "";
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_WorkOrder", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 11);
                        cmd.Parameters.AddWithValue("@ServiceReqId", Id);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        DataTable service = ds.Tables[0];
                        DataTable format = ds.Tables[1];
                        //if (dt.Rows.Count > 0)
                        //{
                        //    responce = dt.Rows[1][0].ToString() + "/" + dt.Rows[0][0].ToString();
                        //}
                        if (ds.Tables[0].Rows.Count!=0)
                        {
                            string year = ds.Tables[0].Rows[0][1].ToString();
                            year = year.Substring(year.Length - 2);
                           responce = ds.Tables[1].Rows[0][0].ToString() + "/" + ds.Tables[0].Rows[0][0].ToString()+"-"+ year;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return responce = ex.Message;
            }

            return responce;
        }
        //In raise table status and Workorder apprvstaus updating in _sp
        public string updateRaiseSatus(int Id)
        {
            string responce = "";
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_RaiseService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 10);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            responce = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responce;
        }
    }
}