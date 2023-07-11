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
    public class ProblemDAL
    {
     
        public List<Problem> GetProblemServices(int companyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Problem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ProblemCode", "");
                        cmd.Parameters.AddWithValue("@ProblemDescription", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitId", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateProblemeObject(ds.Tables[0]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Problem> PopulateProblemeObject(DataTable dt)
        {
            List<Problem> problemObjectList = new List<Problem>();
            try
            {


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Problem problemObject = new Problem();
                        problemObject.BusinessUnitId = int.Parse(dr["BusinessUnitId"].ToString());
                        problemObject.BusinessUnitCode = dr["Description"].ToString();
                        problemObject.CompanyId = int.Parse(dr["CompanyId"].ToString());
                        problemObject.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                        problemObject.IsActive = int.Parse(dr["IsActive"].ToString());
                        problemObject.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                        problemObject.ProblemCode = dr["ProblemCode"].ToString();
                        problemObject.ProblemDescription = dr["ProblemDescription"].ToString();
                        problemObject.ProblemId = int.Parse(dr["ID"].ToString());
                        problemObject.Remark = dr["Remark"].ToString();
                        problemObject.ServiceCode = dr["ServiceDescription"].ToString();
                        problemObject.ServiceId = int.Parse(dr["ServiceId"].ToString());
                        problemObject.SubServiceCode = dr["SubServiceDescription"].ToString();
                        problemObject.SubServiceId = int.Parse(dr["SubServiceId"].ToString());

                        problemObject.UpdateOn =  dr["UpdatedOn"].ToString();
                        problemObject.CreatedOn =dr["CreatedOn"].ToString();
                        problemObjectList.Add(problemObject);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return problemObjectList;
        }

        public string InsertProblem(Problem prbObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Problem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ProblemCode", prbObj.ProblemCode);
                        cmd.Parameters.AddWithValue("@ProblemDescription", prbObj.ProblemDescription);
                        cmd.Parameters.AddWithValue("@Remarks", prbObj.Remark);
                        cmd.Parameters.AddWithValue("@ServiceId", prbObj.ServiceId);
                        cmd.Parameters.AddWithValue("@BusinessUnitId", prbObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@SubServiceId", prbObj.SubServiceId);
                        cmd.Parameters.AddWithValue("@createdby", prbObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", prbObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@IsStatus", prbObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", prbObj.ProblemId);
                        cmd.Parameters.AddWithValue("@CompanyId", prbObj.CompanyId);
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

        public string UpdateProblem(Problem prbObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Problem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ProblemCode", prbObj.ProblemCode);
                        cmd.Parameters.AddWithValue("@ProblemDescription", prbObj.ProblemDescription);
                        cmd.Parameters.AddWithValue("@Remarks", prbObj.Remark);
                        cmd.Parameters.AddWithValue("@ServiceId", prbObj.ServiceId);
                        cmd.Parameters.AddWithValue("@BusinessUnitId", prbObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@SubServiceId", prbObj.SubServiceId);
                        cmd.Parameters.AddWithValue("@createdby", prbObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", prbObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@IsStatus", prbObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", prbObj.ProblemId);
                        cmd.Parameters.AddWithValue("@CompanyId", prbObj.CompanyId);
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

        public string DeleteProblemRecordById(int problemId,int CompanyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Problem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.Parameters.AddWithValue("@ID", problemId);
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
            return "No records Found";
        }

        public List<Problem> GetProblembysubservice(int companyId,int Id)
        {
            List<Problem> basemodel = new List<Problem>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Problem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@ProblemCode", "");
                        cmd.Parameters.AddWithValue("@ProblemDescription", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitId", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                Problem data = new Problem();

                                data.ProblemId = Convert.ToInt32(dr["ID"]);
                                data.ProblemDescription = dr["ProblemDescription"].ToString();
                                basemodel.Add(data);
                            }

                        }


                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return basemodel;
        }
    }
}