using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.Masters
{
    public class ReportingManagerDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;


        public string CreateReportingMaster(ReportingManager request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-Sp-ReportingManager]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);


                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
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

        public string UpdateReportingMaster(ReportingManager request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-Sp-ReportingManager]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);


                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
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


        public string DeleteReportingManger(DeleteObj request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-Sp-ReportingManager]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Id", request.RecordId);


                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
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
    }
}