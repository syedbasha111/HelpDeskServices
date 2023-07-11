﻿using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer
{
    public class FloorMasterDAL
    {
        public string InsertFloordetails(FloorMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", "");
                        cmd.Parameters.AddWithValue("@FloorCode",request.FloorCode);
                        cmd.Parameters.AddWithValue("@FloorName",request.FloorName);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", request.Companyid);
                        cmd.Parameters.AddWithValue("@IsDeleted", request.IsDeleted);
                        cmd.Parameters.AddWithValue("@SiteId", request.SiteId);
                        cmd.Parameters.AddWithValue("@cityID", request.cityID);
                        cmd.Parameters.AddWithValue("@CountryID", request.CountryID);
                        cmd.Parameters.AddWithValue("@DistrictID", request.DistrictID);
                        cmd.Parameters.AddWithValue("@RegionID", request.RegionID);
                        cmd.Parameters.AddWithValue("@ZoneId", request.ZoneId);
                        cmd.Parameters.AddWithValue("@BuildingId", request.BuildingId);

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

        public string UpdateFloordetails(FloorMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", request.ID);
                        cmd.Parameters.AddWithValue("@FloorCode", request.FloorCode);
                        cmd.Parameters.AddWithValue("@FloorName", request.FloorName);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", "");
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", request.Companyid);
                        cmd.Parameters.AddWithValue("@IsDeleted", request.IsDeleted);
                        cmd.Parameters.AddWithValue("@SiteId", request.SiteId);
                        cmd.Parameters.AddWithValue("@cityID", request.cityID);
                        cmd.Parameters.AddWithValue("@CountryID", request.CountryID);
                        cmd.Parameters.AddWithValue("@DistrictID", request.DistrictID);
                        cmd.Parameters.AddWithValue("@RegionID", request.RegionID);
                        cmd.Parameters.AddWithValue("@ZoneId", request.ZoneId);
                        cmd.Parameters.AddWithValue("@BuildingId", request.BuildingId);

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

        public string deleteFloorMaster(int Id)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", "");
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);

                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



                        cmd.CommandType = CommandType.StoredProcedure;
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

        public List<FloorMasterModel> GetFloorMaster(int companyId)
        {
            List<FloorMasterModel> baseModel = new List<FloorMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", "");
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FloorMasterModel data = new FloorMasterModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.FloorCode = dr["FloorCode"].ToString();
                                data.FloorName = dr["FloorName"].ToString();
                                data.CountryName = dr["CountryName"].ToString();
                                data.RegionName = dr["RegionName"].ToString();
                                data.CityName = dr["CityName"].ToString();
                                data.SiteName = dr["SiteName"].ToString();
                                data.ZoneName = dr["ZoneName"].ToString();
                                data.DistrictName = dr["DistrictName"].ToString();
                                data.BuildingName = dr["BuildingName"].ToString();
                                data.BuildingId = Convert.ToInt32(dr["BuildingId"]);
                                data.ZoneId = Convert.ToInt32(dr["ZoneId"]);
                                data.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                data.Remarks = dr["Remarks"].ToString();


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }

        public SiteMasterDropdownlist GetDetailsbybuildingid(int companyId, int Id)
        {
            SiteMasterDropdownlist response = new SiteMasterDropdownlist();
            response.ZoneModelList = ZoneName(companyId, Id);
            response.SiteModelList = Sitename(companyId, Id);
            response.DistrictModelList = districtname(companyId, Id);
            response.cityModelList = Cityname(companyId, Id);
            response.RegoinModelList = RegionName(companyId, Id);
            response.CountryModelList = CountryName(companyId, Id);
            return response;
        }
        internal List<ZoneModel> ZoneName(int companyId, int Id)
        {
            List<ZoneModel> districtresponce = new List<ZoneModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ZoneModel Districtobj = new ZoneModel();

                                Districtobj.ID = int.Parse(dr["ZoneId"].ToString());
                                // Districtobj.SiteCode = dr["Sitecode"].ToString();
                                Districtobj.ZoneName = dr["ZoneName"].ToString();

                                districtresponce.Add(Districtobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return districtresponce;
        }

        internal List<SiteMasterModel> Sitename(int companyId, int Id)
        {
            List<SiteMasterModel> districtresponce = new List<SiteMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SiteMasterModel Districtobj = new SiteMasterModel();

                                Districtobj.ID = int.Parse(dr["SiteId"].ToString());
                                // Districtobj.SiteCode = dr["Sitecode"].ToString();
                                Districtobj.SiteName = dr["SiteName"].ToString();

                                districtresponce.Add(Districtobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return districtresponce;
        }

        internal List<DistrictModel> districtname(int companyId, int Id)
        {
            List<DistrictModel> districtresponce = new List<DistrictModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                DistrictModel Districtobj = new DistrictModel();

                                Districtobj.DistrictId = int.Parse(dr["DistrictId"].ToString());
                                //Districtobj.DistrictCode = dr["DistrictCode"].ToString();
                                Districtobj.DistrictName = dr["DistrictName"].ToString();

                                districtresponce.Add(Districtobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return districtresponce;
        }

        internal List<CityModel> Cityname(int companyId, int Id)
        {
            List<CityModel> responce = new List<CityModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CityModel data = new CityModel();

                                data.CityId = int.Parse(dr["CityId"].ToString());
                                //data.CityCode = dr["CityCode"].ToString();
                                data.CityName = dr["CityName"].ToString();

                                responce.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return responce;
        }

        internal List<RegionModel> RegionName(int companyId, int Id)
        {
            List<RegionModel> responce = new List<RegionModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RegionModel data = new RegionModel();

                                data.RegionId = int.Parse(dr["RegionId"].ToString());
                                //data.RegionCode = dr["RegionCode"].ToString();
                                data.RegionName = dr["RegionName"].ToString();

                                responce.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return responce;
        }

        internal List<CountryModel> CountryName(int companyId, int Id)
        {
            List<CountryModel> responce = new List<CountryModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CountryModel data = new CountryModel();

                                data.CountryId = int.Parse(dr["CountryId"].ToString());
                                //data.CountryCode = dr["CountryCode"].ToString();
                                data.CountryName = dr["CountryName"].ToString();

                                responce.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return responce;
        }

        public List<FloorMasterModel> GetFloorbybuildingid(int companyId,int Id)
        {
            List<FloorMasterModel> baseModel = new List<FloorMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_Floor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@ID",Id);
                        cmd.Parameters.AddWithValue("@FloorCode", "");
                        cmd.Parameters.AddWithValue("@FloorName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FloorMasterModel data = new FloorMasterModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.FloorCode = dr["FloorCode"].ToString();
                                data.FloorName = dr["FloorName"].ToString();
                                data.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                data.Remarks = dr["Remarks"].ToString();


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }
    }
}