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
    public class RegionMasterDAL
    {

        public string CreateRegion(RegionModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Region", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", request.CompanyId);
                        cmd.Parameters.AddWithValue("@RegionCode", request.RegionCode);
                        cmd.Parameters.AddWithValue("@RegionName", request.RegionName);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CountryId", request.CountryId);
                        cmd.Parameters.AddWithValue("@DistrictId", request.DistrictId);
                        cmd.Parameters.AddWithValue("@StateId", request.StateId);
                        cmd.Parameters.AddWithValue("@CityId", request.CityId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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

        public string UpdateRegion(RegionModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Region", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", request.RegionId);
                        cmd.Parameters.AddWithValue("@RegionCode", request.RegionCode);
                        cmd.Parameters.AddWithValue("@RegionName", request.RegionName);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CountryId", request.CountryId);
                        cmd.Parameters.AddWithValue("@DistrictId", request.DistrictId);
                        cmd.Parameters.AddWithValue("@StateId", request.StateId);
                        cmd.Parameters.AddWithValue("@CityId", request.CityId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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


        public List<RegionModel> GetRegionMaster(int companyId)
        {
            List<RegionModel> DistrictobjList = new List<RegionModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Region", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@RegionCode", "");
                        cmd.Parameters.AddWithValue("@RegionName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@DistrictId", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
                        cmd.Parameters.AddWithValue("@CityId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RegionModel Districtobj = new RegionModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Districtobj.RegionId = int.Parse(dr["RegionId"].ToString());
                                Districtobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Districtobj.StateId = (dr["StateId"].Equals(DBNull.Value)?0: Convert.ToInt32(dr["StateId"]));
                                Districtobj.CityId = dr["CityId"].Equals(DBNull.Value) ? 0 : int.Parse(dr["CityId"].ToString());
                                Districtobj.DistrictId = dr["DistrictId"].Equals(DBNull.Value) ? 0 : int.Parse(dr["DistrictId"].ToString());
                                Districtobj.RegionCode = dr["RegionCode"].ToString();
                                Districtobj.RegionName = dr["RegionName"].ToString();
                                Districtobj.Remarks = dr["Remarks"].ToString();
                                Districtobj.IsActive =Convert.ToBoolean( dr["IsActive"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                Districtobj.CountryName = dr["CountryName"].ToString();
                                Districtobj.DistrictName = dr["DistrictName"].ToString();



                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                DistrictobjList.Add(Districtobj);
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

        public List<RegionModel> GetRegions(RegionModel request)
        {
            List<RegionModel> DistrictobjList = new List<RegionModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Region", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@RegionCode", "");
                        cmd.Parameters.AddWithValue("@RegionName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CountryId", request.CountryId);
                        cmd.Parameters.AddWithValue("@DistrictId", request.DistrictId);

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RegionModel Districtobj = new RegionModel();
                                Districtobj.RegionId = int.Parse(dr["RegionId"].ToString());
                                Districtobj.RegionCode = dr["RegionCode"].ToString();
                                Districtobj.RegionName = dr["RegionName"].ToString();

                                DistrictobjList.Add(Districtobj);
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

        public string DeleteRegion(int Id)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Region", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@RegionCode", "");
                        cmd.Parameters.AddWithValue("@RegionName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@DistrictId", 0);
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