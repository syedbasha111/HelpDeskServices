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
    public class ReqApprvlMatrixDAL
    {

        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public string SaveReqApprvlMatrix(requestApprovalmatrix request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ReqApprvlMatrix]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@L1Approval", request.L1Approval);
                        cmd.Parameters.AddWithValue("@L2Approval", request.L2Approval);
                        cmd.Parameters.AddWithValue("@WoExcecutionL1Approval", request.WoExcecutionL1Approval);
                        cmd.Parameters.AddWithValue("@WoExcecutionL2Approval", request.WoExcecutionL2Approval);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ApprovalStatus", request.ApprovalStatus);
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

        public string UpdateReqApprvlMatrix(requestApprovalmatrix request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ReqApprvlMatrix]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@L1Approval", request.L1Approval);
                        cmd.Parameters.AddWithValue("@L2Approval", request.L2Approval);
                        cmd.Parameters.AddWithValue("@WoExcecutionL1Approval", request.WoExcecutionL1Approval);
                        cmd.Parameters.AddWithValue("@WoExcecutionL2Approval", request.WoExcecutionL2Approval);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.CreatedBy);
                        cmd.Parameters.AddWithValue("@ApprovalStatus", request.ApprovalStatus);
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

        public List<requestApprovalmatrix> getReqApprvlMatrix(int CompanyId)
        {
            List<requestApprovalmatrix> basemodel = new List<requestApprovalmatrix>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ReqApprvlMatrix]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                requestApprovalmatrix responce = new requestApprovalmatrix();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                responce.L1Approval = Convert.ToInt32(dr["L1Approval"].ToString());
                                responce.L2Approval = Convert.ToInt32(dr["L2Approval"].ToString());
                                responce.WoExcecutionL1Approval = Convert.ToInt32(dr["WoExcecutionL1Approval"].ToString());
                                responce.WoExcecutionL2Approval = Convert.ToInt32(dr["WoExcecutionL2Approval"].ToString());
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.L1Approvalname = (dr["l1apprvrole"].ToString());
                                responce.L2Approvalname = (dr["l2apprvrole"].ToString());
                                responce.WoExcecutionL1Approvalname = (dr["l1approvemp"].ToString());
                                responce.WoExcecutionL2Approvalname = (dr["l2apprvemp"].ToString());
                                responce.Status = (dr["Status"].ToString());
                                responce.Remarks = (dr["Remarks"].ToString());

                                basemodel.Add(responce);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return basemodel;
        }


        public string deleteApprovematrix(DeleteObj request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ReqApprvlMatrix]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", request.RecordId);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
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