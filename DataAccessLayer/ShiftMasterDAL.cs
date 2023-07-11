using HelpDeskServices.AdoConnection;
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
    public class ShiftMasterDAL
    {
        #region declaration
        AdoExcmethod spexc = new AdoExcmethod();



        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        #endregion
        public string SaveShiftMaster(ShiftMaster request)
        {
           
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ShiftMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", "");
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@FromDate", request.FromDate);
                        cmd.Parameters.AddWithValue("@Todate", request.Todate);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@Weekoff", request.Weekoff);

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

        public string UpdateShiftMaster(ShiftMaster request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ShiftMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Code", request.Code);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@FromDate", request.FromDate);
                        cmd.Parameters.AddWithValue("@Todate", request.Todate);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.ModifiedBy);
                        cmd.Parameters.AddWithValue("@Weekoff", request.Weekoff);

                        // cmd.Parameters.AddWithValue("@ModifiedOn", request.ModifiedOn);

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

        public string DeleteShiftMaster(DeleteObj request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ShiftMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", request.RecordId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        // cmd.Parameters.AddWithValue("@ModifiedOn", request.ModifiedOn);

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

        public List<ShiftMaster> Getshiftdetsils(int Id)
        {
            List<ShiftMaster> Baseresponce = new List<ShiftMaster>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ShiftMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyId", Id);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ShiftMaster data = new ShiftMaster();
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.Country = Convert.ToInt32(dr["Country"]);
                                data.Location = Convert.ToInt32(dr["Location"]);
                                data.Status = (dr["Status"]).ToString();
                                data.Code = (dr["Code"]).ToString();
                                data.Name= (dr["Name"]).ToString();
                                data.FromDate= (dr["FromDate"]).ToString();
                                data.Todate= (dr["Todate"]).ToString();
                                Baseresponce.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return Baseresponce;
        }


        public Hd_Responce getShiftbylocation(int Companyid,int Id)
        {

            Hd_Responce responce = new Hd_Responce();
            List<object> baseresponce = new List<object>();
            try
            {
                var parameters = new SqlParamDefinition[]
              {
                  new SqlParamDefinition("@Fcase",  5),
                  new SqlParamDefinition("@Location",  Id),
                  new SqlParamDefinition("@CompanyId",  Companyid)
              };
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd-sp-ShiftMaster]", parameters);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                            Id = Convert.ToInt32(rw["Id"]),
                                            Country = Convert.ToInt32(rw["Country"]),
                                            Location = Convert.ToInt32(rw["Location"]),
                                            Status = (rw["Status"]).ToString(),
                                            Code = (rw["Code"]).ToString(),
                                            Name = (rw["Name"]).ToString(),
                                            FromDate = (rw["FromDate"]).ToString(),
                                            Todate = (rw["Todate"]).ToString(),
                                         }).Distinct().ToList();
                    if (convertedList != null)
                    {
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = convertedList;
                    }
                }
            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = ex.Message;
                responce.Result = null;
            }

            return responce;
        }
    }
}