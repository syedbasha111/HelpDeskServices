using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using HelpDeskServices.DataModels;


namespace HelpDeskServices.DataAccessLayer
{
    public class MasterSubServiceDAL
    {
        public List<SubServiceObject> GetSubServiceUnit(int campanyId)
        {

            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_SubService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@SubServiceCode", "");
                        cmd.Parameters.AddWithValue("@SubServiceDescription", "");
                        cmd.Parameters.AddWithValue("@ServiceID", 0);
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", "");
                        cmd.Parameters.AddWithValue("@Companyid", campanyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateSubServiceObject(ds.Tables[0]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<SubServiceObject> PopulateSubServiceObject(DataTable dt)
        {
            List<SubServiceObject> ServiceObjectList = new List<SubServiceObject>();
            try
            {


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SubServiceObject SubServiceObject = new SubServiceObject();
                        SubServiceObject.SubServiceCode = dr["SubServiceCode"].ToString();
                        SubServiceObject.SubServiceDescription = dr["SubServiceDescription"].ToString();
                        SubServiceObject.ServiceID = int.Parse(dr["ServiceID"].ToString());
                        SubServiceObject.Remarks = dr["Remarks"].ToString();
                        SubServiceObject.CompanyId = int.Parse(dr["Companyid"].ToString());
                        SubServiceObject.BusinessUnitId = int.Parse(dr["BusinessUnitID"].ToString());
                        SubServiceObject.BusinessName = dr["Name"].ToString();
                        SubServiceObject.SubServiceID = int.Parse(dr["ID"].ToString());
                        SubServiceObject.serviceCode = (dr["ServiceDescription"].ToString());
                        SubServiceObject.BusinessCode = dr["BusinessCode"].ToString();
                        SubServiceObject.IsActive = int.Parse(dr["IsActive"].ToString());
                        ServiceObjectList.Add(SubServiceObject);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ServiceObjectList;
        }

        public string InsertSubService(SubService SubServiceObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_SubService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@SubServiceCode", SubServiceObj.SubServiceCode);
                        cmd.Parameters.AddWithValue("@SubServiceDescription", SubServiceObj.SubServiceDescription);
                        cmd.Parameters.AddWithValue("@ServiceID", SubServiceObj.ServiceID);
                        cmd.Parameters.AddWithValue("@BusinessUnitID", SubServiceObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@Remarks", SubServiceObj.Remarks);
                        cmd.Parameters.AddWithValue("@Companyid", SubServiceObj.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", SubServiceObj.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", SubServiceObj.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", SubServiceObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", SubServiceObj.SubServiceID);
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

        public string updateSubService(SubService SubServiceObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_SubService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@SubServiceCode", SubServiceObj.SubServiceCode);
                        cmd.Parameters.AddWithValue("@SubServiceDescription", SubServiceObj.SubServiceDescription);
                        cmd.Parameters.AddWithValue("@ServiceID", SubServiceObj.ServiceID);
                        cmd.Parameters.AddWithValue("@Remarks", SubServiceObj.Remarks);
                        cmd.Parameters.AddWithValue("@BusinessUnitID", SubServiceObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@Companyid", SubServiceObj.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", SubServiceObj.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", SubServiceObj.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", SubServiceObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", SubServiceObj.SubServiceID);
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

        public SubServiceObject GetSubServiceById(int SubServiceId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_SubService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@SubServiceCode", "");
                        cmd.Parameters.AddWithValue("@SubServiceDescription", "");
                        cmd.Parameters.AddWithValue("@ServiceID", 0);
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", 0);
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", SubServiceId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateSubServiceObject(ds.Tables[0])[0];
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public string DeleteSubService(int SubServiceId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_SP_SubService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@SubServiceCode", "");
                        cmd.Parameters.AddWithValue("@SubServiceDescription", "");
                        cmd.Parameters.AddWithValue("@ServiceID", 0);
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", 0);
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", SubServiceId);
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