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
    public class CompanyMasterDAL
    {
        public MVCompanyData GetBindingdata()
        {
            MVCompanyData BaseResponce = new MVCompanyData();
            BaseResponce.CompanyList = CompanyDetails();
            BaseResponce.CurrencycodeList = Currencycode();
            BaseResponce.TimeZoneList = TimeZonedetails();
            return BaseResponce;
        }

        internal List<CompanyMaster> GetCompanyBasedUser(string Username)
        {
            List<CompanyMaster> BaseResponce = new List<CompanyMaster>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[Hd-Tbl-CompanyMaster] where Active=1", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CompanyMaster responce = new CompanyMaster();

                                responce.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                responce.Name = dr["Name"].ToString();
                                responce.CmpyCode = dr["CmpyCode"].ToString();

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



        internal List<CompanyMaster> CompanyDetails()
        {
            List<CompanyMaster> BaseResponce = new List<CompanyMaster>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[CompanyMaster] where Active=@Status", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Status", "Y");
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CompanyMaster responce = new CompanyMaster();

                                responce.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                responce.Name = dr["Name"].ToString();
                                responce.CmpyCode = dr["CmpyCode"].ToString();

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
        internal List<CurrencyCode> Currencycode()
        {
            List<CurrencyCode> BaseResponce = new List<CurrencyCode>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[Hd-tbl-Currency]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CurrencyCode responce = new CurrencyCode();

                                responce.CurrencyId = int.Parse(dr["CurrencyId"].ToString());
                                responce.Currencycode = dr["Currencycode"].ToString();

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
        internal List<TimeZoneMaster> TimeZonedetails()
        {
            List<TimeZoneMaster> Baseresponce = new List<TimeZoneMaster>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[Hd_tbl-TimeZoneMaster]", conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                TimeZoneMaster responce = new TimeZoneMaster();

                                responce.Value = (dr["Value"].ToString());
                                responce.TimeZone = dr["TimeZone"].ToString();

                                Baseresponce.Add(responce);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            return Baseresponce;
        }

        public List<CurrencyCode> GetCurrencyName(int Id)
        {
            List<CurrencyCode> BaseResponce = new List<CurrencyCode>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[Hd-tbl-Currency] where  CurrencyId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CurrencyCode responce = new CurrencyCode();

                                responce.CurrencyId = int.Parse(dr["CurrencyId"].ToString());
                                responce.Currencyname = dr["Currencyname"].ToString();
                                responce.CmpyCode = dr["CmpyCode"].ToString();

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

        public List<CompanyMaster> GetCompanyName()
        {
            List<CompanyMaster> BaseResponce = new List<CompanyMaster>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",5);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CompanyMaster responce = new CompanyMaster();
                                responce.Name = dr["Name"].ToString();
                                responce.CmpyCode = dr["CmpyCode"].ToString();
                                responce.ParentCmpyCode = dr["ParentCmpyCode"].ToString();
                                responce.RegistrationDate =Convert.ToDateTime(dr["RegistrationDate"]);
                                // responce.OfficeType = dr["Type"].ToString();
                                responce.BaseCurrencyCode = dr["BaseCurrencyCode"].ToString();
                                responce.TimeZoneValue = dr["TimeZone"].ToString();
                                responce.CurrencyName = dr["CurrencyName"].ToString();
                                responce.TimeZone = dr["timezonename"].ToString();
                                responce.CompanyId =Convert.ToInt32(dr["CompanyId"]);
                                responce.RegistrationNo = dr["RegistrationNo"].ToString();
                                responce.Active = dr["Active"].ToString();
                                responce.Language = dr["Language"].ToString();
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

        public string CompanyMaster(CompanyMaster request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CmpyCode", request.CmpyCode);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@ParentCmpyCode", request.ParentCmpyCode);
                        cmd.Parameters.AddWithValue("@RegistrationNo", request.RegistrationNo);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@RegistrationDate", request.RegistrationDate);
                        cmd.Parameters.AddWithValue("@BaseCurrencyCode", request.BaseCurrencyCode);
                        cmd.Parameters.AddWithValue("@TimeZone", request.TimeZone);
                        cmd.Parameters.AddWithValue("@Language", request.Language);
                        cmd.Parameters.AddWithValue("@Active", request.Active);

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

        public string UpdateCompanyMaster(CompanyMaster request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CmpyCode", request.CmpyCode);
                        cmd.Parameters.AddWithValue("@Name", request.Name);
                        cmd.Parameters.AddWithValue("@ParentCmpyCode", request.ParentCmpyCode);
                        cmd.Parameters.AddWithValue("@RegistrationNo", request.RegistrationNo);
                        //cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@RegistrationDate", request.RegistrationDate);
                        cmd.Parameters.AddWithValue("@BaseCurrencyCode", request.BaseCurrencyCode);
                        cmd.Parameters.AddWithValue("@TimeZone", request.TimeZone);
                        cmd.Parameters.AddWithValue("@Language", request.Language);
                        cmd.Parameters.AddWithValue("@Active", request.Active);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        string status = "";
                        if (dt.Rows.Count > 0)
                        {
                            status = dt.Rows[0][0].ToString();
                        }

                        if (status == "Updated")
                        {
                            string DeleteStatus = deleteCompanyAdress(request.CompanyId);
                            if (DeleteStatus == "Deleted")
                            {
                                return request.CompanyId.ToString();
                            }

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

        public string deleteCompanyAdress(int Id)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (var conn = new SqlConnection(ConString))
                {
                    using (var cmd = new SqlCommand("[Hd-sp-CompanyAdress]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",4);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        DataTable dt = new DataTable();
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

            return "No records Found";

        }




        public string savelogoFile(CompanyMaster request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Logo", request.Logo);



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


        public string savedocsFile(CompanyMaster request)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyMaster]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationDocument", request.CompanyRegistrationDocument);



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

        public string SaveCompanyGrid(int Id, List<CompanyAdressDetails> request)
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

                        using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyAdress]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@CompanyId", Id);
                            cmd.Parameters.AddWithValue("@OfficeTypeId", data.OfficeTypeId);
                            cmd.Parameters.AddWithValue("@Address1", data.Address1);
                            cmd.Parameters.AddWithValue("@Address2", data.Address2);
                            cmd.Parameters.AddWithValue("@Address3", data.Address3);
                            cmd.Parameters.AddWithValue("@Country", data.CountryId);
                            cmd.Parameters.AddWithValue("@City", data.CityId);
                            cmd.Parameters.AddWithValue("@POBox", data.POBox);
                            cmd.Parameters.AddWithValue("@Tele1", data.Tele1);
                            cmd.Parameters.AddWithValue("@Tele2", data.Tele2);
                            cmd.Parameters.AddWithValue("@URL", data.URL);
                            cmd.Parameters.AddWithValue("@Fax", data.Fax);
                            cmd.Parameters.AddWithValue("@Email", data.Email);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter da = new SqlDataAdapter();
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


        public List<CompanyAdressDetails> GetCompanyAdress(int CompanyId)
        {
            List<CompanyAdressDetails> BaseResponce = new List<CompanyAdressDetails>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyAdress]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CompanyAdressDetails responce = new CompanyAdressDetails();
                                responce.CompanyMasterDetailId = Convert.ToInt32(dr["CompanyMasterDetailId"]);
                                responce.OfficeTypeId =Convert.ToInt32( dr["OfficeTypeId"]);
                                responce.Address1 =dr["Address1"].ToString();
                                responce.Address2 =dr["Address2"].ToString();
                                responce.Address3 =dr["Address3"].ToString();
                                responce.OfficeType = dr["Type"].ToString();
                                responce.CountryId = dr["Country"].ToString();
                                responce.CityId  = dr["City"].ToString();
                                responce.Tele1  = dr["Tele1"].ToString();
                                responce.Tele2  = dr["Tele2"].ToString();
                                responce.POBox = dr["POBox"].ToString();
                                responce.Fax = dr["Fax"].ToString();
                                responce.Email = dr["Email"].ToString();
                                responce.URL = dr["URL"].ToString();
                                responce.Country = dr["CountryName"].ToString();
                                responce.City = dr["CityName"].ToString();
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

        public List<OfficeTypeModel> GetCompanyType(int CompanyId)
        {
            List<OfficeTypeModel> BaseResponce = new List<OfficeTypeModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[Hd-sp-CompanyAdress]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                OfficeTypeModel responce = new OfficeTypeModel();
                                responce.Id = Convert.ToInt32(dr["Id"]);
                                responce.Type = dr["Type"].ToString();
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
    }
}