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
    public class SlaTimeDefinationDAL
    {

        public string insertSLATimeDefination(SlaTimeDefinationModel timedefination)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_sla_time_defination", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CountryId", timedefination.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", timedefination.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", timedefination.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", timedefination.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", timedefination.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", timedefination.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", timedefination.ProblemId);
                        cmd.Parameters.AddWithValue("@CompanyId", timedefination.CompanyId);
                        cmd.Parameters.AddWithValue("@createdBy", timedefination.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", timedefination.UpdatedBy);

                        cmd.Parameters.AddWithValue("@ID", timedefination.SlaTimeDefinationId);
                        
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);




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
                throw;
            }

            return "";

        }

        public string UpdateSLATimeDefination(SlaTimeDefinationModel slatimeModel)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_sla_time_defination", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CountryId", slatimeModel.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", slatimeModel.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", slatimeModel.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", slatimeModel.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", slatimeModel.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", slatimeModel.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", slatimeModel.ProblemId);
                        cmd.Parameters.AddWithValue("@CompanyId", slatimeModel.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", slatimeModel.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", slatimeModel.UpdatedBy);
                        cmd.Parameters.AddWithValue("@ID", slatimeModel.SlaTimeDefinationId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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
                throw;
            }

            return "";

        }


        public List<SlaTimeDefinationModel> GetSLATimeDefination(int companyId)
        {
            List<SlaTimeDefinationModel> slatimeList = new List<SlaTimeDefinationModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_sla_time_defination", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CityId", 0);
                        cmd.Parameters.AddWithValue("@LocationId", 0);
                        cmd.Parameters.AddWithValue("@BusinessId", 0);
                        cmd.Parameters.AddWithValue("@ServiceId", 0);
                        cmd.Parameters.AddWithValue("@SubServiceId", 0);
                        cmd.Parameters.AddWithValue("@ProblemId", 0);
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                    
                        cmd.Parameters.AddWithValue("@ID", 0);

                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SlaTimeDefinationModel SlaTimeObj = new SlaTimeDefinationModel();
                                SlaTimeObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                SlaTimeObj.SlaTimeDefinationId = int.Parse(dr["Sla_Time_Defination_Id"].ToString());
                                SlaTimeObj.CountryCode = dr["CountryName"].ToString();
                                SlaTimeObj.CountryId = dr["CountryCode"].ToString();
                                SlaTimeObj.CityName = dr["CityName"].ToString();
                                SlaTimeObj.CityId = dr["CityCode"].ToString();
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                SlaTimeObj.ServiceId = int.Parse(dr["ServiceId"].ToString());
                                SlaTimeObj.ServiceName = dr["ServiceDescription"].ToString();
                                SlaTimeObj.SubServiceID = int.Parse(dr["SubServiceId"].ToString());
                                SlaTimeObj.SubServiceName = dr["SubServiceDescription"].ToString();
                                SlaTimeObj.ProblemId = int.Parse(dr["Problem"].ToString());
                                SlaTimeObj.ProblemName = dr["ProblemDescription"].ToString();
                                SlaTimeObj.BusinessUnitId = int.Parse(dr["BusinessId"].ToString());
                                SlaTimeObj.BusinessUnitName = dr["BusinessDescription"].ToString();
                                SlaTimeObj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                slatimeList.Add(SlaTimeObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return slatimeList;

        }

        public string DeleteSLATimeDefination(int recordId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_sla_time_defination", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", recordId);

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
                throw;
            }

            return "No records Found";

        }
    }
}