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
    public class CompanyListDAL
    {
        public List<CompaniesModel> GetCompanyById(int companyId)
        {
            List<CompaniesModel> cmpList = new List<CompaniesModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_GetCompanies", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@ID", companyId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CompaniesModel compyObj = new CompaniesModel();
                                compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                compyObj.CompanyName = dr["Name"].ToString();
                                //citiesObj.CountryName = dr["CountryName"].ToString();
                                //citiesObj.CityCode = dr["CityCode"].ToString();
                                //citiesObj.CityName = dr["CityName"].ToString();
                                //citiesObj.CmpCode = dr["CmpyCode"].ToString();
                                cmpList.Add(compyObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return cmpList;

        }


     
    }
}