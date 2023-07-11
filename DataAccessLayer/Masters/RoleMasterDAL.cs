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
    public class RoleMasterDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;

        public string CreateRole(RoleModel request)
        {
           //RoleModel[] model = new RoleModel[] { };
           
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-sp-RoleMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@code", request.code);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        //cmd.Parameters.AddWithValue("@CompanyCode", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyCode", request.CompanyCode);
                        cmd.Parameters.AddWithValue("@CreatedOn", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);

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


        public string UpdateRole(RoleModel request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-sp-RoleMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@code", request.code);
                        cmd.Parameters.AddWithValue("@RoleId", request.RoleId);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        //cmd.Parameters.AddWithValue("@CompanyCode", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyCode", request.CompanyCode);
                        cmd.Parameters.AddWithValue("@CreatedOn", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);

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

        public List<RoleModel> GetRoleMaster(int companyId)
        {
            List<RoleModel> Basemodel = new List<RoleModel>();
            try
            {
                using ( conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using ( cmd = new SqlCommand("[Hd-sp-RoleMaster]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyCode", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RoleModel data = new RoleModel();
                                data.RoleId =Convert.ToInt32(dr["RoleId"]);
                                data.CompanyId =Convert.ToInt32(dr["CompanyCode"]);
                                data.code= (dr["Code"].ToString());
                                data.Name =(dr["Name"].ToString());
                                data.Status =Convert.ToBoolean(dr["Status"]);
                                data.Remarks =(dr["Remarks"].ToString());
                                Basemodel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return Basemodel;

        }

        public string DeleteRole(DeleteObj request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[Hd-sp-RoleMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@RoleId", request.RecordId);
                        cmd.Parameters.AddWithValue("@CompanyCode", request.CompanyId);

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