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
    public class SRAssignMasterDAL
    {

        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;


        public List<NewUser> GetEmaployeeBysite(int SiteId, int CompanyId)
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
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@Id", SiteId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                NewUser data = new NewUser();
                                data.Id = Convert.ToInt32(dr["EmployeeId"]);
                                data.FirstName = (dr["EmployeeName"]).ToString();
                                data.EmpCode = (dr["EmployeeCode"]).ToString();
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

        public string SaveSrAssignMaster(SrAssignmaster request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request.ServiceList)
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        conn.Open();

                        using (cmd = new SqlCommand("[Hd-Sp-SrAssignMaster]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@EmpId", request.EmployeeId);
                            cmd.Parameters.AddWithValue("@SIte", request.Site);
                            cmd.Parameters.AddWithValue("@ServiceId", data.ServiceID);
                            cmd.Parameters.AddWithValue("@CompanyId", request.companyId);
                            cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
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
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }

        public List<NewUser> GetEmployeebyService(int ServiceId, int CompanyId)
        {
            List<NewUser> Basemodel = new List<NewUser>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[Hd-Sp-SrAssignMaster]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                NewUser data = new NewUser();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.FirstName = (dr["EmployeeName"]).ToString();
                                data.LastName = "";
                                data.EmpCode = (dr["EmployeeCode"].ToString());
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


        public HD_BaseModel createSiteEmployeeMapping(SiteEmpMapping request)
        {
            //RoleModel[] model = new RoleModel[] { };
            HD_BaseModel model = new HD_BaseModel();
            try
            {
                DataTable dt = new DataTable();
                
                    using (conn = new SqlConnection(ConString))
                    {
                        conn.Open();

                        using (cmd = new SqlCommand("[Hd-Sp-SrAssignMaster]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase",3 );
                            cmd.Parameters.AddWithValue("@EmpId", request.EmployeeId);
                            cmd.Parameters.AddWithValue("@SIte", request.SiteId);
                            cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                            cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();

                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
             
                if (dt.Rows.Count > 0)
                {
                    model.status= dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                model.status=ex.Message;
            }

            return model;

        }

    }
}