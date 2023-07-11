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
    public class CreateUserDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;

        public string CreatUser(CreateUser request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-CreateUserfromEMployee]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@UserId", request.UserId);
                        cmd.Parameters.AddWithValue("@EmailId", request.EmailId);
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@TimeZone", request.TimeZone);
                        cmd.Parameters.AddWithValue("@City", request.City);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
                        cmd.Parameters.AddWithValue("@Address", request.Address);
                        cmd.Parameters.AddWithValue("@MobileNO", request.MobileNO);
                        cmd.Parameters.AddWithValue("@Grade", request.Grade);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Department", request.Department);
                        cmd.Parameters.AddWithValue("@Designation", request.Designation);
                        cmd.Parameters.AddWithValue("@ReportingManager", request.ReportingManager);
                        cmd.Parameters.AddWithValue("@Vertical", request.Vertical);
                        cmd.Parameters.AddWithValue("@CostCenter", request.CostCenter);
                        cmd.Parameters.AddWithValue("@Password", request.Password);
                        cmd.Parameters.AddWithValue("@ChargePerHour", request.ChargePerHour);
                        cmd.Parameters.AddWithValue("@OTChargeperHour", request.OTChargeperHour);
                        cmd.Parameters.AddWithValue("@HolidatOTperHr", request.HolidatOTperHr);
                        cmd.Parameters.AddWithValue("@EmployeeType", request.EmployeeType);
                        cmd.Parameters.AddWithValue("@Shift", request.Shift);
                        cmd.Parameters.AddWithValue("@Skills", request.Skills);
                        cmd.Parameters.AddWithValue("@ServiceMapping", request.ServiceMapping);
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


        public string UpdateUser(CreateUser request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-CreateUserfromEMployee]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@UserId", request.UserId);
                        cmd.Parameters.AddWithValue("@EmailId", request.EmailId);
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@TimeZone", request.TimeZone);
                        cmd.Parameters.AddWithValue("@City", request.City);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
                        cmd.Parameters.AddWithValue("@Address", request.Address);
                        cmd.Parameters.AddWithValue("@MobileNO", request.MobileNO);
                        cmd.Parameters.AddWithValue("@Grade", request.Grade);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Department", request.Department);
                        cmd.Parameters.AddWithValue("@Designation", request.Designation);
                        cmd.Parameters.AddWithValue("@ReportingManager", request.ReportingManager);
                        cmd.Parameters.AddWithValue("@Vertical", request.Vertical);
                        cmd.Parameters.AddWithValue("@CostCenter", request.CostCenter);
                        cmd.Parameters.AddWithValue("@Password", request.Password);
                        cmd.Parameters.AddWithValue("@ChargePerHour", request.ChargePerHour);
                        cmd.Parameters.AddWithValue("@OTChargeperHour", request.OTChargeperHour);
                        cmd.Parameters.AddWithValue("@HolidatOTperHr", request.HolidatOTperHr);
                        cmd.Parameters.AddWithValue("@EmployeeType", request.EmployeeType);
                        cmd.Parameters.AddWithValue("@Shift", request.Shift);
                        cmd.Parameters.AddWithValue("@Skills", request.Skills);
                        cmd.Parameters.AddWithValue("@ServiceMapping", request.ServiceMapping);
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

        public List<CreateUser> GetUserList(int UserId, int CompanyId)
        {
            List<CreateUser> Basemodel = new List<CreateUser>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[hd-sp-CreateUserfromEMployee]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompayId", CompanyId);
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                CreateUser data = new CreateUser();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.UserId = (dr["UserId"]).ToString();
                                data.EmailId = dr["EmailId"].ToString();    
                                data.MobileNO = dr["MobileNO"].ToString();
                                data.ReportingManager = Convert.ToInt32(dr["ReportingManager"]);
                                data.Designation= Convert.ToInt32(dr["Designation"]);
                                data.Department= Convert.ToInt32(dr["Department"]);
                                data.Vertical= Convert.ToInt32(dr["Vertical"]);
                                data.CostCenter= Convert.ToInt32(dr["CostCenter"]);
                                data.ChargePerHour= Convert.ToDecimal(dr["ChargePerHour"]);     
                                data.OTChargeperHour= Convert.ToDecimal(dr["OTChargeperHour"]);     
                                data.HolidatOTperHr= Convert.ToDecimal(dr["HolidatOTperHr"]);     
                                data.Country= Convert.ToInt32(dr["Country"]);
                                data.City= Convert.ToInt32(dr["City"]);
                                data.Location= Convert.ToInt32(dr["Location"]);
                                data.Skills= Convert.ToInt32(dr["Skills"]);

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

        public List<CreateUser> GetUserdetails(int CompanyId)
        {
            List<CreateUser> Basemodel = new List<CreateUser>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[hd-sp-CreateUserfromEMployee]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                CreateUser data = new CreateUser();
                                //data.Id = Convert.ToInt32(dr["Id"]);
                                data.UserId = (dr["UserId"]).ToString();
                                //data.EmailId = dr["EmailId"].ToString();
                                //data.EmpId =Convert.ToInt32(dr["EmpId"]);
                                data.MobileNO = dr["MobileNO"].ToString();
                                //data.EmployeeType =Convert.ToInt32(dr["EmployeeType"].ToString());
                                //data.Address = dr["Address"].ToString();
                                //data.ReportingManager = Convert.ToInt32(dr["ReportingManager"]);
                                //data.Designation = Convert.ToInt32(dr["Designation"]);
                                //data.Department = Convert.ToInt32(dr["Department"]);
                                //data.Vertical = Convert.ToInt32(dr["Vertical"]);
                                //data.Grade = Convert.ToInt32(dr["Grade"]);
                                //data.CostCenter = Convert.ToInt32(dr["CostCenter"]);
                                //data.ChargePerHour = Convert.ToDecimal(dr["ChargePerHour"]);
                                //data.OTChargeperHour = Convert.ToDecimal(dr["OTChargeperHour"]);
                                //data.HolidatOTperHr = Convert.ToDecimal(dr["HolidatOTperHr"]);
                                //data.Country = Convert.ToInt32(dr["Country"]);
                                //data.TimeZone = (dr["TimeZone"]).ToString();
                                //data.City = Convert.ToInt32(dr["City"]);
                                //data.Location = Convert.ToInt32(dr["Location"]);
                                //data.Skills = Convert.ToInt32(dr["Skills"]);
                                //data.Shift = Convert.ToInt32(dr["Shift"]);
                                //data.ServiceMapping = Convert.ToInt32(dr["ServiceMapping"]);
                                data.FirstName = (dr["UserName"]).ToString();





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


        public List<RoleModel> GetRolesByUser(string UserId,int CompanyId)
        {
            List<RoleModel> Basemodel = new List<RoleModel>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[Hd-Sp-UserRights]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RoleModel data = new RoleModel();
                                data.RoleId = Convert.ToInt32(dr["RoleId"]);
                                data.Name =(dr["Name"]).ToString();
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



    }
}