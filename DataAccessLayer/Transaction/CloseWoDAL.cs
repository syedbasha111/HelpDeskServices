using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.DataAccessLayer.Transaction
{
    public class CloseWoDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection conn;

        public string CreateCloseWOStatus(CloseWOStatus request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[HD_SP_CloseWO]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ServiceReqId", request.ServiceReqId);
                        cmd.Parameters.AddWithValue("@WoId", request.WoId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Feedback", request.Feedback);
                        cmd.Parameters.AddWithValue("@Acknowledge", request.Acknowledge);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);

                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            string status = UpdateWoCloseStatus(request.WoId, request.CompanyId);
                            WorkOrderDAL WoDal = new WorkOrderDAL();
                            var resourcelist = WoDal.GetWOchilddetsils(request.WoId);
                            string Resourcetime = SaveResourceTime(resourcelist.ResourcesList);
                            string resourceInsert = CreateResourceWorkdone(resourcelist.ResourcesList, request.CompanyId);
                            string SparesInsert = CreateSparesWorkdone(resourcelist.SparesList, request.CompanyId);
                            string ConsumbalsInsert = CreateConsumbalsWorkdone(resourcelist.ConsumabelsList, request.CompanyId);
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


        /// <summary>
        /// Update status in Wo Table For Close
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Companyid"></param>
        /// <returns></returns>
        public string UpdateWoCloseStatus(int Id, int Companyid)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[HD_SP_CloseWO]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", Companyid);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        DataTable dt = new DataTable();
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

        /// <summary>
        /// reject the Close WO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string RejectCloseWOStatus(CloseWOStatus request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[HD_SP_CloseWO]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ServiceReqId", request.ServiceReqId);
                        cmd.Parameters.AddWithValue("@WoId", request.WoId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@Feedback", request.Feedback);
                        cmd.Parameters.AddWithValue("@Acknowledge", request.Acknowledge);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);

                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            string RemoveStatus = UpdateWoRejectStatus(request.WoId, request.CompanyId);
                            WorkOrderDAL WoDal = new WorkOrderDAL();
                            var resourcelist = WoDal.GetWOchilddetsils(request.WoId);
                            string Resourcetime = SaveResourceTime(resourcelist.ResourcesList);
                            string resourceInsert = CreateResourceWorkdone(resourcelist.ResourcesList, request.CompanyId);
                            string SparesInsert = CreateSparesWorkdone(resourcelist.SparesList, request.CompanyId);
                            string ConsumbalsInsert = CreateConsumbalsWorkdone(resourcelist.ConsumabelsList, request.CompanyId);

                            //string DeleteHistory = DeleteWOHistory(request.ServiceReqId,request.WoId, request.CompanyId);
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


        private string DeleteWOHistory(int Id, int Woid, int CompanyId)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[HD_SP_CloseWO]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@WoId", Woid);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        DataTable dt = new DataTable();
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
        /// <summary>
        /// Update status in Wo Table For Close
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Companyid"></param>
        /// <returns></returns>
        public string UpdateWoRejectStatus(int Id, int Companyid)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[HD_SP_CloseWO]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", Companyid);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter();
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        DataTable dt = new DataTable();
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


        internal string SaveResourceTime(List<Resources> request)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (var data in request)
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        using (cmd = new SqlCommand("[HD_SP_WOResource]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 6);
                            cmd.Parameters.AddWithValue("@WorkOrderId", data.WorkOrderId);
                            cmd.Parameters.AddWithValue("@ResourceId", data.resourceId);
                            cmd.Parameters.AddWithValue("@TimeTaken", data.TimeTaken);
                            cmd.Parameters.AddWithValue("@CompanyId", data.Companyid);
                            cmd.Parameters.AddWithValue("@CreatedBy", data.CreatedBy);
                            cmd.CommandType = CommandType.StoredProcedure;
                            da = new SqlDataAdapter();
                            conn.Open();
                            da.SelectCommand = cmd;
                            conn.Close();

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

        internal string CreateResourceWorkdone(List<Resources> request, int CompanyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        //Inserting new record
                        if (data.IsDone == false)
                        {

                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOResource", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 1);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ResourceId", data.resourceId);
                                cmd.Parameters.AddWithValue("@Code", data.Code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Fromdate", data.Fromdate);
                                cmd.Parameters.AddWithValue("@Todate", data.Todate);
                                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@TimeTaken", data.TimeTaken);
                                cmd.Parameters.AddWithValue("@WorkOrderId", data.WorkOrderId);
                                cmd.Parameters.AddWithValue("@IsDone", true);
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

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        internal string CreateSparesWorkdone(List<ToolsSpresConsumables> request, int CompanyId)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        if (data.IsDone == false)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 3);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", data.WorkOrderId);
                                cmd.Parameters.AddWithValue("@IsDone", true);

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

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }


        internal string CreateConsumbalsWorkdone(List<ToolsSpresConsumables> request, int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    foreach (var data in request)
                    {
                        if (data.IsDone == false)
                        {
                            using (SqlCommand cmd = new SqlCommand("HD_SP_WOAddItems", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Fcase", 4);
                                cmd.Parameters.AddWithValue("@Id", "");
                                cmd.Parameters.AddWithValue("@ItemId", data.ItemId);
                                cmd.Parameters.AddWithValue("@Code", data.code);
                                cmd.Parameters.AddWithValue("@Name", data.Name);
                                cmd.Parameters.AddWithValue("@Category", data.Category);
                                cmd.Parameters.AddWithValue("@SubCategory", data.SubCategory);
                                cmd.Parameters.AddWithValue("@Quantity", data.ReqQuantity);
                                cmd.Parameters.AddWithValue("@ConsumeQty", data.ConsumeQty);
                                cmd.Parameters.AddWithValue("@InventoryType", data.InventoryType);
                                cmd.Parameters.AddWithValue("@Services", data.ServiceDescription);
                                cmd.Parameters.AddWithValue("@ComapanyId", CompanyId);
                                cmd.Parameters.AddWithValue("@WorkOrderId", data.WorkOrderId);
                                cmd.Parameters.AddWithValue("@IsDone", true);

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

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

    }
}