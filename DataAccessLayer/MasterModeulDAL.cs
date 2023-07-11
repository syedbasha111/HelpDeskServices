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
    public class MasterModeulDAL
    {
        public List<menuObject> GetSideNavigation(string UserType, string CompanyCode)
        {
            List<menuObject> menuObjectList = new List<menuObject>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("GetMenuItems_hd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_Name", UserType);
                        cmd.Parameters.AddWithValue("@CmpyCode", CompanyCode);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        menuObjectList = GetMenuObject(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return menuObjectList;
        }

        public List<menuObject> GetMenuObject(DataTable menuTable)
        {
            List<menuObject> listMenuObject = new List<menuObject>();
            DataRow[] menuparent = menuTable.Select("Menu_Parent_Id =0");
            foreach (DataRow dr in menuparent)
            {
                menuObject mastermenu = new menuObject();
                mastermenu.id = dr["menu_id"].ToString();
                mastermenu.title = dr["menu_name"].ToString();
                mastermenu.url = dr["Menu_URL"].ToString();
                mastermenu.icon = dr["Menu_Item_Image"].ToString();
                mastermenu.translate = dr["ArabicTrans"].ToString();
                mastermenu.children = getParentObject(menuTable, mastermenu, dr);
                listMenuObject.Add(mastermenu);
            }

            return listMenuObject;
        }

        public List<ParentChild> getParentObject(DataTable menuTable, menuObject mastermenu, DataRow dr)
        {
            List<ParentChild> listParentObject = new List<ParentChild>();
            DataRow[] menuparent = menuTable.Select("Menu_Parent_Id = " + dr["menu_id"]);
            foreach (DataRow drparent in menuparent)
            {
                ParentChild Parentchild = new ParentChild();
                Parentchild.id = drparent["menu_id"].ToString();
                Parentchild.title = drparent["menu_name"].ToString();
                Parentchild.url = drparent["Menu_URL"].ToString();
                Parentchild.icon = drparent["Menu_Item_Image"].ToString();
                Parentchild.translate = drparent["ArabicTrans"].ToString();
                Parentchild.children = getChildObject(menuTable, Parentchild, drparent);
                listParentObject.Add(Parentchild);
            }

            return listParentObject;


        }

        public List<Child> getChildObject(DataTable menuTable, ParentChild Parentchild, DataRow dr)
        {
            List<Child> listChildObject = new List<Child>();
            DataRow[] menuparent = menuTable.Select("Menu_Parent_Id = " + dr["menu_id"]);
            foreach (DataRow drparent in menuparent)
            {
                Child ChildObject = new Child();
                ChildObject.id = drparent["menu_id"].ToString();
                ChildObject.title = drparent["menu_name"].ToString();
                ChildObject.url = drparent["Menu_URL"].ToString();
                ChildObject.icon = drparent["Menu_Item_Image"].ToString();
                ChildObject.translate = drparent["ArabicTrans"].ToString();

                ChildObject.children = getChildchildObject(menuTable, Parentchild, drparent);
                listChildObject.Add(ChildObject);
            }

            return listChildObject;
        }

        public List<Childchild> getChildchildObject(DataTable menuTable, ParentChild Parentchild, DataRow dr)
        {
            List<Childchild> listChildObject = new List<Childchild>();
            DataRow[] menuparent = menuTable.Select("Menu_Parent_Id = " + dr["menu_id"]);
            foreach (DataRow drparent in menuparent)
            {
                Childchild ChildObject = new Childchild();
                ChildObject.id = drparent["menu_id"].ToString();
                ChildObject.title = drparent["menu_name"].ToString();
                ChildObject.url = drparent["Menu_URL"].ToString();
                ChildObject.icon = drparent["Menu_Item_Image"].ToString();
                ChildObject.translate = drparent["ArabicTrans"].ToString();

                ChildObject.children = getChildObject(menuTable, Parentchild, drparent);
                listChildObject.Add(ChildObject);
            }

            return listChildObject;
        }


        public List<BusinessObject> GetBussinessUnit(int companyId)
         {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_BusinessUnit", conn))
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
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
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
                    using (SqlCommand cmd = new SqlCommand("HD_sp_BusinessUnit", conn))
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
                return ex.Message;
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
                    using (SqlCommand cmd = new SqlCommand("HD_sp_BusinessUnit", conn))
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
                return ex.Message;
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
                    using (SqlCommand cmd = new SqlCommand("HD_sp_BusinessUnit", conn))
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

        public string DeleteBussinessUnit(int BusinessId,int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_BusinessUnit", conn))
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
                return ex.Message;
            }

            return "No records Found";

        }

        public List<CountriesModel> GetCountries()
        {
            List<CountriesModel> countiesList = new List<CountriesModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_Country", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CountryCode", "");
                        cmd.Parameters.AddWithValue("@CountryName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        //cmd.Parameters.AddWithValue("@LocationId", countryobj.LocationId);
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", 1);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //cmd.Parameters.AddWithValue("@Cost", countryobj.CountryCost);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CountriesModel countriesObj = new CountriesModel();
                                countriesObj.CountryId = int.Parse(dr["CountryId"].ToString());
                                countriesObj.CmpCode = dr["CompanyId"].ToString();
                                countriesObj.CountryCode = dr["CountryCode"].ToString();
                                countriesObj.CountryName = dr["CountryName"].ToString();
                                //countriesObj.Active = int.Parse(dr["Active"].ToString());
                                countiesList.Add(countriesObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return countiesList;

        }

        public List<CitiesModel> GetCities(string countryId)
        {
            List<CitiesModel> citiesList = new List<CitiesModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_city", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 9);
                        cmd.Parameters.AddWithValue("@ID", 0);
                        cmd.Parameters.AddWithValue("@CityCode", "");
                        cmd.Parameters.AddWithValue("@CityName", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@CreatedBy", 0);
                        cmd.Parameters.AddWithValue("@ModifiedBy", "");
                        cmd.Parameters.AddWithValue("@CompanyId", "");
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@CountryId", countryId);
                        cmd.Parameters.AddWithValue("@StateId", "");
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CitiesModel citiesObj = new CitiesModel();
                                citiesObj.CitiesId = int.Parse(dr["CityId"].ToString());
                                citiesObj.CityCode = dr["CityCode"].ToString();
                                citiesObj.CityName = dr["CityName"].ToString();
                                citiesObj.CmpCode = dr["CompanyId"].ToString();
                                citiesList.Add(citiesObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return citiesList;

        }


        public List<CitiesModel> GetAllCities()
        {
            List<CitiesModel> citiesList = new List<CitiesModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_Sp_city", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@SCountry", "");
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                CitiesModel citiesObj = new CitiesModel();
                                citiesObj.CitiesId = int.Parse(dr["CityId"].ToString());
                                citiesObj.CountryCode = dr["CountryCode"].ToString();
                                citiesObj.CountryName = dr["CountryName"].ToString();
                                citiesObj.CityCode = dr["CityCode"].ToString();
                                citiesObj.CityName = dr["CityName"].ToString();
                                citiesObj.CmpCode = dr["CmpyCode"].ToString();
                                citiesList.Add(citiesObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return citiesList;

        }
        public List<LocationModel> GetLocationByCity(string cityCode, int companyId)
        {
            List<LocationModel> locationList = new List<LocationModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_getlocationBycity", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@CityId", cityCode);
                        cmd.Parameters.AddWithValue("@CompanyId", companyId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                LocationModel locationObj = new LocationModel();
                                locationObj.LocationId = int.Parse(dr["AssetId"].ToString());
                                locationObj.LocationCode = dr["AssetLocationCode"].ToString();
                                locationObj.LocationName = dr["AssetLocationName"].ToString();
                                locationList.Add(locationObj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return locationList;

        }


        public List<menuObject> GetSubmenuItems(int Categoryid, string lang)
        {
            List<menuObject> BaseResponce = new List<menuObject>();

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[GetMenuItems_hd]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", Categoryid);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                menuObject data = new menuObject();

                                //(lang == "arb" ? (data.label=dr["Menu_Name"].ToString()):(data.label = Convert.ToString(dr["Menu_Name"])));
                                if (lang != "arb")
                                    data.label = dr["Menu_Name"].ToString();
                                else
                                    data.label = dr["ArabicTrans"].ToString();

                                data.url = (dr["Menu_Url"]).ToString();
                                data.id = (dr["Menu_Id"]).ToString();
                                BaseResponce.Add(data);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return BaseResponce;

        }
    }
}