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
    public class CountryMasterDAL
    {
        public string insertCountryMaster(CountryModel countryobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Country", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CountryCode", countryobj.CountryCode);
                        cmd.Parameters.AddWithValue("@CountryName", countryobj.CountryName);
                        cmd.Parameters.AddWithValue("@Remarks", countryobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", countryobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", countryobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", countryobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", countryobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", countryobj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", countryobj.CountryCost);



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

        public List<CountryModel> GetCountryMaster(int companyId)
        {
            List<CountryModel> CountryobjList = new List<CountryModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Country", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CountryCode", "");
                        cmd.Parameters.AddWithValue("@CountryName","");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", countryobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", countryobj.CountryCost);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CountryModel Countryobj = new CountryModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Countryobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Countryobj.CountryCode = dr["CountryCode"].ToString();
                                Countryobj.CountryName = dr["CountryName"].ToString();
                                Countryobj.Remarks = dr["Remarks"].ToString();
                                Countryobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                               
                                Countryobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Countryobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Countryobj.IsActive = bool.Parse(dr["IsActive"].ToString());
                            

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                CountryobjList.Add(Countryobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return CountryobjList;

        }

        public string updateCountryMaster(CountryModel countryobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Country", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", countryobj.CountryId);
                        cmd.Parameters.AddWithValue("@CountryCode", countryobj.CountryCode);
                        cmd.Parameters.AddWithValue("@CountryName", countryobj.CountryName);
                        cmd.Parameters.AddWithValue("@Remarks", countryobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", countryobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", countryobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", countryobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", countryobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", countryobj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", countryobj.CountryCost);



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


        public string deleteCountryMaster(DeleteObj deleteObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Country", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", deleteObj.RecordId);
                        cmd.Parameters.AddWithValue("@CountryCode", "");
                        cmd.Parameters.AddWithValue("@CountryName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", countryobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", deleteObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", countryobj.CountryCost);



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
    }
}