using HelpDeskServices.AdoConnection;
using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static HelpDeskServices.Controllers.Masters.FutureplansController;

namespace HelpDeskServices.DataAccessLayer.Masters
{
    public class FutureplansDAL
    {
        AdoExcmethod spexc = new AdoExcmethod();

        public Hd_Responce Getplans(Featureplansearch req)
        {

            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  1),
                  new SqlParamDefinition("@Id",  req.pmtype),
                  new SqlParamDefinition("@planId",  req.planId),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_sp_FuturePlans]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    if (req.planId >0)
                    {
                        var convertedchildList = (from rw in dt.AsEnumerable()
                                                  select new
                                                  {
                                                      childid = Convert.ToString(rw["childid"]),
                                                      Id = Convert.ToString(rw["id"]),
                                                      assertid = Convert.ToString(rw["assertid"]),
                                                      site = Convert.ToString(rw["sitename"]),
                                                      zone = Convert.ToString(rw["zonename"]),
                                                      building = Convert.ToString(rw["buildingname"]),
                                                      floor = Convert.ToString(rw["floorname"]),
                                                      room = Convert.ToString(rw["roomname"]),
                                                      startdate = Convert.ToString(rw["startdate"]),
                                                      enddate = Convert.ToString(rw["enddate"]),
                                                      businessunit = Convert.ToString(rw["Description"]),
                                                      service = Convert.ToString(rw["ServiceDescription"]),
                                                      serviceid = Convert.ToString(rw["serviceid"]),
                                                      Status = Convert.ToString(rw["Status"]),
                                                      system = Convert.ToString(rw["System"]),
                                                      Assetcount = Convert.ToString(rw["Assetcount"]),
                                                     // tlcode = Convert.ToString(rw["TLCode"]),
                                                      thours = Convert.ToString(rw["TLHours"]),
                                                    //  Assetslotid = Convert.ToString(rw["Assetslotid"]),
                                                      createddate = Convert.ToString(rw["CreatedDate"]),
                                                      formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                      Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),
                                                  }).ToList();
                      
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = convertedchildList;

                        return responce;

                    }
                    else
                    {
                        var convertedList = (from rw in dt.AsEnumerable()
                                             select new
                                             {
                                                 Id = Convert.ToString(rw["id"]),
                                                 site = Convert.ToString(rw["sitename"]),
                                                 zone = Convert.ToString(rw["zonename"]),
                                                 building = Convert.ToString(rw["buildingname"]),
                                                 floor = Convert.ToString(rw["floorname"]),
                                                 room = Convert.ToString(rw["roomname"]),
                                                 startdate = Convert.ToString(rw["startdate"]),
                                                 enddate = Convert.ToString(rw["enddate"]),
                                                 businessunit = Convert.ToString(rw["Description"]),
                                                 service = Convert.ToString(rw["ServiceDescription"]),
                                                 system = Convert.ToString(rw["System"]),
                                                 Status = Convert.ToString(rw["Status"]),
                                                 Assetcount = Convert.ToString(rw["Assetcount"]),
                                                 createddate = Convert.ToString(rw["CreatedDate"]),
                                                 formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                 Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),
                                                 // tlcode = Convert.ToString(rw["TLCode"]),
                                                 thours = Convert.ToString(rw["TLHours"]),
                                               //  Assetslotid = Convert.ToString(rw["Assetslotid"]),

                                             }).Distinct().ToList();

                    
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = convertedList;

                        return responce;
                    }

                }
                responce.Status = "200";
                responce.Message = "Success";
                responce.Result = null;
            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = ex.Message;
                responce.Result = null;

            }
            return responce;
        }


        public Hd_Responce PlansToCreate()
        {

            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",2),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[HD_sp_FuturePlans]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {
                   
                        var convertedchildList = (from rw in dt.AsEnumerable()
                                                  select new
                                                  {
                                                      //childid = Convert.ToString(rw["childid"]),
                                                      Id = Convert.ToString(rw["id"]),
                                                     // assertid = Convert.ToString(rw["assertid"]),
                                                      site = Convert.ToString(rw["sitename"]),
                                                      sitecode = Convert.ToString(rw["SiteCode"]),
                                                      
                                                      zone = Convert.ToString(rw["zonename"]),
                                                      ZoneCode = Convert.ToString(rw["ZoneCode"]),
                                                      building = Convert.ToString(rw["buildingname"]),
                                                      buildingcode = Convert.ToString(rw["BuildingCode"]),
                                                      floor = Convert.ToString(rw["floorname"]),
                                                      floorCode = Convert.ToString(rw["FloorCode"]),
                                                      room = Convert.ToString(rw["roomname"]),
                                                      roomCode = Convert.ToString(rw["RoomCode"]),
                                                      
                                                      //startdate = Convert.ToString(rw["startdate"]),
                                                      //enddate = Convert.ToString(rw["enddate"]),
                                                      businessunit = Convert.ToString(rw["Description"]),
                                                      businessunitcode = Convert.ToString(rw["Code"]),
                                                      
                                                      service = Convert.ToString(rw["ServiceDescription"]),
                                                      serviceid = Convert.ToString(rw["serviceid"]),
                                                      ServiceCode = Convert.ToString(rw["ServiceCode"]),
                                                     
                                                      //Status = Convert.ToString(rw["Status"]),
                                                      system = Convert.ToString(rw["System"]),
                                                      SystemCode = Convert.ToString(rw["SystemCode"]),
                                                      
                                                      Assetcount = Convert.ToString(rw["Assetcount"]),
                                                      m = Convert.ToString(rw["M"]),
                                                      q = Convert.ToString(rw["Q"]),
                                                      s = Convert.ToString(rw["S"]),
                                                      a = Convert.ToString(rw["A"]),
                                                      mh = Convert.ToString(rw["MH"]),
                                                      qh = Convert.ToString(rw["QH"]),
                                                      sh = Convert.ToString(rw["SH"]),
                                                      ah = Convert.ToString(rw["AH"]),
                                                      monthly = Convert.ToString(rw["TLM-M"]),
                                                      quarterly = Convert.ToString(rw["TLM-Q"]),
                                                      semiannual = Convert.ToString(rw["TLM-S"]),
                                                      annual = Convert.ToString(rw["TLM-A"]),
                                                      tm = Convert.ToString(rw["CntM"]),
                                                      tq = Convert.ToString(rw["CntQ"]),
                                                      ts = Convert.ToString(rw["CntS"]),
                                                      ta = Convert.ToString(rw["CntA"]),
                                                      tcount = Convert.ToString(rw["TLHours"]),
                                                      

                                                      jan = Convert.ToString(rw["JAN"]),
                                                      feb = Convert.ToString(rw["FEB"]),
                                                      mar = Convert.ToString(rw["MAR"]),
                                                      apr = Convert.ToString(rw["APR"]),
                                                      may = Convert.ToString(rw["MAY"]),
                                                      jun = Convert.ToString(rw["JUN"]),
                                                      jul = Convert.ToString(rw["JUL"]),
                                                      aug = Convert.ToString(rw["AUG"]),
                                                      sep = Convert.ToString(rw["SEP"]),
                                                      oct = Convert.ToString(rw["OCT"]),
                                                      nov = Convert.ToString(rw["NOV"]),
                                                      dec = Convert.ToString(rw["DEC"]),
                                                       
                                                      isactive = Convert.ToString(rw["IsActive"]),
                                                      locationclass = Convert.ToString(rw["LocationClass"]),
                                                      systeminvno = Convert.ToString(rw["SYSINVNUM"]),
                                                      subsysteminvno = Convert.ToString(rw["SUBSYSINVNUM"]),
                                                      systemdescription = Convert.ToString(rw["SYSDESC"]),
                                                      subsystemdescription = Convert.ToString(rw["SUBSYSDESC"]),
                                                      assetclass = Convert.ToString(rw["AssetClass"]),
                                                      UniqueAssetid = Convert.ToString(rw["AssertId"]),
                                                      planremarks = Convert.ToString(rw["Remarks"]),
                                                      
                                                      // tlcode = Convert.ToString(rw["TLCode"]),
                                                      // thours = Convert.ToString(rw["TLHours"]),
                                                      //  Assetslotid = Convert.ToString(rw["Assetslotid"]),
                                                      // createddate = Convert.ToString(rw["CreatedDate"]),
                                                      formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                      Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),
                                                  }).Distinct().ToList();

                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = convertedchildList;

                        return responce;

                }
                responce.Status = "200";
                responce.Message = "No data found";
                responce.Result = null;
            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = ex.Message;
                responce.Result = null;

            }
            return responce;
        }


        public Hd_Responce SavePlanListItems(List<PlanListAddItemModel> req)
        {
            /*string status = "";*/
            Hd_Responce responce = new Hd_Responce();
            DataTable dt;

            try
            {
                foreach (var data in req)
                {
                    var parameters = new SqlParamDefinition[]
              {
                  new SqlParamDefinition("@Fcase", 1),
                  new SqlParamDefinition("@PlanId", data.PlanId),
                  new SqlParamDefinition("@year", data.Toyear),

            };
                    DataSet ds = spexc.ExecuteSelectProcedure("HD_SP_HDTEMP", parameters);
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        responce.Status = "-100";
                        responce.Message = "No data";
                        responce.Result = null;
                    }
                }


            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = ex.Message;
                responce.Result = null;
            }

            return responce;
        }

        public Hd_Responce UpdatedPlanListItems(List<PlanListAddItemModel> req)
        {
            /*string status = "";*/
            Hd_Responce responce = new Hd_Responce();
            DataTable dt;

            try
            {
                foreach (var data in req)
                {
                    var parameters = new SqlParamDefinition[]
              {
                  new SqlParamDefinition("@Fcase", 2),
                  new SqlParamDefinition("@Uniqueassetid",data.UniqueAssetid),
                   new SqlParamDefinition("@IsActive",data.IsActive),
                  //new SqlParamDefinition("@year", data.Toyear),
              };
                    DataSet ds = spexc.ExecuteSelectProcedure("HD_SP_HDTEMP", parameters);
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        responce.Status = "-100";
                        responce.Message = "No data";
                        responce.Result = null;
                    }
                }


            }
            catch (Exception ex)
            {
                responce.Status = "-100";
                responce.Message = ex.Message;
                responce.Result = null;
            }

            return responce;
        }



    }
}