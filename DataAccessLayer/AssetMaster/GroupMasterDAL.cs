using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.AssetMaster
{
    public class GroupMasterDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public List<GroupMasterModel> GetGroupMasterName(int CompanyId)
        {
            List<GroupMasterModel> BaseResponce = new List<GroupMasterModel>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-GroupMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                GroupMasterModel responce = new GroupMasterModel();
                                //data Assign to Model assign
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.Name = dr["Name"].ToString();
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

        public List<GroupMasterModel> GetGroupMasterCode(int Id,int CompanyId)
        {
            List<GroupMasterModel> BaseResponce = new List<GroupMasterModel>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-GroupMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                GroupMasterModel responce = new GroupMasterModel();
                                //data Assign to Model assign
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.code = dr["code"].ToString();
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