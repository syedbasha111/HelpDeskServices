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
    public class SiteMasterDAL
    {

        public string CreateSiteMaster(SiteMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_SiteMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@SiteCode", request.SiteCode);
                        cmd.Parameters.AddWithValue("@SiteName", request.SiteName);
                        cmd.Parameters.AddWithValue("@CountryID", request.CountryID);
                        cmd.Parameters.AddWithValue("@DistrictID", request.DistrictID);
                        cmd.Parameters.AddWithValue("@cityID", request.cityID);
                        cmd.Parameters.AddWithValue("@RegionID", request.RegionID);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@Companyid", request.Companyid);
                        cmd.Parameters.AddWithValue("@StateID", request.StateID);
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", request.IsDeleted);

                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



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

        public string UpdateSiteMaster(SiteMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_SiteMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@SiteCode", request.SiteCode);
                        cmd.Parameters.AddWithValue("@SiteName", request.SiteName);
                        cmd.Parameters.AddWithValue("@CountryID", request.CountryID);
                        cmd.Parameters.AddWithValue("@StateID", request.StateID);
                        cmd.Parameters.AddWithValue("@DistrictID", request.DistrictID);
                        cmd.Parameters.AddWithValue("@cityID", request.cityID);
                        cmd.Parameters.AddWithValue("@RegionID", request.RegionID);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@Companyid", request.Companyid);
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ID", request.ID);
                        cmd.Parameters.AddWithValue("@IsDeleted", request.IsDeleted);

                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



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

        public List<SiteMasterModel> GetSiteMaster(int companyId)
        {
            List<SiteMasterModel> DistrictobjList = new List<SiteMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_SiteMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@SiteCode", 0);
                        cmd.Parameters.AddWithValue("@SiteName", 0);
                        cmd.Parameters.AddWithValue("@CountryID",0);
                        cmd.Parameters.AddWithValue("@StateID",0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@Remarks",0);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SiteMasterModel data = new SiteMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                data.ID = int.Parse(dr["ID"].ToString());
                                data.SiteCode= dr["SiteCode"].ToString();
                                data.SiteName = dr["SiteName"].ToString();
                                data.IsActive =Convert.ToBoolean( dr["IsActive"].ToString());
                                data.Remarks = dr["Remarks"].ToString();
                                data.CountryName = dr["CountryName"].ToString();
                                data.CountryID =Convert.ToInt32( dr["CountryID"]);
                                data.StateID = Convert.ToInt32(dr["StateID"].ToString());
                                data.cityID = Convert.ToInt32(dr["CityID"].ToString());
                                data.DistrictID = Convert.ToInt32(dr["DistrictID"].ToString());
                                data.RegionID= Convert.ToInt32(dr["RegionID"].ToString());
                                data.CityName = dr["CityName"].ToString();
                                data.DistrictName = dr["DistrictName"].ToString();
                                data.Lat = dr["Lat"].ToString();
                                data.Lng = dr["Lng"].ToString();

                                DistrictobjList.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return DistrictobjList;

        }

        public string DeleteSiteMaster(int Id)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_SiteMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@SiteCode", 0);
                        cmd.Parameters.AddWithValue("@SiteName", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@StateID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@Remarks", 0);
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);


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