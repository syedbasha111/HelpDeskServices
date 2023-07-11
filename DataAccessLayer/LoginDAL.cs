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
    public class LoginDAL
    {
        public List<Login> Login(Login request)
        {
            List<Login> baseresponce = new List<Login>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@PassWord", request.Password);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        string responce1 = dt.Rows[0][0].ToString();
                        if (dt.Rows.Count > 0 && responce1 != "login fails")
                        {


                            foreach (DataRow dr in dt.Rows)
                            {
                                Login responce = new Login();
                                responce.UserId = dr["UserId"].ToString();
                                responce.UserName = dr["UserName"].ToString();
                                responce.CompanyId = dr["CmpyCode"].ToString();
                                //responce.UserId = dr["UserId"].ToString();
                                responce.Designation= dr["Designation"].ToString();
                                responce.Department = dr["Department"].ToString();
                                responce.ReportingTo = dr["ReportingPerson"].ToString();
                                responce.Email = dr["EmailId"].ToString();
                                baseresponce.Add(responce);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

                return baseresponce;

        }

        public string PasswordRecovery(User request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@PassWord", request.Password);
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



        public string saveLogindetails(Loginrecords request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@LoginId", request.LoginId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
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

        public string UpdateLogindetails(Loginrecords request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@LoginId", request.LoginId);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
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

        public List<User> GetListOfEmployees(int CompanyId)
        {
            List<User> Basemodel = new List<User>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                User responce = new User();
                                responce.UserId = Convert.ToInt32(dr["UserId"]);
                                responce.UserName = (dr["UserName"]).ToString();
                                Basemodel.Add(responce);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return Basemodel;

        }

        public List<Loginrecords> GetLoginUserslist(Loginrecords req)
        {
            List<Loginrecords> Basemodel = new List<Loginrecords>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@LoginId", req.LoginId);
                        cmd.Parameters.AddWithValue("@CompanyId", req.CompanyId);
                        cmd.Parameters.AddWithValue("@LoginTime", req.LoginTime);
                        cmd.Parameters.AddWithValue("@LogoutTime", req.LogOutTime);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Loginrecords responce = new Loginrecords();
                                responce.LoginId = Convert.ToInt32(dr["Id"]);
                                responce.UserName = (dr["FirstName"]).ToString();
                                responce.EmailId = (dr["EmailId"]).ToString();
                                //responce.LoginTime = Convert.ToDateTime(dr["LoginTime"].ToString());
                                //responce.LogOutTime = (dr["LogOutTime"].Equals(DBNull.Value)) ? Convert.ToDateTime(dr["LogOutTime"]).ToString() : null ;


                                if (dr["LoginTime"].Equals(DBNull.Value))
                                {
                                    responce.LoginTime = null;
                                }
                                else
                                {
                                    responce.LoginTime = Convert.ToDateTime(dr["LoginTime"]);
                                }

                                if (dr["LogOutTime"].Equals(DBNull.Value))
                                {
                                    responce.LogOutTime = null;
                                }
                                else
                                {
                                    responce.LogOutTime = Convert.ToDateTime(dr["LogOutTime"]);
                                }
                                Basemodel.Add(responce);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return Basemodel;

        }



        public Login Getuserdetails(int CompanyId, int UserId)
        {
            Login baseresponce = new Login();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-Login]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@LoginId", UserId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {


                            foreach (DataRow dr in dt.Rows)
                            {

                                baseresponce.UserName = dt.Rows[0]["UserName"].ToString();
                                baseresponce.CompanyName = dt.Rows[0]["Name"].ToString();
                                //responce.UserId = dr["UserId"].ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                
            }

            return baseresponce;

        }
    }
}