using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.Transaction
{
    public class ApproveWoDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public List<ApproveModel> ApproveList(ApproveModel request)
        {
            List<ApproveModel> baseresponce = new List<ApproveModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-ApproveWo]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dt.Rows[0][0].ToString();
                            RaiseServiceDAL FOrExPression = new RaiseServiceDAL();
                            foreach (DataRow dr in dt.Rows)
                            {
                                ApproveModel responce = new ApproveModel();
                                responce.CompanyId = Convert.ToInt32(dr["CompanyId"].ToString());
                                responce.Site = dr["Site"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["Site"]);
                                responce.Zone = dr["Zone"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["Zone"]);
                                responce.WOId = dr["WoId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["WoId"].ToString());
                                responce.ServiceReqId = dr["ServiceReqId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["ServiceReqId"].ToString());
                                responce.Location = (dr["location"].ToString());
                                responce.ZoneName = (dr["ZoneName"].ToString());
                                responce.IsStatus = (dr["Status"].ToString());
                                responce.Remarks = (dr["ApprvRemarks"].ToString());
                                responce.CreatedBy = (dr["UserName"].ToString());
                                responce.CreatedBy = (dr["UserName"].ToString());
                                if (responce.ServiceReqId>0) {
                                    responce.WOExp = FOrExPression.autoIdFormat(Convert.ToInt32(dr["ServiceReqId"]), request.CompanyId, "Workorder");

                                }
                                responce.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                                //responce.UserId = dr["UserId"].ToString();
                                baseresponce.Add(responce);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return baseresponce;

        }

        public string UpdateApproveorderlist(List<Workorder> request)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        using (SqlCommand cmd = new SqlCommand("[Hd-sp-ApproveWo]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 2);
                            cmd.Parameters.AddWithValue("@Id", data.Id);
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId);
                            cmd.Parameters.AddWithValue("@ApproveStatus", data.ApproveStatus);
                            cmd.Parameters.AddWithValue("@ApprvRemarks", data.ApprvRemarks);
                            cmd.Parameters.AddWithValue("@modifiedby", data.Modifiedby);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                        WorkOrderDAL Dal = new WorkOrderDAL();
                        WOHistory model = new WOHistory();
                        model.ServiceId =Convert.ToInt32(data.ServiceReqId);
                        model.AssignTo = data.AssignTo;
                        model.WorKorderStatus = "11";
                        model.CompanyId = data.CompanyId;
                        model.CreatedBy = data.Modifiedby;
                        Dal.CreateWorkOrderHistory(model);
                    }
                    if (dt.Rows.Count > 0)
                    {

                        return dt.Rows[0][0].ToString();
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