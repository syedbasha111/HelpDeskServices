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
    public class FeedbackMasterDAL
    {

        public string insertFeedbackCallMaster(FeedbackCallMasterModel FeedbackObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_feedbackmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", FeedbackObj.FeedbackCallMasterId);
                        cmd.Parameters.AddWithValue("@FeedbackCode", FeedbackObj.FeedbackCallCode);
                        cmd.Parameters.AddWithValue("@FeedbackName", FeedbackObj.FeedbackCallName);
                        cmd.Parameters.AddWithValue("@Remark", FeedbackObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", FeedbackObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", FeedbackObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", FeedbackObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", FeedbackObj.CompanyId);
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
                throw;
            }

            return "";

        }

        public string UpdateFeedbackMaster(FeedbackCallMasterModel FeedbackObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_feedbackmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", FeedbackObj.FeedbackCallMasterId);
                        cmd.Parameters.AddWithValue("@FeedbackCode", FeedbackObj.FeedbackCallCode);
                        cmd.Parameters.AddWithValue("@FeedbackName", FeedbackObj.FeedbackCallName);
                        cmd.Parameters.AddWithValue("@Remark", FeedbackObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", FeedbackObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", FeedbackObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", FeedbackObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", FeedbackObj.CompanyId);
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


        public List<FeedbackCallMasterModel> GetFeedbackMaster(int companyId)
        {
            List<FeedbackCallMasterModel> FeedbackobjList = new List<FeedbackCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_feedbackmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                        cmd.Parameters.AddWithValue("@FeedbackCode", "");
                        cmd.Parameters.AddWithValue("@FeedbackName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FeedbackCallMasterModel Feedbackobj = new FeedbackCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Feedbackobj.FeedbackCallMasterId = int.Parse(dr["ID"].ToString());
                                Feedbackobj.FeedbackCallCode = dr["FeedbackCode"].ToString();
                                Feedbackobj.FeedbackCallName = dr["FeedbackName"].ToString();
                                Feedbackobj.Remark = dr["Remark"].ToString();
                                Feedbackobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                Feedbackobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                Feedbackobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Feedbackobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Feedbackobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                Feedbackobj.CreatedOn = dr["CreatedOn"].ToString();
                                Feedbackobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                FeedbackobjList.Add(Feedbackobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return FeedbackobjList;

        }

        public string DeleteFeedbackMaster(int recordId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_feedbackmaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);

                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@FeedbackCode", "");
                        cmd.Parameters.AddWithValue("@FeedbackName", "");
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