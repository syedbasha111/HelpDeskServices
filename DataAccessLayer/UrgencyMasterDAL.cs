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
    public class UrgencyMasterDAL
    {
        public string insertUrgencyCallMaster(UrgencyCallMasterModel UrgencyObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_urgencymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", UrgencyObj.UrgencyCallMasterId);
                        cmd.Parameters.AddWithValue("@UrgencyCode", UrgencyObj.UrgencyCallCode);
                        cmd.Parameters.AddWithValue("@UrgencyName", UrgencyObj.UrgencyCallName);
                        cmd.Parameters.AddWithValue("@Remark", UrgencyObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", UrgencyObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", UrgencyObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", UrgencyObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", UrgencyObj.CompanyId);
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

        public string UpdateUrgencyMaster(UrgencyCallMasterModel UrgencyObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_urgencymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", UrgencyObj.UrgencyCallMasterId);
                        cmd.Parameters.AddWithValue("@UrgencyCode", UrgencyObj.UrgencyCallCode);
                        cmd.Parameters.AddWithValue("@UrgencyName", UrgencyObj.UrgencyCallName);
                        cmd.Parameters.AddWithValue("@Remark", UrgencyObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", UrgencyObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", UrgencyObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", UrgencyObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", UrgencyObj.CompanyId);
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
                return ex.Message;
            }

            return "";

        }


        public List<UrgencyCallMasterModel> GetUrgencyMaster(int companyId)
        {
            List<UrgencyCallMasterModel> UrgencyobjList = new List<UrgencyCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_urgencymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                        cmd.Parameters.AddWithValue("@UrgencyCode", "");
                        cmd.Parameters.AddWithValue("@UrgencyName", "");
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
                                UrgencyCallMasterModel Urgencyobj = new UrgencyCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Urgencyobj.UrgencyCallMasterId = int.Parse(dr["ID"].ToString());
                                Urgencyobj.UrgencyCallCode = dr["UrgencyCode"].ToString();
                                Urgencyobj.UrgencyCallName = dr["UrgencyName"].ToString();
                                Urgencyobj.Remark = dr["Remark"].ToString();
                                Urgencyobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                Urgencyobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                Urgencyobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Urgencyobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Urgencyobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                Urgencyobj.CreatedOn = dr["CreatedOn"].ToString();
                                Urgencyobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                UrgencyobjList.Add(Urgencyobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return UrgencyobjList;

        }

        public string DeleteUrgencyMaster(int recordId,int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                  
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_urgencymaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", recordId);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
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