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
                    using (SqlCommand cmd = new SqlCommand("GetMenuItems", conn))
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
                ChildObject.children = getChildObject(menuTable, Parentchild, drparent);
                listChildObject.Add(ChildObject);
            }

            return listChildObject;
        }


        public List<BusinessObject> GetBussinessUnit()
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
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@Code", "");
                        cmd.Parameters.AddWithValue("@Description", "");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.Parameters.AddWithValue("@Companyid", 0);
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
                throw;
            }

            return "";

        }

        public string updateBusinessUnit(string Code, string Description, string Remark, int CompanyId, int createdBy, int modifiedBy, int IsActive, int BusinessId)
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
                        cmd.Parameters.AddWithValue("@Code", Code);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@Remarks", Remark);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
                        cmd.Parameters.AddWithValue("@createdby", createdBy);
                        cmd.Parameters.AddWithValue("@Modifiedby", modifiedBy);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@ID", BusinessId);
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

        public string DeleteBussinessUnit(int BusinessId)
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
                        cmd.Parameters.AddWithValue("@Fcase", 4);
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