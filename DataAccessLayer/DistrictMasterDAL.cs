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
    public class DistrictMasterDAL
    {
        public string insertDistrictMaster(DistrictModel Districtobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@ID", Districtobj.CompanyId);
                        cmd.Parameters.AddWithValue("@DistrictCode", Districtobj.DistrictCode);
                        cmd.Parameters.AddWithValue("@DistrictName", Districtobj.DistrictName);
                        cmd.Parameters.AddWithValue("@Remarks", Districtobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Districtobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Districtobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Districtobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Districtobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Districtobj.CompanyId);
                        cmd.Parameters.AddWithValue("@CountryId", Districtobj.CountryId);
                        cmd.Parameters.AddWithValue("@StateId", Districtobj.StateId);
                        cmd.Parameters.AddWithValue("@CityId", Districtobj.CityId);

                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);



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

        public List<DistrictModel> GetDistrictMaster(int companyId)
        {
            List<DistrictModel> DistrictobjList = new List<DistrictModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@DistrictCode", "");
                        cmd.Parameters.AddWithValue("@DistrictName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CityId", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
                        cmd.Parameters.AddWithValue("@CountryId", 0);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                DistrictModel Districtobj = new DistrictModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Districtobj.DistrictId = int.Parse(dr["DistrictId"].ToString());
                                Districtobj.DistrictCode = dr["DistrictCode"].ToString();
                                Districtobj.DistrictName = dr["DistrictName"].ToString();
                                Districtobj.Remarks = dr["Remarks"].ToString();
                                Districtobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Districtobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Districtobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Districtobj.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                Districtobj.CountryId = Convert.ToInt32(dr["CountryId"]);
                                Districtobj.StateId = Convert.ToInt32(dr["StateId"]);
                                Districtobj.CityId = Convert.ToInt32(dr["CityId"]);
                                Districtobj.CountryName = dr["CountryName"].ToString();
                                Districtobj.CityId = int.Parse(dr["CityId"].ToString());
                                Districtobj.CityName = dr["CityName"].ToString();
                                Districtobj.StateName = dr["StateName"].ToString();



                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                DistrictobjList.Add(Districtobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return DistrictobjList;

        }

        public string updateDistrictMaster(DistrictModel Districtobj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", Districtobj.DistrictId);
                        cmd.Parameters.AddWithValue("@DistrictCode", Districtobj.DistrictCode);
                        cmd.Parameters.AddWithValue("@DistrictName", Districtobj.DistrictName);
                        cmd.Parameters.AddWithValue("@Remarks", Districtobj.Remarks);
                        //cmd.Parameters.AddWithValue("@LocationId", Districtobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", Districtobj.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", Districtobj.CreatedBy);
                        cmd.Parameters.AddWithValue("@ModifiedBy", Districtobj.ModifiedBy);
                        cmd.Parameters.AddWithValue("@CompanyId", Districtobj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", Districtobj.CountryId);
                        cmd.Parameters.AddWithValue("@CityId", Districtobj.CityId);
                        cmd.Parameters.AddWithValue("@StateId", Districtobj.StateId);
                        cmd.Parameters.AddWithValue("@CountryId", Districtobj.CountryId);
                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);
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
        public List<CityModel> GetCity(int companyId)
        {
            List<CityModel> CityobjList = new List<CityModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@DistrictCode", "");
                        cmd.Parameters.AddWithValue("@DistrictName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Districtobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CityId", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);

                        //cmd.Parameters.AddWithValue("@Cost", Districtobj.DistrictCost);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CityModel Cityobj = new CityModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Cityobj.CityId = int.Parse(dr["CityId"].ToString());
                                Cityobj.CityCode = dr["CityCode"].ToString();
                                Cityobj.CityName = dr["CityName"].ToString();
                                Cityobj.CountryId = int.Parse(dr["CountryId"].ToString());
                                Cityobj.Remarks = dr["Remarks"].ToString();
                                Cityobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Cityobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Cityobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Cityobj.IsActive = bool.Parse(dr["IsActive"].ToString());
                                //Districtobj.CompanyId = int.Parse(dr["CountryId"].ToString());
                                //Districtobj.CountryName = dr["CountryName"].ToString();


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

        public string DeleteDistrictMaster(int Districtid)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@ID", Districtid);
                        cmd.Parameters.AddWithValue("@DistrictCode", "");
                        cmd.Parameters.AddWithValue("@DistrictName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", Districtobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CityId", 0);
                        cmd.Parameters.AddWithValue("@StateId", 0);
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

        public List<DistrictModel> GetDistricts(DistrictModel request)
        {
            List<DistrictModel> DistrictobjList = new List<DistrictModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_District", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 8);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@DistrictCode", "");
                        cmd.Parameters.AddWithValue("@DistrictName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@CountryId", 0);
                        cmd.Parameters.AddWithValue("@CityId", request.CityId);
                        cmd.Parameters.AddWithValue("@StateId", request.StateId);
                        cmd.Parameters.AddWithValue("@CountryId", request.CountryId);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                DistrictModel Districtobj = new DistrictModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                Districtobj.DistrictId = int.Parse(dr["DistrictId"].ToString());
                                Districtobj.DistrictCode = dr["DistrictCode"].ToString();
                                Districtobj.DistrictName = dr["DistrictName"].ToString();
                                Districtobj.Remarks = dr["Remarks"].ToString();
                                Districtobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());

                                Districtobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                Districtobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                Districtobj.IsActive = Convert.ToBoolean(dr["IsActive"]);

                                Districtobj.CityId = int.Parse(dr["CityId"].ToString());



                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                DistrictobjList.Add(Districtobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return DistrictobjList;

        }
    }
}