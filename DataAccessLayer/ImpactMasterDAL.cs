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
    public class ImpactMasterDAL
    {
        public string insertImpactCallMaster(ImpactCallMasterModel impactObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_ImpactMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@Id", impactObj.ImpactCallMasterId);
                        cmd.Parameters.AddWithValue("@ImpactCode", impactObj.ImpactCallCode);
                        cmd.Parameters.AddWithValue("@ImpactName", impactObj.ImpactCallName);
                        cmd.Parameters.AddWithValue("@Remark", impactObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", impactObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", impactObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", impactObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", impactObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);




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

        public string UpdateImpactMaster(ImpactCallMasterModel impactObj)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_ImpactMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", impactObj.ImpactCallMasterId);
                        cmd.Parameters.AddWithValue("@ImpactCode", impactObj.ImpactCallCode);
                        cmd.Parameters.AddWithValue("@ImpactName", impactObj.ImpactCallName);
                        cmd.Parameters.AddWithValue("@Remark", impactObj.Remark);
                        cmd.Parameters.AddWithValue("@IsActive", impactObj.IsActive);
                        cmd.Parameters.AddWithValue("@createdBy", impactObj.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", impactObj.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Companyid", impactObj.CompanyId);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
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


        public List<ImpactCallMasterModel> GetImpactMaster(int companyId)
        {
            List<ImpactCallMasterModel> impactobjList = new List<ImpactCallMasterModel>();
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_ImpactMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);

                        cmd.Parameters.AddWithValue("@Id", 0);
                        cmd.Parameters.AddWithValue("@ImpactCode", "");
                        cmd.Parameters.AddWithValue("@ImpactName", "");
                        cmd.Parameters.AddWithValue("@Remark", "");
                        cmd.Parameters.AddWithValue("@IsActive", 0);
                        cmd.Parameters.AddWithValue("@createdBy", 0);
                        cmd.Parameters.AddWithValue("@UpdatedBy", 0);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        cmd.Parameters.AddWithValue("@UpdatedOn", "");
                        cmd.Parameters.AddWithValue("@CreatedOn", "");
                        cmd.Parameters.AddWithValue("@Companyid", companyId);


                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ImpactCallMasterModel impactobj = new ImpactCallMasterModel();
                                //compyObj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                //compyObj.CompanyName = dr["Name"].ToString();
                                impactobj.ImpactCallMasterId = int.Parse(dr["ID"].ToString());
                                impactobj.ImpactCallCode = dr["ImpactCode"].ToString();
                                impactobj.ImpactCallName = dr["ImpactName"].ToString();
                                impactobj.Remark = dr["Remark"].ToString();
                                impactobj.CreatedBy = int.Parse(dr["CreatedBy"].ToString());
                                //escalationObj.LocationName = int.Parse(dr["Service_Escalation_Id"].ToString());
                                //escalationObj.LocationId = int.Parse(dr["Service_Escalation_Id"].ToString());
                                impactobj.UpdatedBy = int.Parse(dr["UpdatedBy"].ToString());
                                impactobj.CompanyId = int.Parse(dr["CompanyId"].ToString());
                                impactobj.IsDeleted = int.Parse(dr["IsDeleted"].ToString());
                                impactobj.IsActive = int.Parse(dr["IsActive"].ToString());
                                impactobj.CreatedOn = dr["CreatedOn"].ToString();
                                impactobj.UpdatedOn = dr["UpdatedOn"].ToString();

                                //repeatobj.CompanyId = int.Parse(dr["CompanyId"].ToString());


                                impactobjList.Add(impactobj);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return impactobjList;

        }

        public string DeleteImpactMaster(int recordId,int CompanyId)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("HD_sp_ImpactMaster", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@Companyid", CompanyId);
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

            return "No records Found";

        }
    }
}