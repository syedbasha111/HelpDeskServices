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
    public class ServiceEscalationDAL
    {
        public string insertServiceEscaltion(ServiceEscalationModel escalation)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CountryId", escalation.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", escalation.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", escalation.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", escalation.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", escalation.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", escalation.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", escalation.ProblemId);
                        cmd.Parameters.AddWithValue("@Companyid", escalation.CompanyId);
                        cmd.Parameters.AddWithValue("@createdBy", escalation.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", escalation.UpdatedBy);
                    
                        cmd.Parameters.AddWithValue("@ID", escalation.ServiceEscalationId);
                       
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

        public string UpdateServiceEscaltion(ServiceEscalationModel escalation)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CountryId", escalation.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", escalation.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", escalation.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", escalation.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", escalation.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", escalation.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", escalation.ProblemId);
                        cmd.Parameters.AddWithValue("@Companyid", escalation.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", escalation.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", escalation.UpdatedBy);
                        cmd.Parameters.AddWithValue("@ID", escalation.ServiceEscalationId);
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


        public List<ServiceEscalationModel> GetServiceEscalation(int companyId)
        {
            List<ServiceEscalationModel> escalationsList = new List<ServiceEscalationModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
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
                        cmd.Parameters.AddWithValue("@ProblemId",0);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@createdBy",0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);

                        cmd.Parameters.AddWithValue("@ID", 0);

                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ServiceEscalationModel escalationObj = new ServiceEscalationModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                escalationObj.ServiceEscalationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                escalationObj.CountryCode = dr["CountryName"].ToString();
                                escalationObj.CountryId = dr["CountryCode"].ToString();
                                escalationObj.CityName = dr["CityName"].ToString();
                                escalationObj.CityId =dr["CityCode"].ToString();
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                escalationObj.ServiceId = int.Parse(dr["ServiceId"].ToString());
                                escalationObj.ServiceName = dr["ServiceDescription"].ToString();
                                escalationObj.SubServiceID = int.Parse(dr["SubServiceId"].ToString());
                                escalationObj.SubServiceName = dr["SubServiceDescription"].ToString();
                                escalationObj.ProblemId = int.Parse(dr["Problem"].ToString());
                                escalationObj.ProblemName = dr["ProblemDescription"].ToString();
                                escalationObj.BusinessUnitId = int.Parse(dr["BusinessId"].ToString());
                                escalationObj.BusinessUnitName = dr["BusinessDescription"].ToString();
                                escalationObj.CompanyId =int.Parse(dr["CompanyId"].ToString());
                                

                                escalationsList.Add(escalationObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return escalationsList;

        }

        public string DeleteServiceEscalation(int recordId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
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