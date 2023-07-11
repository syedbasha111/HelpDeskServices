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
    public class CityMasterDAL
    {
        public string insertCityMaster(CityModel Cityobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Cityobj.CompanyId);
                        cmd.Parameters.AddWithValue("@CityCode", Cityobj.CityCode);
                        cmd.Parameters.AddWithValue("@CityName", Cityobj.CityName);
                        cmd.Parameters.AddWithValue("@Remarks", Cityobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Cityobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Cityobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Cityobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Cityobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Cityobj.CompanyId);
                        //cmd.Parameters.AddWithValue("@CountryId", Cityobj.CountryId);
                        cmd.Parameters.AddWithValue("@StateId", Cityobj.StateId);

                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", Cityobj.CountryId);
                        //cmd.Parameters.AddWithValue("@Cost", Cityobj.CityCost);



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

        public List<CityModel> GetCityMaster(int companyId)
        {
            List<CityModel> CityobjList = new List<CityModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CityCode", "");
                        cmd.Parameters.AddWithValue("@CityName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Cityobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Cityobj.CityCost);
                        cmd.Parameters.AddWithValue("@CountryId", 0);

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CityModel Cityobj = new CityModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Cityobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Cityobj.CityId = int.Parse(dr["CityId"].ToString());
                                Cityobj.CityCode = dr["CityCode"].ToString();
                                Cityobj.CityName = dr["CityName"].ToString();
                                Cityobj.Remarks = dr["Remarks"].ToString();
                                Cityobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Cityobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Cityobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Cityobj.IsActive = bool.Parse(dr["IsActive"].ToString());

                                Cityobj.CountryName = dr["CountryName"].ToString();
                                Cityobj.StateId = int.Parse(dr["StateId"].ToString());
                                Cityobj.StateName = dr["StateName"].ToString();



                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                CityobjList.Add(Cityobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return CityobjList;

        }

        public string updateCityMaster(CityModel Cityobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", Cityobj.CityId);
                        cmd.Parameters.AddWithValue("@CityCode", Cityobj.CityCode);
                        cmd.Parameters.AddWithValue("@CityName", Cityobj.CityName);
                        cmd.Parameters.AddWithValue("@Remarks", Cityobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Cityobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Cityobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Cityobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Cityobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Cityobj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", Cityobj.CountryId);
                        cmd.Parameters.AddWithValue("@StateId", Cityobj.StateId);
                        //cmd.Parameters.AddWithValue("@Cost", Cityobj.CityCost);
                        cmd.Parameters.AddWithValue("@CountryId", Cityobj.CountryId);

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
        public List<StateModel> GetState(int companyId,int countryId)
        {
            List<StateModel> StateobjList = new List<StateModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CityCode", "");
                        cmd.Parameters.AddWithValue("@CityName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Cityobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
                        cmd.Parameters.AddWithValue("@CountryId", countryId);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);

                        //cmd.Parameters.AddWithValue("@Cost", Cityobj.CityCost);


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
                                Stateobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Stateobj.Remarks = dr["Remarks"].ToString();
                                Stateobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Stateobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Stateobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Stateobj.IsActive = bool.Parse(dr["IsActive"].ToString());
                                //Cityobj.CompanyId = int.Parse(dr["CountryId"].ToString());
                                //Cityobj.CountryName = dr["CountryName"].ToString();


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

        public List<CityModel> Getcitybystate(int companyId, int countryId, int stateid)
        {
            List<CityModel> CityobjList = new List<CityModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 8);
                       cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CityCode", "");
                       cmd.Parameters.AddWithValue("@CityName", "");
                       cmd.Parameters.AddWithValue("@Remarks", "");
                       cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", countryId);
                        cmd.Parameters.AddWithValue("@StateId", stateid);

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CityModel Cityobj = new CityModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Cityobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Cityobj.CityId = int.Parse(dr["CityId"].ToString());
                                Cityobj.CityCode = dr["CityCode"].ToString();
                                Cityobj.CityName = dr["CityName"].ToString();
                                Cityobj.Remarks = dr["Remarks"].ToString();
                                Cityobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Cityobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Cityobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Cityobj.IsActive = bool.Parse(dr["IsActive"].ToString());

                                //Cityobj.CountryName = dr["CountryName"].ToString();
                                Cityobj.StateId = int.Parse(dr["StateId"].ToString());
                                //Cityobj.StateName = dr["StateName"].ToString();



                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                CityobjList.Add(Cityobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return CityobjList;

        }
        public string deleteCityMaster(DeleteObj obj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_City", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@CityCode", "");
                        cmd.Parameters.AddWithValue("@CityName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Cityobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
                        cmd.Parameters.AddWithValue("ID", obj.RecordId);
                        cmd.Parameters.AddWithValue("@CountryId", 0);



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