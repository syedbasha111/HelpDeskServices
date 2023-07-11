using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.Masters
{
    public class UserRightsDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;

        public string CreatUserRights(List<UserRights> request)
        {
            //RoleModel[] model = new RoleModel[] { };

            try
            {
                DataTable dt = new DataTable();

                foreach (var data in request)
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        using (cmd = new SqlCommand("[Hd-Sp-UserRights]", conn))
                        {
                            cmd.Parameters.AddWithValue("@Fcase", 1);
                            cmd.Parameters.AddWithValue("@UserId", data.UserId);
                            cmd.Parameters.AddWithValue("@RoleId", data.RoleId);
                            cmd.Parameters.AddWithValue("@CompanyId", data.CompanyId);
                            cmd.Parameters.AddWithValue("@view", data.view);
                            cmd.Parameters.AddWithValue("@new", data.newId);
                            cmd.Parameters.AddWithValue("@Edit", data.Edit);
                            cmd.Parameters.AddWithValue("@Approve", data.Approve);
                            cmd.Parameters.AddWithValue("@Print", data.Print);
                            cmd.Parameters.AddWithValue("@Delete", data.Delete);
                            cmd.Parameters.AddWithValue("@ScreenId", data.ScreenId);
                            cmd.Parameters.AddWithValue("@CreatedBy", data.CreatedBy);

                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Close();
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }


        public UserRights GetScreenUserRights(UserRights req)
        {
            UserRights data = new UserRights();
            try
            {
                if (req.Username=="Super Admin") {
                    data.view = true;
                    data.newId = true;
                    data.Edit = true;
                    data.Approve = true;
                    data.Print = true;
                    data.Delete = true;
                }
                else {
                    using (conn = new SqlConnection(ConString))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (cmd = new SqlCommand("[Hd-Sp-UserRights]", conn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            cmd.Parameters.AddWithValue("@Fcase", 2);
                            cmd.Parameters.AddWithValue("@CompanyId", req.CompanyId);
                            cmd.Parameters.AddWithValue("@UserId", req.UserId);
                            cmd.Parameters.AddWithValue("@RoleId", req.RoleId);
                            cmd.Parameters.AddWithValue("@ScreenId", req.ScreenId);
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = cmd;
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    //data.Id = Convert.ToInt32(dr["Id"]);
                                    data.UserId = Convert.ToInt32(dr["UserId"]);
                                    data.view = Convert.ToBoolean(dr["Viewit"]);
                                    data.newId = Convert.ToBoolean(dr["Newit"]);
                                    data.Edit = Convert.ToBoolean(dr["Editit"]);
                                    data.Approve = Convert.ToBoolean(dr["Approveit"]);
                                    data.Print = Convert.ToBoolean(dr["Printit"]);
                                    data.Delete = Convert.ToBoolean(dr["Deleteit"]);
                                   // data.ScreenId = (dr["ScreenId"].ToString());
                                }
                            }
                            else
                            {
                                CreateUserDAL UserDAL = new CreateUserDAL();
                                List<RoleModel> Rolelist = new List<RoleModel>();

                                Rolelist = UserDAL.GetRolesByUser(req.UserId.ToString(), req.CompanyId);

                                data.view = false;
                                data.newId = false;
                                data.Edit = false;
                                data.Approve = false;
                                data.Print = false;
                                data.Delete = false;
                                List<UserRights> Userightsmodel = new List<UserRights>();
                                foreach (var list in Rolelist)
                                {
                                    UserRights model = new UserRights();
                                    model = GetUserRigthsBYrole(req.CompanyId, list.RoleId, req.ScreenId);
                                    if (model.ScreenId != null)
                                        Userightsmodel.Add(model);
                                }
                                foreach (var rolerights in Userightsmodel)
                                {
                                    if (rolerights.view == true)
                                        data.view = true;
                                    if (rolerights.newId == true)
                                        data.newId = true;
                                    if (rolerights.Edit == true)
                                        data.Edit = true;
                                    if (rolerights.Approve == true)
                                        data.Approve = true;
                                    if (rolerights.Print == true)
                                        data.Print = true;
                                    if (rolerights.Delete == true)
                                        data.Delete = true;
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return data;
        }

        public UserRights GetUserRigthsBYrole(int CompanyId, int RoleId, string ScreenId)
        {
            UserRights data = new UserRights();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[Hd-Sp-UserRights]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@RoleId", RoleId);
                        cmd.Parameters.AddWithValue("@ScreenId", ScreenId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                data.Id = Convert.ToInt32(dr["Id"]);
                                data.UserId = Convert.ToInt32(dr["UserId"]);
                                data.view = Convert.ToBoolean(dr["view"]);
                                data.newId = Convert.ToBoolean(dr["new"]);
                                data.Edit = Convert.ToBoolean(dr["Edit"]);
                                data.Approve = Convert.ToBoolean(dr["Approve"]);
                                data.Print = Convert.ToBoolean(dr["Print"]);
                                data.Delete = Convert.ToBoolean(dr["Delete"]);
                                data.ScreenId = (dr["ScreenId"].ToString());
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }



        public class ScreenDetaisl
        {
            public string ScreenId { get; set; }
            public string ParentScreenId { get; set; }
        }
        public ScreenDetaisl GetUserdetails(string url)
        {
            ScreenDetaisl model = new ScreenDetaisl();
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (cmd = new SqlCommand("[Hd-Sp-UserRights]", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@url", url);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            model.ScreenId = dt.Rows[0]["Menu_Id"].ToString();
                            model.ParentScreenId = dt.Rows[0]["Menu_Parent_Id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return model;

        }

    }
}