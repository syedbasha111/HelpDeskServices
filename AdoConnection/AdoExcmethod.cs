using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDeskServices.AdoConnection
{
    public class AdoExcmethod
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public DataSet ExecuteSelectProcedure(string procedeureName, params SqlParamDefinition[] parameters)
        {
            var ds = new DataSet();
            using (var con = new SqlConnection(ConString))
            {

                using (var cmd = new SqlCommand(procedeureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        // cmd.Parameters.Add(new SqlParameter(param.Name, param.DbType).Value = param.Value);
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }

                    try
                    {
                        con.Open();
                        var objDataAdapter = new SqlDataAdapter();
                        objDataAdapter.SelectCommand = cmd;

                        objDataAdapter.Fill(ds);

                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        //sql_log_err
                    }

                }
            }
            return ds;
        }

    }
}