using HelpDeskServices.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataAccessLayer.DocumentsPathsDAL
{

    public class ImageModel
    {
        public string Imagepathpath { get; set; }
        public string docspath { get; set; }
    }
    public class DeleteImages
    {
        public List<ImageModel> GetImagespathdetails(IList<Imagepathdetails> req)
        {

            List<ImageModel> baseresponce = new List<ImageModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Hd_Imagedelete", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", req[0].Id);
                        cmd.Parameters.AddWithValue("@TableName", req[0].TableName);
                        cmd.Parameters.AddWithValue("@Id_name", req[0].Id_name);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ImageModel data = new ImageModel();
                                data.Imagepathpath =(dr[req[0].ImagePath1]).ToString();
                                baseresponce.Add(data);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return baseresponce;
        }
    }
}