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
    public class MaintenanceSLADAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public string SaveMaintenanceSLA(MaintenanceSLA request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[hd-sp-MaintenanceSLA]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@City", request.City);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
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


        public string UpdateMaintenanceSLA(MaintenanceSLA request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[hd-sp-MaintenanceSLA]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Country", request.Country);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@City", request.City);
                        cmd.Parameters.AddWithValue("@Location", request.Location);
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


        public List<MaintenanceSLA> getMaintenanceSLA(int CompanyId)
        {
            List<MaintenanceSLA> basemodel = new List<MaintenanceSLA>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[hd-sp-MaintenanceSLA]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                MaintenanceSLA responce = new MaintenanceSLA();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                responce.Location =Convert.ToInt32(dr["Location"].ToString());
                                responce.Country =Convert.ToInt32(dr["Country"].ToString());
                                responce.City =Convert.ToInt32(dr["City"].ToString());
                                responce.CountryName =(dr["CountryName"].ToString());
                                responce.CityName =(dr["CityName"].ToString());
                                responce.LocationName =(dr["SiteName"].ToString());
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                basemodel.Add(responce);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return basemodel;
        }

    }
}