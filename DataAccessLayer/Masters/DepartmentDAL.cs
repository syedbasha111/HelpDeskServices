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
    public class DepartmentDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();

        public HD_BaseModel SaveDepartment(DepartmentModel request)
        {
            HD_BaseModel reponce = new HD_BaseModel();
            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-sp-DepartmentMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remark);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();

                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            reponce.status = dt.Rows[0][0].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                reponce.status = ex.ToString();
            }

            return reponce;

        }

        public HD_BaseModel UpdateDepartment(DepartmentModel request)
        {
            HD_BaseModel reponce = new HD_BaseModel();
            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-sp-DepartmentMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remark);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();

                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            reponce.status = dt.Rows[0][0].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                reponce.status = ex.ToString();
            }

            return reponce;

        }

        public List<DepartmentModel> GetDepartment(int CompanyId)
        {
            List<DepartmentModel> BaseResponce = new List<DepartmentModel>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {


                    using (cmd = new SqlCommand("[Hd-sp-DepartmentMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                DepartmentModel responce = new DepartmentModel();

                                responce.Id = int.Parse(dr["Id"].ToString());
                                responce.Name = dr["Name"].ToString();
                                responce.Code = dr["Code"].ToString();
                                responce.Status = dr["Status"].ToString();
                                responce.Remark = dr["Remarks"].ToString();

                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }

        public string deletedepartment(DeleteObj request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-sp-DepartmentMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", request.RecordId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();

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
    }
}