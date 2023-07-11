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
    public class UserRoleMappingDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;


        public string CreateUserRole(MVUserRoleMapping request)
        {
            foreach (var i in request.EmployeeList)
            {
                string rolemessage = CreateUserRoleMapping(i.Id,request.CompanyId,request.CreatedBy,request.RoleList);

                string LocationMessage = CreateUserLocationMapping(i.Id, request.CompanyId, request.CreatedBy, request.LocationList);

                string ServiceMessage = CreateUserServiceMapping(i.Id, request.CompanyId, request.CreatedBy, request.ServiceList);
            }
            return "Inserted";
        }


        public string CreateUserRoleMapping(int EmpId,int CompanyId,int CreatedBy,List<Role> request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request)
                {
                    using (conn = new SqlConnection(ConString))
                    {

                        using (cmd = new SqlCommand("[Hd-Sp-UserRoleMapping]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@EmpId", EmpId);
                            cmd.Parameters.AddWithValue("@RoleId", data.RoleId);
                            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
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
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string CreateUserLocationMapping(int EmpId, int CompanyId, int CreatedBy, List<Location> request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request)
                {
                    using (conn = new SqlConnection(ConString))
                    {

                        using (cmd = new SqlCommand("[Hd-Sp-UserRoleMapping]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 2);
                            cmd.Parameters.AddWithValue("@EmpId", EmpId);
                            cmd.Parameters.AddWithValue("@LocationId", data.Id);
                            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
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
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public string CreateUserServiceMapping(int EmpId, int CompanyId, int CreatedBy, List<ServiceModel> request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request)
                {
                    using (conn = new SqlConnection(ConString))
                    {

                        using (cmd = new SqlCommand("[Hd-Sp-UserRoleMapping]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 3);
                            cmd.Parameters.AddWithValue("@EmpId", EmpId);
                            cmd.Parameters.AddWithValue("@Service", data.ServiceID);
                            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
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
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }
    }
}