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
    public class AddNewUserDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;

        public List<Employeetype> GetEmaployeeType(int companyId)
        {
            List<Employeetype> Basemodel = new List<Employeetype>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[hd-sp-CreateNewUser]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CompayId", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Employeetype data = new Employeetype();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Code = (dr["Code"]).ToString();
                                data.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                                data.EmployeeType = (dr["EmployeeType"].ToString());
                                data.Remarks = (dr["Remarks"].ToString());
                                data.Status =Convert.ToBoolean(dr["Status"]);
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

        public List<NewUser> GetEmployeList(int companyId)
        {
            List<NewUser> Basemodel = new List<NewUser>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[hd-sp-CreateNewUser]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase",4 );
                        cmd.Parameters.AddWithValue("@CompayId", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                NewUser data = new NewUser();
                                data.Id = Convert.ToInt32(dr["EmployeeId"]);
                                data.EmpCode = (dr["EmployeeCode"]).ToString();
                                //data.EmailId = (dr["EmailId"]).ToString();
                                data.MobileNO = (dr["MobileNO"]).ToString();
                                data.FirstName = (dr["EmployeeName"].ToString());
                                //data.EmpId= (dr["EmpId"]).ToString();
                                //data.Title= (dr["Title"]).ToString();
                               // data.MiddleName= (dr["MiddleName"]).ToString();
                                //data.LastName= (dr["LastName"]).ToString();
                               // data.Country= Convert.ToInt32(dr["Country"]);
                               // data.TimeZone= dr["TimeZone"].ToString();
                               // data.City = Convert.ToInt32(dr["City"]);
                               // data.Location= Convert.ToInt32(dr["Location"]);
                               // data.Address = dr["Address"].ToString();
                               // data.MobileNO= dr["MobileNO"].ToString();
                               // data.Grade= Convert.ToInt32(dr["Grade"]);
                               // data.CompanyId= Convert.ToInt32(dr["CompanyId"]);
                               // data.Department= Convert.ToInt32(dr["Department"]);
                               // data.Designation= Convert.ToInt32(dr["Designation"]);
                               // data.ReportingManager= Convert.ToInt32(dr["ReportingManager"]);
                               // data.Vertical= Convert.ToInt32(dr["Vertical"]);
                               // data.CostCenter= Convert.ToInt32(dr["CostCenter"]);
                               // data.Password= (dr["Password"]).ToString();
                               // data.ChargePerHour=Convert.ToDecimal(dr["ChargePerHour"]);
                               // data.OTChargeperHour=Convert.ToDecimal(dr["OTChargeperHour"]);
                               // data.HolidatOTperHr=Convert.ToDecimal(dr["HolidatOTperHr"]);
                               // data.EmployeeType=Convert.ToInt32(dr["EmployeeType"]);
                               // data.Shift=Convert.ToInt32(dr["Shift"]);
                               // data.Skills=Convert.ToInt32(dr["Skills"]);
                               // data.ServiceMapping=Convert.ToInt32(dr["ServiceMapping"]);

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

        public string CreatNewUser(NewUser request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-CreateNewUser]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",2);
                        cmd.Parameters.AddWithValue("@EmpCode", request.EmpCode);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@Title", request.Title);
                        cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", request.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", request.LastName);
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

        public string UpdateNewUser(NewUser request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("[hd-sp-CreateNewUser]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@EmpCode", request.EmpCode);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@EmpId", request.EmpId);
                        cmd.Parameters.AddWithValue("@Title", request.Title);
                        cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", request.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", request.LastName);
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

        #region gettingDropdownValues

        public List<Grade> Getgrde(int companyId)
        {
            List<Grade> baseModel = new List<Grade>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [Hd-Tbl-Grade] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", companyId);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Grade data = new Grade();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.gradedetail = dr["Grade"].ToString();
                                baseModel.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // throw;
            }
            return baseModel;
        }

        public List<ReportingManager> GetReportingmanger(int CompanyId)
        {
            List<ReportingManager> baseModel = new List<ReportingManager>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-Sp-ReportingManager]", conn))
                    {
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@Fcase", 2);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ReportingManager data = new ReportingManager();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.EmpId = Convert.ToInt32(dr["EmpId"]);
                                data.ReportingManagerName = dr["EmployeeName"].ToString();
                                data.Status =Convert.ToBoolean(dr["Status"].ToString());
                                data.Remarks =(dr["Remarks"].ToString());
                                baseModel.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return baseModel;
        }

        public List<Vertical> GetVertical(int CompanyId)
        {
            List<Vertical> baseModel = new List<Vertical>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [Hd-tbl-Vertical] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", CompanyId);

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Vertical data = new Vertical();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Vertiacal = dr["Vertiacal"].ToString();
                                baseModel.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // throw;
            }
            return baseModel;
        }

        public List<CostCenter> Getcostcenter(int CompanyId)
        {
            List<CostCenter> baseModel = new List<CostCenter>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [Hd-tbl-CostCenter] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", CompanyId);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                CostCenter data = new CostCenter();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.CostCenterdetails = dr["CostCenter"].ToString();
                                baseModel.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // throw;
            }
            return baseModel;
        }

        public List<Skills> GetSkills(int CompanyId)
        {
            List<Skills> baseModel = new List<Skills>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [Hd-tbl-Skills] where CompanyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", CompanyId);

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Skills data = new Skills();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Skillsdetails = dr["Skills"].ToString();
                                baseModel.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return baseModel;
        }

        #endregion

    }
}