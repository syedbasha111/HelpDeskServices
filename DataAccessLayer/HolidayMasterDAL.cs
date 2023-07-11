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
        public List<HD_BaseModel> insertHolidayCallMaster(List<HolidayCallMasterModel> HolidayObj)
        {
            List<HD_BaseModel> BaseResponce = new List<HD_BaseModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    foreach (var request in HolidayObj)
                    {
                        using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@Id", request.HolidayCallMasterId);
                            cmd.Parameters.AddWithValue("@HolidayDate", request.HolidayDate);
                            cmd.Parameters.AddWithValue("@HolidayName", request.HolidayCallName);
                            cmd.Parameters.AddWithValue("@Remark", request.Remark);
                            cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                            cmd.Parameters.AddWithValue("@createdBy", request.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", request.UpdatedBy);
                            cmd.Parameters.AddWithValue("@Companyid", request.CompanyId);
                            cmd.Parameters.AddWithValue("@IsDeleted", 0);
                            cmd.Parameters.AddWithValue("@CityID", request.CityId);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows[0][0].ToString() == "Already Record Exist")
                            {
                                HD_BaseModel responce = new HD_BaseModel();
                                responce.Names = request.HolidayCallName;
                                BaseResponce.Add(responce);
                            }
                        }
                    }
                    //if (dt.Rows.Count > 0)
                    //{
                    //    return BaseResponce;
                    //}
                }

            }
            catch (Exception ex)
            {
               
            }

            return BaseResponce;

        }

        public string UpdateHolidayMaster(List<HolidayCallMasterModel> HolidayObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();

                    foreach (var request in HolidayObj)
                    {
                        using (SqlCommand cmd = new SqlCommand("HD_sp_Holidaymaster", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 2);
                            cmd.Parameters.AddWithValue("@Id", request.HolidayCallMasterId);
                            cmd.Parameters.AddWithValue("@CityID", request.CityId);
                            cmd.Parameters.AddWithValue("@HolidayDate", request.HolidayDate);
                            cmd.Parameters.AddWithValue("@HolidayName", request.HolidayCallName);
                            cmd.Parameters.AddWithValue("@Remark", request.Remark);
                            cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                            cmd.Parameters.AddWithValue("@createdBy", request.CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", request.UpdatedBy);
                            cmd.Parameters.AddWithValue("@Companyid", request.CompanyId);
                            cmd.Parameters.AddWithValue("@IsDeleted", 0);
                            cmd.Parameters.AddWithValue("@UpdatedOn", "");
                            cmd.Parameters.AddWithValue("@CreatedOn", "");
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);



                        }
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
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
                        cmd.Parameters.AddWithValue("@CityID", "");
                        cmd.Parameters.AddWithValue("@HolidayDate", "");

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

        public string DeleteHolidayMaster(int recordId,int CompanyId)
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
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
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