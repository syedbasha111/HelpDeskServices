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
    public class MaintenanceSubSystemDAL
    {
        #region SubSystem

        public string SaveSubSystem(SubSytem request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                   
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[mt-sp-SubSystem]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@SubSystemCode", request.SubSystemCode);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                        cmd.Parameters.AddWithValue("@Isdeleted", 1);
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
                throw;
            }

            return "";

        }

        public string UpdateSubSystem(SubSytem request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[mt-sp-SubSystem]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@SubSystemCode", request.SubSystemCode);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@Status", request.Status);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
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
                throw;
            }

            return "";

        }   


        public List<SystemMaster> GetSystemdata(SystemMaster request)
        {
            List<SystemMaster> BaseResponce = new List<SystemMaster>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[mt-sp-SubSystem]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",2);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@BusinessUnit", request.BusinessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SystemMaster responce = new SystemMaster();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.System = dr["System"].ToString();
                                responce.SystemCode = dr["SystemCode"].ToString();
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

        public List<SubSytem> GetSubSystemData(int CompanyId)
        {
            List<SubSytem> BaseResponce = new List<SubSytem>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[mt-sp-SubSystem]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
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
                                responce.BusinessUnit = dr["BusinessUnit"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["BusinessUnit"]);
                                responce.Service = dr["Service"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["Service"]);
                                responce.System = dr["System"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["System"]);
                                responce.Status = Convert.ToBoolean(dr["Status"]);
                                responce.SubSystem = dr["SubSystem"].ToString();
                                responce.Remarks= dr["Remarks"].ToString();
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

        public string DeleteSubSystemdata(int CompanyId, int Id)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[mt-sp-SubSystem]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Id", Id);
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
                throw;
            }

            return "";

        }
        #endregion
    }
}