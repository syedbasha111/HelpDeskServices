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
    public class RoomMasterDAL
    {
        public string CreateRoomMaster(RoomMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", "");
                        cmd.Parameters.AddWithValue("@RoomCode", request.RoomCode);
                        cmd.Parameters.AddWithValue("@RoomName",request.RoomName);
                        cmd.Parameters.AddWithValue("@RoomId",request.RoomId);
                        cmd.Parameters.AddWithValue("@RoomNumber", request.RoomNumber);
                        cmd.Parameters.AddWithValue("@Remarks",request.Remarks);
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
                        cmd.Parameters.AddWithValue("@FloorId", request.FloorId);
                        cmd.Parameters.AddWithValue("@AreaId", request.AreaId);

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

        public string UpdateRoomMaster(RoomMasterModel request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", request.ID);
                        cmd.Parameters.AddWithValue("@RoomCode", request.RoomCode);
                        cmd.Parameters.AddWithValue("@RoomName", request.RoomName);
                        cmd.Parameters.AddWithValue("@RoomId", request.RoomId);
                        cmd.Parameters.AddWithValue("@RoomNumber", request.RoomNumber);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.Companyid);
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
                        cmd.Parameters.AddWithValue("@FloorId", request.FloorId);
                        cmd.Parameters.AddWithValue("@AreaId", request.AreaId);

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


        public string deleteRoomMaster(int Id)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);

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


        public List<RoomMasterModel> GetRoomMaster(int companyId)
        {
            List<RoomMasterModel> baseModel = new List<RoomMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id","");
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RoomMasterModel data = new RoomMasterModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.RoomName = dr["RoomName"].ToString();
                                data.RoomCode = dr["RoomCode"].ToString();
                                data.RoomTypeName = dr["RoomTypeName"].ToString();
                                data.RoomNumber = dr["RoomNumber"].ToString();
                                data.RoomId = Convert.ToInt32( dr["RoomTypeId"].ToString());
                                data.AreaName = dr["AreaName"].ToString();
                                data.FloorName = dr["FloorName"].ToString();
                                data.CountryName = dr["CountryName"].ToString();
                                data.RegionName = dr["RegionName"].ToString();
                                data.CityName = dr["CityName"].ToString();
                                data.SiteName = dr["SiteName"].ToString();
                                data.ZoneName = dr["ZoneName"].ToString();
                                data.DistrictName = dr["DistrictName"].ToString();
                                data.BuildingName = dr["BuildingName"].ToString();
                                data.BuildingId = Convert.ToInt32(dr["BuildingId"]);
                                data.AreaId = Convert.ToInt32(dr["AreaId"]);
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

        public SiteMasterDropdownlist GetdetailsbyRoomType(int companyId, int Id)
        {
            SiteMasterDropdownlist response = new SiteMasterDropdownlist();
            response.AreaModelList = AreaName(companyId, Id);
            response.FloorModelList = FloorName(companyId, Id);
            response.BuildingModelList = BuildingName(companyId, Id);
            response.ZoneModelList = ZoneName(companyId, Id);
            response.SiteModelList = Sitename(companyId, Id);
            response.DistrictModelList = districtname(companyId, Id);
            response.cityModelList = Cityname(companyId, Id);
            response.RegoinModelList = RegionName(companyId, Id);
            response.CountryModelList = CountryName(companyId, Id);
            return response;
        }
        internal List<AreaMasterModel> AreaName(int companyId, int Id)
        {
            List<AreaMasterModel> districtresponce = new List<AreaMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                AreaMasterModel Districtobj = new AreaMasterModel();

                                Districtobj.ID = int.Parse(dr["AreaId"].ToString());
                                // Districtobj.SiteCode = dr["Sitecode"].ToString();
                                Districtobj.AreaName = dr["AreaName"].ToString();

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
        internal List<FloorMasterModel> FloorName(int companyId, int Id)
        {
            List<FloorMasterModel> districtresponce = new List<FloorMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FloorMasterModel Districtobj = new FloorMasterModel();

                                Districtobj.ID = int.Parse(dr["FloorId"].ToString());
                                // Districtobj.SiteCode = dr["Sitecode"].ToString();
                                Districtobj.FloorName = dr["FloorName"].ToString();

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

        internal List<BuildingModel> BuildingName(int companyId, int Id)
        {
            List<BuildingModel> districtresponce = new List<BuildingModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                BuildingModel Districtobj = new BuildingModel();

                                Districtobj.ID = int.Parse(dr["BuildingId"].ToString());
                                // Districtobj.SiteCode = dr["Sitecode"].ToString();
                                Districtobj.BuildingName = dr["BuildingName"].ToString();

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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);

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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


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
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


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

        public List<RoomMasterModel> GetRoomNameBYAreaid(int companyId,int Id)
        {
            List<RoomMasterModel> baseModel = new List<RoomMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@Id",Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
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
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RoomMasterModel data = new RoomMasterModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.RoomName = dr["RoomName"].ToString();
                                data.RoomCode = dr["RoomCode"].ToString();


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