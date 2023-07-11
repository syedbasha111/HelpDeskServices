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
    public class RepeatCallMasterDAL
    {
        public string insertRepeatCallMaster(RepeatCallMasterModel repeatObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_repeatcallmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", repeatObj.RepeatCallMasterId);
                        cmd.Parameters.AddWithValue("@RepeatCallCode", repeatObj.RepeatCallCode);
                        cmd.Parameters.AddWithValue("@RepeatCallName", repeatObj.RepeatCallName);
                        cmd.Parameters.AddWithValue("@Remark", repeatObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", repeatObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", repeatObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", repeatObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", repeatObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);




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

        public string UpdateRepeatCallMaster(RepeatCallMasterModel repeatObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_repeatcallmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", repeatObj.RepeatCallMasterId);
                        cmd.Parameters.AddWithValue("@RepeatCallCode", repeatObj.RepeatCallCode);
                        cmd.Parameters.AddWithValue("@RepeatCallName", repeatObj.RepeatCallName);
                        cmd.Parameters.AddWithValue("@Remark", repeatObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", repeatObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", repeatObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", repeatObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", repeatObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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


        public List<RepeatCallMasterModel> GetRepeatCallMaster(int companyId)
        {
            List<RepeatCallMasterModel> repeatobjList = new List<RepeatCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_repeatcallmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                        cmd.Parameters.AddWithValue("@RepeatCallCode", "");
                        cmd.Parameters.AddWithValue("@RepeatCallName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy",0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                    

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                RepeatCallMasterModel repeatobj = new RepeatCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                repeatobj.RepeatCallMasterId = int.Parse(dr["ID"].ToString());
                                repeatobj.RepeatCallCode = dr["RepeatCallCode"].ToString();
                                repeatobj.RepeatCallName = dr["RepeatCallName"].ToString();
                                repeatobj.Remark = dr["Remark"].ToString();
                                repeatobj.CreatedBy = int.Parse(dr["Createdby"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                repeatobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                repeatobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                repeatobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                repeatobj.CreatedOn =dr["CreatedOn"].ToString();
                                repeatobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                repeatobjList.Add(repeatobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return repeatobjList;

        }

        public string DeleteRepeatCallMaster(int recordId,int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_repeatcallmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
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