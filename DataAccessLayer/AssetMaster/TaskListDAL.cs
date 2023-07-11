using HelpDeskServices.AdoConnection;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.AssetMaster
{
    public class TaskListDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        AdoExcmethod spexc = new AdoExcmethod();

        #region TaskList Master

        public List<SubSytem> GetSubSystemdata(SubSytem request)
        {
            List<SubSytem> BaseResponce = new List<SubSytem>();
            
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                SubSytem responce = new SubSytem();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.SubSystem = dr["SubSystem"].ToString();
                                responce.SubSystemCode = dr["SubSystemCode"].ToString();
                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }

        public string SaveTaskList(TaskListMaster request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@TaskType", request.TaskType);
                        cmd.Parameters.AddWithValue("@Frequency", request.Frequency);
                        cmd.Parameters.AddWithValue("@TLCode", request.TLCode);
                        cmd.Parameters.AddWithValue("@TLName", request.TLName);
                        cmd.Parameters.AddWithValue("@TLDescription", request.TLDescription);
                        cmd.Parameters.AddWithValue("@Hours", request.Hours);
                        cmd.Parameters.AddWithValue("@Isdeleted", "1");
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
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
                return ex.ToString();
            }

            return "";
        }

        public string UpdateTaskList(TaskListMaster request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 10);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@TaskType", request.TaskType);
                        cmd.Parameters.AddWithValue("@Frequency", request.Frequency);
                        cmd.Parameters.AddWithValue("@TLCode", request.TLCode);
                        cmd.Parameters.AddWithValue("@TLName", request.TLName);
                        cmd.Parameters.AddWithValue("@TLDescription", request.TLDescription);
                        cmd.Parameters.AddWithValue("@Hours", request.Hours);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
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
                return ex.ToString();
            }

            return "";
        }

        public List<TaskTypeMaster> DropdownTaskType(int CompanyId)
        {
            List<TaskTypeMaster> BaseResponce = new List<TaskTypeMaster>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TaskTypeMaster responce = new TaskTypeMaster();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.TaskType = dr["TaskType"].ToString();
                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }

        public List<FrequencyMaster> DropdownFrequency(int CompanyId)
        {
            List<FrequencyMaster> BaseResponce = new List<FrequencyMaster>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                FrequencyMaster responce = new FrequencyMaster();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.Frequency = dr["Frequency"].ToString();
                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }

        public string SaveTaskListItems(List<TaskListAddItemModel> request,int Id)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    foreach (var data in request)
                    {
                        if (data.Insestdata == 1) { 
                        using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 2);
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId);
                            cmd.Parameters.AddWithValue("@TaskDesc", data.TaskDesc);
                            cmd.Parameters.AddWithValue("@TaskHead", data.TaskHead);
                            cmd.Parameters.AddWithValue("@SubTaskId", data.SubTaskId);
                            cmd.Parameters.AddWithValue("@Subtaskname", data.Subtaskname);
                                cmd.Parameters.AddWithValue("@TaskListId", Id);
                            cmd.Parameters.AddWithValue("@Isdeleted", "0");
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
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

       

        public List<TaskListMaster> TaskListDetails(int CompanyId)
        {
            List<TaskListMaster> BaseResponce = new List<TaskListMaster>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TaskListMaster responce = new TaskListMaster();
                                responce.Id = Convert.ToInt32(dr["Id"]);
                                responce.TaskType =Convert.ToInt32(dr["TaskType"]);
                                responce.TLCode =Convert.ToString(dr["TLCode"]);
                                responce.TLName =Convert.ToString(dr["TLName"]);
                                responce.TLDescription =Convert.ToString(dr["TLDescription"]);
                                responce.Hours =Convert.ToString(dr["Hours"]);
                                responce.Frequency =Convert.ToInt32(dr["Frequency"]);
                                responce.Service= Convert.ToInt32(dr["Service"]);
                                responce.BusinessUnit= Convert.ToInt32(dr["BusinessUnit"]);
                                responce.System = Convert.ToInt32(dr["System"]);
                                responce.SubSystem = Convert.ToInt32(dr["SubSystem"]);
                                responce.SystemName = dr["SystemaName"].ToString();
                                responce.BusinessUnitName = dr["Description"].ToString();
                                responce.ServiceName = dr["ServiceDescription"].ToString();

                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }

        public List<TaskListAddItemModel> TaskLisItemDetails(int CompanyId,int Id)
        {
            List<TaskListAddItemModel> BaseResponce = new List<TaskListAddItemModel>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",4);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TaskListAddItemModel responce = new TaskListAddItemModel();
                                responce.Id = Convert.ToInt32(dr["Id"]);
                                responce.TaskHead = Convert.ToString(dr["TaskHead"]);
                                responce.TaskDesc = Convert.ToString(dr["TaskDesc"]);
                                BaseResponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return BaseResponce;
        }


        public string DeleteTLAddItem(int Id)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 8);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
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

        public string DeleteTaskList(int Id)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-TaskList]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",9 );
                        cmd.Parameters.AddWithValue("@Id", Id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
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
        #endregion

        //public string SavePlanListItems(List<PlanListAddItemModel>)
        //{
        //    try
        //    {
        //        using (conn = new SqlConnection(ConString))
        //        {
        //            foreach (var data in request)
        //            {
        //                if (data.Insestdata == 1)
        //                {
        //                    using (cmd = new SqlCommand("[HdTemp]", conn))
        //                    {
        //                        cmd.Parameters.AddWithValue("@year", data.year);
        //                        cmd.Parameters.AddWithValue("@PlanId", data.PlanId);
        //                        cmd.Parameters.AddWithValue("@Isdeleted", "0");
        //                        conn.Open();
        //                        cmd.CommandType = CommandType.TableDirect;
        //                        conn.Close();
        //                        da.SelectCommand = cmd;
        //                        da.Fill(dt);
        //                    }
        //                }
        //            }
        //            if (dt.Rows.Count > 0)
        //            {
        //                return dt.Rows[0][0].ToString();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //    return "";
        //}

        
    }
}