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
    public class ServiceEscalationDAL
    {
        #region declarations
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd;
        #endregion

        #region Implimenations
        public string insertServiceEscaltion(ServiceEscalationModel escalation)
        {

            try
            {
                using ( conn = new SqlConnection(ConString))
                {
                   
                    using ( cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CountryId", escalation.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", escalation.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", escalation.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", escalation.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", escalation.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", escalation.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", escalation.ProblemId);
                        cmd.Parameters.AddWithValue("@Companyid", escalation.CompanyId);
                        cmd.Parameters.AddWithValue("@createdBy", escalation.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", escalation.UpdatedBy);
                        cmd.Parameters.AddWithValue("@ID", escalation.ServiceEscalationId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
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

        public string SaveusersCheckList(List<ServiceEscalationSubItems> request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    foreach (var data in request) {
                        using (cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase",7 );
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId );
                            cmd.Parameters.AddWithValue("@UserId", data.UserId );
                            cmd.Parameters.AddWithValue("@EscalationServiceId", data.EscalationServiceId);
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
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

        public string UpdateServiceEscaltion(ServiceEscalationModel escalation)
        {

            try
            {
                using ( conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CountryId", escalation.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", escalation.CityId);
                        cmd.Parameters.AddWithValue("@LocationId", escalation.LocationId);
                        cmd.Parameters.AddWithValue("@BusinessId", escalation.BusinessUnitId);
                        cmd.Parameters.AddWithValue("@ServiceId", escalation.ServiceId);
                        cmd.Parameters.AddWithValue("@SubServiceId", escalation.SubServiceID);
                        cmd.Parameters.AddWithValue("@ProblemId", escalation.ProblemId);
                        cmd.Parameters.AddWithValue("@Companyid", escalation.CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", escalation.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", escalation.UpdatedBy);
                        cmd.Parameters.AddWithValue("@ID", escalation.ServiceEscalationId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        DataTable dt = new DataTable();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        string status = "";
                        if (dt.Rows.Count > 0)
                        {
                            status = dt.Rows[0][0].ToString();
                        }
                        if (status == "Successfully Updated")
                        {
                            string DeleteStatus = deletecheckedlist(escalation.ServiceEscalationId, escalation.CompanyId);
                            if (DeleteStatus== "Successfully Deleted") {
                                return escalation.ServiceEscalationId.ToString();
                            }
                            
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Not updated";

        }

        public string deletecheckedlist(int Id,int CompanyId)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",8);
                        cmd.Parameters.AddWithValue("@ID", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        DataTable dt = new DataTable();
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

        public List<ServiceEscalationModel> GetServiceEscalation(int companyId)
        {
            List<ServiceEscalationModel> escalationsList = new List<ServiceEscalationModel>();
            try
            {
                using ( conn = new SqlConnection(ConString))
                {
                    using ( cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ServiceEscalationModel escalationObj = new ServiceEscalationModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                escalationObj.ServiceEscalationId = int.Parse(dr["ID"].ToString());
                                escalationObj.CountryName =  dr["CountryName"].ToString();
                                escalationObj.CountryId = int.Parse(dr["CountryId"].ToString());
                                escalationObj.CityName = dr["CityName"].ToString();
                                escalationObj.CityId = int.Parse(dr["CityId"].ToString());
                                escalationObj.LocationName = dr["AssetLocationName"].ToString();
                                escalationObj.LocationId = int.Parse(dr["LocationId"].ToString());
                                escalationObj.ServiceId = int.Parse(dr["ServiceId"].ToString());
                                escalationObj.ServiceName = dr["ServiceDescription"].ToString();
                                escalationObj.SubServiceID = int.Parse(dr["SubServiceId"].ToString());
                                escalationObj.SubServiceName = dr["SubServiceDescription"].ToString();
                                escalationObj.ProblemId = int.Parse(dr["Problem"].ToString());
                                escalationObj.ProblemName = dr["ProblemDescription"].ToString();
                                escalationObj.BusinessUnitId = int.Parse(dr["BusinessId"].ToString());
                                escalationObj.BusinessUnitName = dr["BusinessDescription"].ToString();
                                escalationObj.CompanyId =int.Parse(dr["CompanyId"].ToString());
                                

                                escalationsList.Add(escalationObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return escalationsList;

        }

        public string DeleteServiceEscalation(int recordId)
        {

            try
            {
                using ( conn = new SqlConnection(ConString))
                {
                   
                    using ( cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", recordId);
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

            return "No records Found";

        }

        public RoleTreeView role(int companyId)
        {
            RoleTreeView response = new RoleTreeView();
            response.RoleList = RoleList(companyId);
            
            return response;
        }

        internal List<RoleModel> RoleList(int companyId)
        {
            List<RoleModel> escalationsList = new List<RoleModel>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                RoleModel escalationObj = new RoleModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                escalationObj.Remarks = dr["Remarks"].ToString();
                                escalationObj.Status = (bool)dr["Status"];
                                escalationObj.code = dr["Code"].ToString();
                                escalationObj.Name = dr["Name"].ToString();
                                escalationObj.RoleId = int.Parse(dr["RoleId"].ToString());
                                escalationObj.UserList = UserList(dr["CompanyCode"].ToString(), int.Parse(dr["RoleId"].ToString()));
                                escalationsList.Add(escalationObj);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return escalationsList;
        }

        internal List<User> UserList(string companyId,int id)
        {
            List<User> escalationsList = new List<User>();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("HD_Sp_ServiceEscalation", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@Company", companyId);
                        cmd.Parameters.AddWithValue("@ID", id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                User escalationObj = new User();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                escalationObj.UserName = dr["UserName"].ToString();
                                escalationObj.UserId = int.Parse(dr["UserId"].ToString());
                                escalationObj.RoleId = int.Parse(dr["RoleId"].ToString());
                                escalationsList.Add(escalationObj);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return escalationsList;
        }
        #endregion
    }
}