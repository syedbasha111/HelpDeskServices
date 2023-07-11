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
    public class StateMasterDAL
    {
        public string insertStateMaster(StateModel Stateobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_State", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Stateobj.CompanyId);
                        cmd.Parameters.AddWithValue("@StateCode", Stateobj.StateCode);
                        cmd.Parameters.AddWithValue("@StateName", Stateobj.StateName);
                        cmd.Parameters.AddWithValue("@Remarks", Stateobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Stateobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Stateobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Stateobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Stateobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Stateobj.CompanyId);
                        cmd.Parameters.AddWithValue("@CountryId", Stateobj.CountryId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Stateobj.StateCost);



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

        public List<StateModel> GetStateMaster(int companyId)
        {
            List<StateModel> StateobjList = new List<StateModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_State", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@StateCode", "");
                        cmd.Parameters.AddWithValue("@StateName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Stateobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Stateobj.StateCost);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                StateModel Stateobj = new StateModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Stateobj.StateId = int.Parse(dr["StateId"].ToString());
                                Stateobj.StateCode = dr["StateCode"].ToString();
                                Stateobj.StateName = dr["StateName"].ToString();
                                Stateobj.Remarks = dr["Remarks"].ToString();
                                Stateobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Stateobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Stateobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Stateobj.IsActive = bool.Parse(dr["IsActive"].ToString());
                                Stateobj.CountryId= int.Parse(dr["CountryId"].ToString());
                                Stateobj.CountryName = dr["CountryName"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                StateobjList.Add(Stateobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return StateobjList;

        }

        public string updateStateMaster(StateModel Stateobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_State", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", Stateobj.StateId);
                        cmd.Parameters.AddWithValue("@StateCode", Stateobj.StateCode);
                        cmd.Parameters.AddWithValue("@StateName", Stateobj.StateName);
                        cmd.Parameters.AddWithValue("@Remarks", Stateobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Stateobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Stateobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Stateobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Stateobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Stateobj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", Stateobj.CountryId);
                        //cmd.Parameters.AddWithValue("@Cost", Stateobj.StateCost);



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
        public List<CountryModel> GetCountries(int companyId)
        {
            List<CountryModel> countryobjList = new List<CountryModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_State", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@StateCode", "");
                        cmd.Parameters.AddWithValue("@StateName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Stateobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Stateobj.StateCost);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CountryModel Countryobj = new CountryModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Countryobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Countryobj.CountryCode = dr["CountryCode"].ToString();
                                Countryobj.CountryName = dr["CountryName"].ToString();
                                Countryobj.Remarks = dr["Remarks"].ToString();
                                Countryobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Countryobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Countryobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Countryobj.IsActive = bool.Parse(dr["IsActive"].ToString());
                                //Stateobj.CompanyId = int.Parse(dr["CountryId"].ToString());
                                //Stateobj.CountryName = dr["CountryName"].ToString();


                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                countryobjList.Add(Countryobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return countryobjList;

        }

        public string DeleteStateMaster(DeleteObj obj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_State", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", obj.RecordId);
                        cmd.Parameters.AddWithValue("@StateCode", "");
                        cmd.Parameters.AddWithValue("@StateName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Stateobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Stateobj.StateCost);



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