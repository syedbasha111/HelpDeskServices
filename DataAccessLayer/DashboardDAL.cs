using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static HelpDeskServices.Controllers.DashboardController;

namespace HelpDeskServices.DataAccessLayer
{
    public class DashboardDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();


        public HelpdeskManagement GetHelpdeskManagement(int companyId)
        {
            HelpdeskManagement responce = new HelpdeskManagement();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Dashboard]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            responce.RequestsRaised = Convert.ToInt32(dt.Rows[0]["RequestsRaised"].ToString());
                            responce.ProceedWO = Convert.ToInt32(dt.Rows[0]["Proceed_WO"].ToString());
                            responce.SRAssign = Convert.ToInt32(dt.Rows[0]["SRAssign"].ToString());
                            responce.WOCreated = Convert.ToInt32(dt.Rows[0]["WOCreated"].ToString());
                            responce.WOInProgress = Convert.ToInt32(dt.Rows[0]["WOInProgress"].ToString());
                            responce.WO_OnHold = Convert.ToInt32(dt.Rows[0]["WO_OnHold"].ToString());
                            responce.WO_Completed = Convert.ToInt32(dt.Rows[0]["WOCompleted"].ToString());
                            responce.WO_Closed = Convert.ToInt32(dt.Rows[0]["WOClosed"].ToString());
                            responce.RequestCancelled = Convert.ToInt32(dt.Rows[0]["RequestCancelled"].ToString());
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return responce;

        }


        public assetcounts GetAssetdata(int companyId)
        {
            assetcounts responce = new assetcounts();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataSet dt = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Dashboard]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        DataTable sitelocation = dt.Tables[0];
                        DataTable Service = dt.Tables[1];
                        responce.LocationCount = AssetlocationCount(sitelocation);
                        responce.Serviceount = AssetserviceCount(Service);
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
            return responce;
        }

        public List<assetlocation> AssetlocationCount(DataTable dt)
        {
            List<assetlocation> baserespone = new List<assetlocation>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    assetlocation responce = new assetlocation();
                    responce.name = dr["SiteName"].ToString();
                    responce.y = dr["sitecount"].ToString();
                    baserespone.Add(responce);
                }

                //responce.RequestsRaised = Convert.ToInt32(dt.Rows[0]["RequestsRaised"].ToString());

            }
            return baserespone;
        }

        public List<assetservice> AssetserviceCount(DataTable dt)
        {
            List<assetservice> baserespone = new List<assetservice>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    assetservice responce = new assetservice();
                    responce.y = dr["servicecount"].ToString();
                    responce.name = dr["ServiceDescription"].ToString();
                    baserespone.Add(responce);
                }

                //responce.RequestsRaised = Convert.ToInt32(dt.Rows[0]["RequestsRaised"].ToString());

            }
            return baserespone;
        }



        public List<ListOfhelpedeskmanagement> GetmapbyLocation(List<LocationRequest> request)
       {
            List<ListOfhelpedeskmanagement> Basereponce = new List<ListOfhelpedeskmanagement>();


            try
            {
                foreach (var site in request)
                {
                    ListOfhelpedeskmanagement sitereponce = new ListOfhelpedeskmanagement();

                    List<HelpdeskManagement> responce = new List<HelpdeskManagement>();

                    List<Service> servicelist = new List<Service>();
                    if (site.Locationservice.Count > 0)
                        servicelist = site.Locationservice;
                    else
                        servicelist = GetservciceByLocation(site.CompanyId);

                    foreach (var i in servicelist)
                    {
                        using (SqlConnection conn = new SqlConnection(ConString))
                        {

                            DataTable dt = new DataTable();
                            using (SqlCommand cmd = new SqlCommand("[hd_sp_Dashboard]", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                cmd.Parameters.AddWithValue("@Fcase", 3);
                                cmd.Parameters.AddWithValue("@companyId", site.CompanyId);
                                cmd.Parameters.AddWithValue("@site", site.Site);
                                cmd.Parameters.AddWithValue("@Service", i.ServiceID);
                                cmd.CommandType = CommandType.StoredProcedure;
                                conn.Open();
                                da.SelectCommand = cmd;
                                conn.Close();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    HelpdeskManagement data = new HelpdeskManagement();

                                    data.ServiceName = i.ServiceDescription;
                                    data.RequestsRaised = Convert.ToInt32(dt.Rows[0]["RequestsRaised"].ToString());
                                    data.ProceedWO = Convert.ToInt32(dt.Rows[0]["Proceed_WO"].ToString());
                                    data.SRAssign = Convert.ToInt32(dt.Rows[0]["SRAssign"].ToString());
                                    data.WOCreated = Convert.ToInt32(dt.Rows[0]["WOCreated"].ToString());
                                    data.WOInProgress = Convert.ToInt32(dt.Rows[0]["WOInProgress"].ToString());
                                    data.WO_OnHold = Convert.ToInt32(dt.Rows[0]["WO_OnHold"].ToString());
                                    data.WO_Completed = Convert.ToInt32(dt.Rows[0]["WOCompleted"].ToString());
                                    data.WO_Closed = Convert.ToInt32(dt.Rows[0]["WOClosed"].ToString());
                                    data.RequestCancelled = Convert.ToInt32(dt.Rows[0]["RequestCancelled"].ToString());
                                    data.Lat = Convert.ToDecimal(dt.Rows[0]["Lat"].ToString());
                                    data.Lng = Convert.ToDecimal(dt.Rows[0]["Lng"].ToString());
                                    responce.Add(data);
                                }
                            }
                        }

                    }

                    sitereponce.Site = site.Site;
                    sitereponce.StatusDetails = responce;
                    sitereponce.Lat = responce[0].Lat;
                    sitereponce.Lng = responce[0].Lng;
                    Basereponce.Add(sitereponce);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Basereponce;
        }



        public List<ListOfhelpedeskmanagement> GetmapbyLocationPM(List<LocationRequest> request)
        {
            List<ListOfhelpedeskmanagement> Basereponce = new List<ListOfhelpedeskmanagement>();


            try
            {
                foreach (var site in request)
                {
                    ListOfhelpedeskmanagement sitereponce = new ListOfhelpedeskmanagement();

                    List<HelpdeskManagement> responce = new List<HelpdeskManagement>();

                    List<Service> servicelist = new List<Service>();
                    if (site.Locationservice.Count > 0)
                        servicelist = site.Locationservice;
                    else
                        servicelist = GetservciceByLocation(site.CompanyId);

                    foreach (var i in servicelist)
                    {
                        using (SqlConnection conn = new SqlConnection(ConString))
                        {

                            DataTable dt = new DataTable();
                            using (SqlCommand cmd = new SqlCommand("[hd_sp_Dashboard]", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter();
                                cmd.Parameters.AddWithValue("@Fcase", 5);
                                cmd.Parameters.AddWithValue("@companyId", site.CompanyId);
                                cmd.Parameters.AddWithValue("@site", site.Site);
                                cmd.Parameters.AddWithValue("@Service", i.ServiceID);
                                cmd.CommandType = CommandType.StoredProcedure;
                                conn.Open();
                                da.SelectCommand = cmd;
                                conn.Close();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    HelpdeskManagement data = new HelpdeskManagement();

                                    data.ServiceName = i.ServiceDescription;
                                    data.RequestsRaised = Convert.ToInt32(dt.Rows[0]["RequestsRaised"].ToString());
                                    data.ProceedWO = Convert.ToInt32(dt.Rows[0]["Proceed_WO"].ToString());
                                    data.SRAssign = Convert.ToInt32(dt.Rows[0]["SRAssign"].ToString());
                                    data.WOCreated = Convert.ToInt32(dt.Rows[0]["WOCreated"].ToString());
                                    data.WOInProgress = Convert.ToInt32(dt.Rows[0]["WOInProgress"].ToString());
                                    data.WO_OnHold = Convert.ToInt32(dt.Rows[0]["WO_OnHold"].ToString());
                                    data.WO_Completed = Convert.ToInt32(dt.Rows[0]["WOCompleted"].ToString());
                                    data.WO_Closed = Convert.ToInt32(dt.Rows[0]["WOClosed"].ToString());
                                    data.RequestCancelled = Convert.ToInt32(dt.Rows[0]["RequestCancelled"].ToString());
                                    data.Lat = Convert.ToDecimal(dt.Rows[0]["Lat"].ToString());
                                    data.Lng = Convert.ToDecimal(dt.Rows[0]["Lng"].ToString());
                                    responce.Add(data);
                                }
                            }
                        }

                    }

                    sitereponce.Site = site.Site;
                    sitereponce.StatusDetails = responce;
                    sitereponce.Lat = responce[0].Lat;
                    sitereponce.Lng = responce[0].Lng;
                    Basereponce.Add(sitereponce);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Basereponce;
        }
        public List<Service> GetservciceByLocation(int companyId)
        {
            List<Service> responce = new List<Service>();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConString))
                {

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("[hd_sp_Dashboard]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        da.SelectCommand = cmd;
                        conn.Close();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Service baseresponce = new Service();
                                baseresponce.ServiceID = Convert.ToInt32(dr["ID"]);
                                baseresponce.ServiceDescription = dr["ServiceDescription"].ToString();
                                responce.Add(baseresponce);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return responce;

        }


    }
}