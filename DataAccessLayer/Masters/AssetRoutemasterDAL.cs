using HelpDeskServices.AdoConnection;
using HelpDeskServices.Controllers.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_System.CreateController;

namespace HelpDeskServices.DataAccessLayer.Masters
{
    public class AssetRoutemasterDAL
    {
        AdoExcmethod spexc = new AdoExcmethod();


        public Hd_Responce SaveAssetroute(Assetroutegroupmode req)
        {
            Hd_Responce responce = new Hd_Responce();

            try
            {


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  1),
                  new SqlParamDefinition("@Code",  req.code),
                  new SqlParamDefinition("@Name",  req.Name),
                  new SqlParamDefinition("@Remarks",  req.Remarks),
                  new SqlParamDefinition("@CompanyId",  req.CompanyId),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_Sp_assetroutemaster]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = dt.Rows[0][0].ToString();
                    return responce;

                }
            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = "Failed";
                responce.Result = ex.Message;

            }

            return responce;

        }

        public Hd_Responce UpdateAssetroute(Assetroutegroupmode req)
        {
            Hd_Responce responce = new Hd_Responce();

            try
            {
                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  2),
                  new SqlParamDefinition("@Id",  req.Id),
                  new SqlParamDefinition("@Code",  req.code),
                  new SqlParamDefinition("@Name",  req.Name),
                  new SqlParamDefinition("@Remarks",  req.Remarks),
                  new SqlParamDefinition("@CompanyId",  req.CompanyId),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_Sp_assetroutemaster]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = dt.Rows[0][0].ToString();
                    return responce;

                }

            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = "Failed";
                responce.Result = ex.Message;

            }

            return responce;

        }

        public Hd_Responce getdetails(int companyid)
        {
            Hd_Responce responce = new Hd_Responce();

            try
            {
                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  3),
                  new SqlParamDefinition("@CompanyId",  companyid),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_Sp_assetroutemaster]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                             code = Convert.ToString(rw["Code"]),
                                             name = Convert.ToString(rw["Routename"]),
                                             Remarks = Convert.ToString(rw["Remarks"]),
                                             isactive = Convert.ToString(rw["IsActive"]),
                                             id = Convert.ToString(rw["Id"])
                                         }).ToList();



                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = convertedList;
                    return responce;

                }
                responce.Status = "200";
                responce.Message = "Success";
                responce.Result = null;
                return responce;
            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = "Failed";
                responce.Result = ex.Message;

            }

            return responce;

        }

        public Hd_Responce Delatedetails(int Id, int companyid)
        {
            Hd_Responce responce = new Hd_Responce();

            try
            {
                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  4),
                  new SqlParamDefinition("@CompanyId",  companyid),
                  new SqlParamDefinition("@Id",  Id),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_Sp_assetroutemaster]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = dt.Rows[0][0].ToString();

                    return responce;

                }

            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = "Failed";
                responce.Result = ex.Message;

            }

            return responce;

        }

        /// <summary>
        /// update asset route in add capital assert table.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Hd_Responce assetrouteupdate(List<planreq> req)
        {
            Hd_Responce responce = new Hd_Responce();

            try
            {
                foreach (var item in req)
                {
                    var parameters = new SqlParamDefinition[]
                  {
                  new SqlParamDefinition("@Fcase",  5),
                  new SqlParamDefinition("@ID",  item.Id),
                  new SqlParamDefinition("@Name",  item.Assetroute),
                  };
                    // SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = spexc.ExecuteSelectProcedure("[HD_Sp_assetroutemaster]", parameters);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = dt.Rows[0][0].ToString();

                    }

                }
                return responce;

            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = "Failed";
                responce.Result = ex.Message;

            }

            return responce;

        }


    }
}