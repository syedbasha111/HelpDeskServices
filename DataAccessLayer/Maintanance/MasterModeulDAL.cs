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
    public class MaintananceBusinessDAL
    {

        public List<BusinessObject> GetBussinessUnit(int companyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("mt_sp_BusinessUnit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Code", "");
                        cmd.Parameters.AddWithValue("@Description", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateBusinessObject(ds.Tables[0]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<BusinessObject> PopulateBusinessObject(DataTable dt)
        {
            List<BusinessObject> businessObjectList = new List<BusinessObject>();
            try
            {


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessObject businessObject = new BusinessObject();
                        businessObject.Code = dr["Code"].ToString();
                        businessObject.Description = dr["Description"].ToString();
                        businessObject.Remarks = dr["Remarks"].ToString();
                        businessObject.CompanyId = int.Parse(dr["Companyid"].ToString());
                        businessObject.Id = int.Parse(dr["ID"].ToString());
                        businessObject.IsActive = int.Parse(dr["IsActive"].ToString());
                        businessObjectList.Add(businessObject);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return businessObjectList;
        }

        public string insertBusinessUnit(BussinessParametersObj bunit)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("mt_sp_BusinessUnit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Code", bunit.Code);
                        cmd.Parameters.AddWithValue("@Description", bunit.Description);
                        cmd.Parameters.AddWithValue("@Remarks", bunit.Remark);
                        cmd.Parameters.AddWithValue("@Companyid", bunit.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", bunit.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", bunit.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", bunit.IsActive);
                        cmd.Parameters.AddWithValue("@ID", bunit.BusinessId);
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

        public string updateBusinessUnit(BussinessParametersObj businessObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("mt_sp_BusinessUnit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Code", businessObj.Code);
                        cmd.Parameters.AddWithValue("@Description", businessObj.Description);
                        cmd.Parameters.AddWithValue("@Remarks", businessObj.Remark);
                        cmd.Parameters.AddWithValue("@Companyid", businessObj.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", businessObj.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", businessObj.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", businessObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", businessObj.BusinessId);
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

        public BusinessObject GetBussinessUnitById(int BusinessId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("mt_sp_BusinessUnit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Code", "");
                        cmd.Parameters.AddWithValue("@Description", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", BusinessId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateBusinessObject(ds.Tables[0])[0];
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public string DeleteBussinessUnit(int BusinessId, int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("mt_sp_BusinessUnit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.Parameters.AddWithValue("@ID", BusinessId);
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

            return "No records Found";

        }

    }
}