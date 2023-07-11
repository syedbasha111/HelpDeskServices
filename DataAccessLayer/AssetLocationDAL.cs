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
    public class AssetLocationDAL
    {
        public List<AssetLocation> GetAssetLocations(int companyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Asset_Location", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@AssetLocatonCode", "");
                        cmd.Parameters.AddWithValue("@AssetLocationDescription", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateAssetLocationObject(ds.Tables[0]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<AssetLocation> PopulateAssetLocationObject(DataTable dt)
        {
            List<AssetLocation> assetLocationObjList = new List<AssetLocation>();
            try
            {


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        AssetLocation assetLocationObject = new AssetLocation();
                        assetLocationObject.AssetLocationId  = int.Parse(dr["AssetId"].ToString());
                        assetLocationObject.AssetLocationCode = dr["AssetLocationCode"].ToString();
                        assetLocationObject.CompanyId = int.Parse(dr["CompanyId"].ToString());
                        assetLocationObject.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                        assetLocationObject.IsActive = int.Parse(dr["IsActive"].ToString());
                        assetLocationObject.UpdatedBy = int.Parse(dr["UpdateBy"].ToString());
                        assetLocationObject.Remark = dr["Remark"].ToString()==null ? "" : dr["Remark"].ToString();
                        assetLocationObject.CompanyName = dr["CompanyName"].ToString();
                        assetLocationObject.UpdatedOn = dr["UpdatedOn"].ToString();
                        assetLocationObject.CreatedOn = dr["CreatedOn"].ToString();
                        assetLocationObject.IsDeleted = int.Parse(dr["IsDeleted"].ToString());

                        assetLocationObject.AssetLocationName = dr["AssetLocationName"].ToString();

                        assetLocationObjList.Add(assetLocationObject);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return assetLocationObjList;

        }

        public string InsertAssetLocation(AssetLocation asstObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Asset_Location", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@AssetLocatonCode", asstObj.AssetLocationCode);
                        cmd.Parameters.AddWithValue("@AssetLocationDescription", asstObj.AssetLocationName);
                        cmd.Parameters.AddWithValue("@Remark", asstObj.Remark);
                        cmd.Parameters.AddWithValue("@CreatedOn", asstObj.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedOn", asstObj.UpdatedOn);
                        cmd.Parameters.AddWithValue("@CreatedBy", asstObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", asstObj.UpdatedBy);
                        //cmd.Parameters.AddWithValue("@Isstatus", asstObj.is);
                        cmd.Parameters.AddWithValue("@IsActive", asstObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", asstObj.AssetLocationId);
                        cmd.Parameters.AddWithValue("@CompanyId", asstObj.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", asstObj.CompanyName);
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

        public string UpdateAssetLocation(AssetLocation asstObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Asset_Location", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@AssetLocatonCode", asstObj.AssetLocationCode);
                        cmd.Parameters.AddWithValue("@AssetLocationDescription", asstObj.AssetLocationName);
                        cmd.Parameters.AddWithValue("@Remark", asstObj.Remark);
                        cmd.Parameters.AddWithValue("@CreatedOn", asstObj.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedOn", asstObj.UpdatedOn);
                        cmd.Parameters.AddWithValue("@CreatedBy", asstObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", asstObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Isstatus", 0);
                        cmd.Parameters.AddWithValue("@IsActive", asstObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", asstObj.AssetLocationId);
                        cmd.Parameters.AddWithValue("@CompanyId", asstObj.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", asstObj.CompanyName);
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

        public string DeleteAssetLocation(int problemId,int CompanyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Asset_Location", conn))
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
    }
}