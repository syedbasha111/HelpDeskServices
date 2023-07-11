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
    public class ModifyCapitalAssetDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public List<AddCapitalAsset> GetCapitalAsset(AddCapitalAsset request)
        {
            List<AddCapitalAsset> BaseResponce = new List<AddCapitalAsset>();

            try
            {
              
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-sp-GroupMaster]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",3 );
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Area", request.Area);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@BussinessUnit", request.BuisnessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                AddCapitalAsset responce = new AddCapitalAsset();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.AssertId = dr["AssertId"].ToString();
                                responce.AssetName = dr["AssetName"].ToString();
                                responce.statusmsg = dr["Statusmsg"].ToString();
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