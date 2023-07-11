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
    public class MasterServiceDAL
    {
        public List<ServiceObject> GetServiceUnit(int campanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Service", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ServiceCode", "");
                        cmd.Parameters.AddWithValue("@ServiceDescription", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", "");
                        cmd.Parameters.AddWithValue("@Companyid", campanyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateServiceObject(ds.Tables[0]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<ServiceObject> PopulateServiceObject(DataTable dt)
        {
            List<ServiceObject> ServiceObjectList = new List<ServiceObject>();
            try
            {


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ServiceObject ServiceObject = new ServiceObject();
                        ServiceObject.ServiceCode = dr["ServiceCode"].ToString();
                        ServiceObject.ServiceDescription = dr["ServiceDescription"].ToString();
                        ServiceObject.Remarks = dr["Remarks"].ToString();
                        ServiceObject.CompanyId = int.Parse(dr["Companyid"].ToString());
                        ServiceObject.BusinessUnitId = int.Parse(dr["BusinessUnitID"].ToString());
                        ServiceObject.BusinessName = dr["Name"].ToString();
                        ServiceObject.ServiceID = int.Parse(dr["ID"].ToString());
                        ServiceObject.IsActive = bool.Parse(dr["IsActive"].ToString());
                        ServiceObjectList.Add(ServiceObject);
                    }
                }
            }
            catch (Exception)
            {
            }

            return ServiceObjectList;
        }

        public string InsertService(Service serviceObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Service", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ServiceCode", serviceObj.ServiceCode);
                        cmd.Parameters.AddWithValue("@ServiceDescription", serviceObj.ServiceDescription);
                        cmd.Parameters.AddWithValue("@Remarks", serviceObj.Remarks);
                        cmd.Parameters.AddWithValue("@BusinessUnitID", serviceObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@Companyid", serviceObj.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", serviceObj.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", serviceObj.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", serviceObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", serviceObj.ServiceID);
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

        public string updateService(Service serviceObj)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Service", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ServiceCode", serviceObj.ServiceCode);
                        cmd.Parameters.AddWithValue("@ServiceDescription", serviceObj.ServiceDescription);
                        cmd.Parameters.AddWithValue("@Remarks", serviceObj.Remarks);
                        cmd.Parameters.AddWithValue("@BusinessUnitID", serviceObj.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@Companyid", serviceObj.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", serviceObj.createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", serviceObj.modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", serviceObj.IsActive);
                        cmd.Parameters.AddWithValue("@ID", serviceObj.ServiceID);
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

        public ServiceObject GetServiceById(int ServiceId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Service", conn))
                    {
                       
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@ServiceCode", "");
                        cmd.Parameters.AddWithValue("@ServiceDescription", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", 0);
                        cmd.Parameters.AddWithValue("@Companyid", 0);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", ServiceId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return PopulateServiceObject(ds.Tables[0])[0];
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public string DeleteService(int ServiceId,int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                  
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Service", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ServiceCode", "");
                        cmd.Parameters.AddWithValue("@ServiceDescription", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@BusinessUnitID", 0);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", 0);
                        cmd.Parameters.AddWithValue("@Modifiedby", 0);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@ID", ServiceId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
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

            return "No records Found";

        }


        public List<ServiceObject> GetServicebybussinessID(int companyId, int Id)
        {
            List<ServiceObject> baseModel = new List<ServiceObject>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_RoomMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@RoomCode", "");
                        cmd.Parameters.AddWithValue("@RoomName", "");
                        cmd.Parameters.AddWithValue("@RoomId", "");
                        cmd.Parameters.AddWithValue("@RoomNumber", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CreatedDate", "");
                        cmd.Parameters.AddWithValue("@ModifiedDate", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@SiteId", 0);
                        cmd.Parameters.AddWithValue("@cityID", 0);
                        cmd.Parameters.AddWithValue("@CountryID", 0);
                        cmd.Parameters.AddWithValue("@DistrictID", 0);
                        cmd.Parameters.AddWithValue("@RegionID", 0);
                        cmd.Parameters.AddWithValue("@ZoneId", 0);
                        cmd.Parameters.AddWithValue("@BuildingId", 0);
                        cmd.Parameters.AddWithValue("@FloorId", 0);
                        cmd.Parameters.AddWithValue("@AreaId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ServiceObject data = new ServiceObject();

                                


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;
        }
    }
}