using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer
{
    public class EmployeetypeDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;

        public string CreatEmployeetype(Employeetype request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-EmployeeType]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@EmployeeType", request.EmployeeType);
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

        public string UpdateEmployeetype(Employeetype request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-EmployeeType]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@EmployeeType", request.EmployeeType);
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

        public string DeleteEmployeetype(DeleteObj request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-EmployeeType]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", request.RecordId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
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