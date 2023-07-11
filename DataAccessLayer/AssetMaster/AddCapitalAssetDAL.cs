using HelpDeskServices.DataModels;
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
    public class AddCapitalAssetDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        #region Saving addCapitalAsseet
        public string SaveAddCapitalAsset(AddCapitalAsset request)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 7);
                        cmd.Parameters.AddWithValue("@BuisnessUnit", request.BuisnessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Area", request.Area);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@AssertId", request.AssertId);
                        cmd.Parameters.AddWithValue("@AssetName", request.AssetName);
                        cmd.Parameters.AddWithValue("@RateContract", request.RateContract);
                        cmd.Parameters.AddWithValue("@vendor", request.vendor);
                        cmd.Parameters.AddWithValue("@AssetPrice", request.AssetPrice);
                        cmd.Parameters.AddWithValue("@AssetSerialNo", request.AssetSerialNo);
                        cmd.Parameters.AddWithValue("@LifeSpan", request.LifeSpan);
                        cmd.Parameters.AddWithValue("@PONumber", request.PONumber);
                        cmd.Parameters.AddWithValue("@WarrntydateUpto", request.WarrntydateUpto);
                        cmd.Parameters.AddWithValue("@PurchaseDate", request.PurchaseDate);
                        cmd.Parameters.AddWithValue("@Mfgdate", request.Mfgdate);
                        cmd.Parameters.AddWithValue("@AnnualDepreciation", request.AnnualDepreciation);
                        cmd.Parameters.AddWithValue("@Department", request.Department);
                        cmd.Parameters.AddWithValue("@status", request.status);
                        cmd.Parameters.AddWithValue("@AssetFor", request.AssetFor);
                        cmd.Parameters.AddWithValue("@Priority", request.Priority);
                        cmd.Parameters.AddWithValue("@AssetInstallatiodate", request.AssetInstallatiodate);
                        cmd.Parameters.AddWithValue("@AssetCommissioningdate", request.AssetCommissioningdate);
                        cmd.Parameters.AddWithValue("@AssetCostValue", request.AssetCostValue);
                        cmd.Parameters.AddWithValue("@AssetScrapValue", request.AssetScrapValue);
                        cmd.Parameters.AddWithValue("@AMCIncluded", request.AMCIncluded);
                        cmd.Parameters.AddWithValue("@AmcDateUpto", request.AmcDateUpto);
                        cmd.Parameters.AddWithValue("@InsuranceIncluded", request.InsuranceIncluded);
                        cmd.Parameters.AddWithValue("@InsuranceDate", request.InsuranceDate);
                        cmd.Parameters.AddWithValue("@Count", request.Count);
                        cmd.Parameters.AddWithValue("@AssetPriority", request.AssetPriority);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@LocationId", request.LocationId);
                        cmd.Parameters.AddWithValue("@LocationClass", request.LocationClass);
                        cmd.Parameters.AddWithValue("@AssestClass", request.AssestClass);
                        cmd.Parameters.AddWithValue("@frequency", request.Frequency);

                        cmd.Parameters.AddWithValue("@SystemQty", request.SystemQty);
                        cmd.Parameters.AddWithValue("@SubSystemQty", request.SubSystemQty);
                        cmd.Parameters.AddWithValue("@uniqueassertref", request.uniqueassertref);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                           string id= dt.Rows[0][0].ToString();
                           string AssetId= updateAssetId(id,request.AssertId);
                            updateAddcapitalassetsActive(request.CompanyId, request.uniqueassertref);
                            if (AssetId != null)
                            {
                                return id;
                            }
                            
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

        public string updateAddcapitalassetsActive(int companyid,string refassetuniquid)
        {
            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 16);
                        cmd.Parameters.AddWithValue("@AssertId", refassetuniquid);
                        cmd.Parameters.AddWithValue("@CompanyId", companyid);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString() == "Updated")
                            {
                                return "Updated";
                            }

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

        public string UpdateAddCapitalAsset(AddCapitalAsset request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 12);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@BuisnessUnit", request.BuisnessUnit);
                        cmd.Parameters.AddWithValue("@Service", request.Service);
                        cmd.Parameters.AddWithValue("@System", request.System);
                        cmd.Parameters.AddWithValue("@SubSystem", request.SubSystem);
                        cmd.Parameters.AddWithValue("@Site", request.Site);
                        cmd.Parameters.AddWithValue("@Zone", request.Zone);
                        cmd.Parameters.AddWithValue("@Building", request.Building);
                        cmd.Parameters.AddWithValue("@Floor", request.Floor);
                        cmd.Parameters.AddWithValue("@Area", request.Area);
                        cmd.Parameters.AddWithValue("@Room", request.Room);
                        cmd.Parameters.AddWithValue("@AssertId", request.AssertId);
                        cmd.Parameters.AddWithValue("@AssetName", request.AssetName);
                        cmd.Parameters.AddWithValue("@RateContract", request.RateContract);
                        cmd.Parameters.AddWithValue("@vendor", request.vendor);
                        cmd.Parameters.AddWithValue("@AssetPrice", request.AssetPrice);
                        cmd.Parameters.AddWithValue("@AssetSerialNo", request.AssetSerialNo);
                        cmd.Parameters.AddWithValue("@LifeSpan", request.LifeSpan);
                        cmd.Parameters.AddWithValue("@PONumber", request.PONumber);
                        cmd.Parameters.AddWithValue("@WarrntydateUpto", request.WarrntydateUpto);
                        cmd.Parameters.AddWithValue("@PurchaseDate", request.PurchaseDate);
                        cmd.Parameters.AddWithValue("@Mfgdate", request.Mfgdate);
                        cmd.Parameters.AddWithValue("@AnnualDepreciation", request.AnnualDepreciation);
                        cmd.Parameters.AddWithValue("@Department", request.Department);
                        cmd.Parameters.AddWithValue("@status", request.status);
                        cmd.Parameters.AddWithValue("@AssetFor", request.AssetFor);
                        cmd.Parameters.AddWithValue("@Priority", request.Priority);
                        cmd.Parameters.AddWithValue("@AssetInstallatiodate", request.AssetInstallatiodate);
                        cmd.Parameters.AddWithValue("@AssetCommissioningdate", request.AssetCommissioningdate);
                        cmd.Parameters.AddWithValue("@AssetCostValue", request.AssetCostValue);
                        cmd.Parameters.AddWithValue("@AssetScrapValue", request.AssetScrapValue);
                        cmd.Parameters.AddWithValue("@AMCIncluded", request.AMCIncluded);
                        cmd.Parameters.AddWithValue("@AmcDateUpto", request.AmcDateUpto);
                        cmd.Parameters.AddWithValue("@InsuranceIncluded", request.InsuranceIncluded);
                        cmd.Parameters.AddWithValue("@InsuranceDate", request.InsuranceDate);
                        cmd.Parameters.AddWithValue("@Count", request.Count);
                        cmd.Parameters.AddWithValue("@AssetPriority", request.AssetPriority);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@LocationClass", request.LocationClass);
                        cmd.Parameters.AddWithValue("@AssestClass", request.AssestClass);
                        cmd.Parameters.AddWithValue("@frequency", request.Frequency);

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if(dt.Rows[0][0].ToString()== "Updated") {
                                return request.Id.ToString();
                            }
                            
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

        public List<AddCapitalAsset> GetCapitalAsset(int Id,int CompanyId)
        {
            List<AddCapitalAsset> BaseResponce = new List<AddCapitalAsset>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 11);
                        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                        cmd.Parameters.AddWithValue("@Id", Id);
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
                                responce.BuisnessUnit = Convert.ToInt32(dr["BuisnessUnit"].ToString());
                                responce.Service = Convert.ToInt32(dr["Service"].ToString());
                                responce.System = Convert.ToInt32(dr["System"].ToString());
                                responce.SubSystem = Convert.ToInt32(dr["SubSystem"].ToString());
                                responce.Site = Convert.ToInt32(dr["Site"].ToString());
                                responce.Zone = Convert.ToInt32(dr["Zone"].ToString());
                                responce.Building = Convert.ToInt32(dr["Building"].ToString());
                                responce.Floor = Convert.ToInt32(dr["Floor"].ToString());
                                responce.Area = Convert.ToInt32(dr["Area"].ToString());
                                responce.Room = Convert.ToInt32(dr["Room"].ToString());
                                responce.AssertId = Convert.ToString(dr["AssertId"].ToString());
                                responce.AssetName = Convert.ToString(dr["AssetName"].ToString());
                                responce.RateContract = Convert.ToString(dr["RateContract"].ToString());
                                responce.vendor = Convert.ToInt32(dr["vendor"].ToString());
                                responce.AssetPrice = Convert.ToDecimal(dr["AssetPrice"].ToString());
                                responce.AssetSerialNo = Convert.ToString(dr["AssetSerialNo"].ToString());
                                responce.LifeSpan = Convert.ToString(dr["LifeSpan"].ToString());
                                responce.PONumber = Convert.ToString(dr["PONumber"].ToString());
                                responce.WarrntydateUpto = Convert.ToDateTime(dr["WarrntydateUpto"].ToString());
                                responce.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                                responce.Mfgdate = Convert.ToDateTime(dr["Mfgdate"].ToString());
                                responce.AnnualDepreciation = Convert.ToDecimal(dr["AnnualDepreciation"].ToString());
                                responce.Department = Convert.ToInt32(dr["Department"].ToString());
                                responce.LocationId = dr["LocationId"].Equals(DBNull.Value)?0: Convert.ToInt32(dr["LocationId"].ToString());
                                responce.status = Convert.ToInt32(dr["status"].ToString());
                                responce.AssetFor = Convert.ToInt32(dr["AssetFor"].ToString());
                                responce.Priority = Convert.ToInt32(dr["Priority"].ToString());
                                responce.AssetPriority = Convert.ToInt32(dr["AssetPriority"].ToString());
                                responce.AssetInstallatiodate = Convert.ToDateTime(dr["AssetInstallatiodate"].ToString());
                                responce.AssetCommissioningdate = Convert.ToDateTime(dr["AssetCommissioningdate"].ToString());
                                responce.AssetCostValue = Convert.ToString(dr["AssetCostValue"].ToString());
                                responce.AssetScrapValue = Convert.ToString(dr["AssetScrapValue"].ToString());
                                responce.UploadAssetImage = Convert.ToString(dr["UploadAssetImage"].ToString());
                                responce.UploadAssetDocument = Convert.ToString(dr["UploadAssetDocument"].ToString());
                                responce.UploadInsuranceDocument = Convert.ToString(dr["UploadInsuranceDocument"].ToString());
                                responce.AMCIncluded = Convert.ToString(dr["AMCIncluded"].ToString());
                                responce.InsuranceIncluded = Convert.ToString(dr["InsuranceIncluded"].ToString());
                                responce.AmcDateUpto = Convert.ToDateTime(dr["AmcDateUpto"].ToString());
                                responce.InsuranceDate = Convert.ToDateTime(dr["InsuranceDate"].ToString());
                                responce.Count = Convert.ToString(dr["Count"].ToString());
                                responce.AssestClass = dr["AssestClass"].ToString();
                                responce.LocationClass = dr["LocationClass"].ToString();
                                responce.SystemQty =Convert.ToInt32(dr["SystemQty"].ToString());
                                responce.SubSystemQty = Convert.ToInt32(dr["SubSystemQty"].ToString());
                                
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

        public string SaveAssetImage(AddCapitalAsset request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 8);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@UploadAssetImage", request.UploadAssetImage);
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

            return "";

        }

        public string SaveAssetDocument(AddCapitalAsset request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 9);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@UploadAssetDocument", request.UploadAssetDocument);
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

            return "";

        }

        public string SaveInsuranceDocument(AddCapitalAsset request)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 10);
                        cmd.Parameters.AddWithValue("@Id", request.Id);
                        cmd.Parameters.AddWithValue("@CompanyId", request.CompanyId);
                        cmd.Parameters.AddWithValue("@UploadInsuranceDocument", request.UploadInsuranceDocument);
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

            return "";

        }
        #endregion
        #region dropdowns data from Master
        public List<Vendor> GetVendordata(int CompanyId)
        {
            List<Vendor> BaseResponce = new List<Vendor>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@CompanyId",CompanyId);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Vendor responce = new Vendor();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.VendorName = dr["VendorName"].ToString();
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
        public List<Department> GetDepartmentdata(int CompanyId)
        {
            List<Department> BaseResponce = new List<Department>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",2 );
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
                                Department responce = new Department();
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
        public List<AddassetStatus> GetStatus(int CompanyId)
        {
            List<AddassetStatus> BaseResponce = new List<AddassetStatus>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",4 );
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
                                AddassetStatus responce = new AddassetStatus();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.Status = dr["Status"].ToString();
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
        public List<AssetFormodel> GetAssetfordata(int CompanyId)
        {
            List<AssetFormodel> BaseResponce = new List<AssetFormodel>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",3 );
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
                                AssetFormodel responce = new AssetFormodel();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.AssetFor = dr["AssetFor"].ToString();
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
        public List<PriorityModel> GetPrioritydata(int CompanyId)
        {
            List<PriorityModel> BaseResponce = new List<PriorityModel>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase",5 );
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
                                PriorityModel responce = new PriorityModel();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.Priority = dr["Priority"].ToString();
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
        public List<AssetPrioritymodel> GetAssetPrioritydata(int CompanyId)
        {
            List<AssetPrioritymodel> BaseResponce = new List<AssetPrioritymodel>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 6);
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
                                AssetPrioritymodel responce = new AssetPrioritymodel();
                                responce.Id = Convert.ToInt32(dr["Id"].ToString());
                                responce.AssetPriority = dr["AssetPriority"].ToString();
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

        public List<Locationclass> GetLocationclass(int CompanyId)
        {
            List<Locationclass> BaseResponce = new List<Locationclass>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 14);
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
                                Locationclass responce = new Locationclass();
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
        public List<Locationclass> GetAssetClass(int CompanyId)
        {
            List<Locationclass> BaseResponce = new List<Locationclass>();

            try
            {
                using (conn = new SqlConnection(ConString))
                {
                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.Parameters.AddWithValue("@Fcase", 15);
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
                                Locationclass responce = new Locationclass();
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

        #endregion


        public string updateAssetId(string Id,string assetId)
        {

            try
            {
                using (conn = new SqlConnection(ConString))
                {

                    using (cmd = new SqlCommand("[Hd-Sp-AddAssetLocation]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 13);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@AssertId", assetId+"-"+ Id);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Close();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString() == "Updated")
                            {
                                return Id;
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Id;
        }
    }
}