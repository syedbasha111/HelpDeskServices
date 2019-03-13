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
    public class HolidayMasterDAL
    {
        public string insertHolidayCallMaster(HolidayCallMasterModel HolidayObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", HolidayObj.HolidayCallMasterId);
                        cmd.Parameters.AddWithValue("@HolidayDate", HolidayObj.HolidayDate);
                        cmd.Parameters.AddWithValue("@HolidayName", HolidayObj.HolidayCallName);
                        cmd.Parameters.AddWithValue("@Remark", HolidayObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", HolidayObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", HolidayObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", HolidayObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", HolidayObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CityID", HolidayObj.CityId);
                       


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

        public string UpdateHolidayMaster(HolidayCallMasterModel HolidayObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", HolidayObj.HolidayCallMasterId);
                        cmd.Parameters.AddWithValue("@CityID", HolidayObj.CityId);
                        cmd.Parameters.AddWithValue("@HolidayDate", HolidayObj.HolidayDate);
                        cmd.Parameters.AddWithValue("@HolidayName", HolidayObj.HolidayCallName);
                        cmd.Parameters.AddWithValue("@Remark", HolidayObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", HolidayObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", HolidayObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", HolidayObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", HolidayObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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

            return "";

        }


        public List<HolidayCallMasterModel> GetHolidayMaster(int companyId)
        {
            List<HolidayCallMasterModel> HolidayobjList = new List<HolidayCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                       
                        cmd.Parameters.AddWithValue("@HolidayName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                      
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@CityID","");
                        cmd.Parameters.AddWithValue("@HolidayDate","");

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                HolidayCallMasterModel Holidayobj = new HolidayCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Holidayobj.HolidayCallMasterId = int.Parse(dr["ID"].ToString());
                                Holidayobj.HolidayDate = dr["HolidayDate"].ToString();
                                Holidayobj.HolidayCallName = dr["HolidayName"].ToString();
                                Holidayobj.Remark = dr["Remark"].ToString();
                                Holidayobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                Holidayobj.CityId = dr["CityId"].ToString();
                                Holidayobj.CityName = dr["CityName"].ToString();
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                Holidayobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                Holidayobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Holidayobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Holidayobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                Holidayobj.CreatedOn = dr["CreatedOn"].ToString();
                                Holidayobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                HolidayobjList.Add(Holidayobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return HolidayobjList;

        }

        public string DeleteHolidayMaster(int recordId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);

                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@HolidayCode", "");
                        cmd.Parameters.AddWithValue("@HolidayName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                     
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