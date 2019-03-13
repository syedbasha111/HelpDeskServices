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
    public class FacilityMasterDAL
    {
        public string insertFacilityCallMaster(FacilityCallMasterModel FacilityObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_facilitymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", FacilityObj.FacilityCallMasterId);
                        cmd.Parameters.AddWithValue("@FacilityCode", FacilityObj.FacilityCallCode);
                        cmd.Parameters.AddWithValue("@FacilityName", FacilityObj.FacilityCallName);
                        cmd.Parameters.AddWithValue("@Remark", FacilityObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", FacilityObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", FacilityObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", FacilityObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", FacilityObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@Cost",FacilityObj.FacilityCost);



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

        public string UpdateFacilityMaster(FacilityCallMasterModel FacilityObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_facilitymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", FacilityObj.FacilityCallMasterId);
                        cmd.Parameters.AddWithValue("@FacilityCode", FacilityObj.FacilityCallCode);
                        cmd.Parameters.AddWithValue("@FacilityName", FacilityObj.FacilityCallName);
                        cmd.Parameters.AddWithValue("@Remark", FacilityObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", FacilityObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", FacilityObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", FacilityObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", FacilityObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@Cost", "");
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


        public List<FacilityCallMasterModel> GetFacilityMaster(int companyId)
        {
            List<FacilityCallMasterModel> FacilityobjList = new List<FacilityCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_facilitymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                        cmd.Parameters.AddWithValue("@FacilityCode", "");
                        cmd.Parameters.AddWithValue("@FacilityName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@Cost", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FacilityCallMasterModel Facilityobj = new FacilityCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Facilityobj.FacilityCallMasterId = int.Parse(dr["ID"].ToString());
                                Facilityobj.FacilityCallCode = dr["FacilityCode"].ToString();
                                Facilityobj.FacilityCallName = dr["FacilityName"].ToString();
                                Facilityobj.Remark = dr["Remark"].ToString();
                                Facilityobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                Facilityobj.FacilityCost = dr["Cost"].ToString();
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                Facilityobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                Facilityobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Facilityobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Facilityobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                Facilityobj.CreatedOn = dr["CreatedOn"].ToString();
                                Facilityobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                FacilityobjList.Add(Facilityobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return FacilityobjList;

        }

        public string DeleteFacilityMaster(int recordId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_facilitymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);

                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@FacilityCode", "");
                        cmd.Parameters.AddWithValue("@FacilityName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@Cost", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
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