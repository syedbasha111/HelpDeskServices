using HelpDeskServices.AdoConnection;
using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static HelpDeskServices.Controllers.Maintenance_mgmt.PM_by_group.CreateplanController;

namespace HelpDeskServices.DataAccessLayer.Maintenance_mgmt.Pm_by_group
{
    public class createplan
    {
        AdoExcmethod spexc = new AdoExcmethod();
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public IEnumerable<object> getcreatedetails(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            List<object> responce = new List<object>();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("[Hd_Sp_Pmbygroup]", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@location", req.Locations);
                        cmd.Parameters.AddWithValue("@Companyid", req.Companyid);
                        cmd.Parameters.AddWithValue("@zone", req.Zone);
                        cmd.Parameters.AddWithValue("@building", req.Building);
                        cmd.Parameters.AddWithValue("@Business", req.Businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.system);
                        cmd.Parameters.AddWithValue("@Floorreq", req.Floor);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsystem);
                        cmd.Parameters.AddWithValue("@pageno", req.Pageno);
                        cmd.Parameters.AddWithValue("@pagesize", req.pagesize);
                        cmd.Parameters.AddWithValue("@fromdate", req.fromdate);
                        cmd.Parameters.AddWithValue("@todate", req.todate);

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {

                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new
                                                 {
                                                     Id= Convert.ToString(rw["id"]),
                                                     System= Convert.ToString(rw["System"]),
                                                     SubSystemCode = Convert.ToString(rw["SubSystemCode"]),
                                                     SubSystem = Convert.ToString(rw["SubSystem"]),
                                                     AssertId = Convert.ToString(rw["AssertId"]),
                                                     UniqueAssestid = Convert.ToString(rw["UniqueAssestid"]),
                                                     AssetName = Convert.ToString(rw["AssetName"]),
                                                 }).ToList().Distinct();

                            return convertedList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return responce;

        }


        public object Createplan(List<planreq> req)
    {
        object baseModel = new object();
        string id = CreatePmsysplan(1);

        foreach (var item in req)
        {
            try
            {
                plan createplan = new plan();
                tasklistreq taskreq = new tasklistreq();

                DataTable dt = getassetdetailsbyid(Convert.ToInt32(item.Id));

                if (dt.Rows.Count > 0)
                {
                    createplan = (from rw in dt.AsEnumerable()
                                  select new plan
                                  {
                                      AssertId = Convert.ToString(rw["AssertId"]),
                                      AssetRouteID = Convert.ToString(rw["AssertRoute"]),
                                      AssetName = Convert.ToString(rw["AssertId"]),
                                      BUId = Convert.ToString(rw["BuisnessUnit"]),
                                      SERVICEId = Convert.ToString(rw["Service"]),
                                      SYSID = Convert.ToString(rw["System"]),
                                      SUBSYSID = Convert.ToString(rw["SubSystem"]),
                                      SSQty = Convert.ToString(rw["SubSystemQty"]),
                                      Sqty = Convert.ToString(rw["SystemQty"]),
                                      Site = Convert.ToString(rw["Site"]),
                                      LCID = Convert.ToString(rw["Site"]),
                                      ZN = Convert.ToString(rw["Zone"]),
                                      BuildingID = Convert.ToString(rw["Building"]),
                                      FLRID = Convert.ToString(rw["Floor"]),
                                      Area = Convert.ToString(rw["Area"]),
                                      RMID = Convert.ToString(rw["Room"]),
                                      LocationClass = Convert.ToString(rw["LocationId"]),

                                  }).FirstOrDefault();

                    taskreq.businessunit = createplan.BUId;
                    taskreq.service = createplan.SERVICEId;
                    taskreq.sys = createplan.SYSID;
                    taskreq.subsys = createplan.SUBSYSID;
                    taskreq.tasktype = "2";



                }
                string[] frqnames = item.Frequency.Split(',');


                for (int t = 0; t < frqnames.Length; t++)
                {
                    switch (frqnames[t])
                    {
                        case "Monthly":
                            createplan.M = "M";
                            createplan.JAN = "M";
                            createplan.FEB = "M";
                            createplan.MAR = "M";
                            createplan.APR = "M";
                            createplan.MAY = "M";
                            createplan.JUN = "M";
                            createplan.JUL = "M";
                            createplan.AUG = "M";
                            createplan.SEP = "M";
                            createplan.OCT = "M";
                            createplan.NOV = "M";
                            createplan.DEC = "M";
                            createplan.CntM = 12;
                            taskreq.freq = "1";

                            createplan.TLM_M = gettasklistcode(taskreq);
                            createplan.Hours = gettasklisthours(taskreq);

                            break;


                        case "Quarterly":

                            DateTime date1 = DateTime.Now;

                            for (int i = 0; i < 4; i++)
                            {
                                string CurrentMonth1 = "";
                                if (i == 0)
                                {
                                    CurrentMonth1 = String.Format("{0:MMMM}", date1);
                                }
                                else if (i > 0)
                                {
                                    DateTime addeddate = date1.AddMonths(3);
                                    CurrentMonth1 = String.Format("{0:MMMM}", addeddate);
                                }


                                createplan.Q = "Q";
                                if (CurrentMonth1 == "January")
                                    createplan.JAN = "Q";

                                if (CurrentMonth1 == "February")
                                    createplan.FEB = "Q";

                                if (CurrentMonth1 == "March")
                                    createplan.MAR = "Q";

                                if (CurrentMonth1 == "April")
                                    createplan.APR = "Q";

                                if (CurrentMonth1 == "May")
                                    createplan.MAY = "Q";

                                if (CurrentMonth1 == "June")
                                    createplan.JUN = "Q";

                                if (CurrentMonth1 == "July")
                                    createplan.JUL = "Q";

                                if (CurrentMonth1 == "August")
                                    createplan.AUG = "Q";

                                if (CurrentMonth1 == "September")
                                    createplan.SEP = "Q";

                                if (CurrentMonth1 == "October")
                                    createplan.OCT = "Q";

                                if (CurrentMonth1 == "November")
                                    createplan.NOV = "Q";

                                if (CurrentMonth1 == "December")
                                    createplan.DEC = "Q";
                            }
                            taskreq.freq = "2";
                            createplan.CntQ = 4;


                            createplan.TLM_Q = gettasklistcode(taskreq);
                            createplan.Hours = gettasklisthours(taskreq);


                            break;

                        case "SemiAnnually":

                            DateTime date2 = DateTime.Now;

                            for (int i = 0; i < 2; i++)
                            {
                                string CurrentMonth2 = "";
                                if (i == 0)
                                {
                                    CurrentMonth2 = String.Format("{0:MMMM}", date2);
                                }
                                else if (i > 0)
                                {
                                    DateTime addeddate = date2.AddMonths(6);
                                    CurrentMonth2 = String.Format("{0:MMMM}", addeddate);
                                }
                                createplan.CntS = 2;


                                createplan.S = "S";
                                if (CurrentMonth2 == "January")
                                    createplan.JAN = "S";

                                if (CurrentMonth2 == "February")
                                    createplan.FEB = "S";

                                if (CurrentMonth2 == "March")
                                    createplan.MAR = "S";

                                if (CurrentMonth2 == "April")
                                    createplan.APR = "S";

                                if (CurrentMonth2 == "May")
                                    createplan.MAY = "S";

                                if (CurrentMonth2 == "June")
                                    createplan.JUN = "S";

                                if (CurrentMonth2 == "July")
                                    createplan.JUL = "S";

                                if (CurrentMonth2 == "August")
                                    createplan.AUG = "S";

                                if (CurrentMonth2 == "September")
                                    createplan.SEP = "S";

                                if (CurrentMonth2 == "October")
                                    createplan.OCT = "S";

                                if (CurrentMonth2 == "November")
                                    createplan.NOV = "S";

                                if (CurrentMonth2 == "December")
                                    createplan.DEC = "S";
                            }
                            taskreq.freq = "3";

                            createplan.TLM_S = gettasklistcode(taskreq);
                            createplan.Hours = gettasklisthours(taskreq);


                            break;
                        case "Annually":
                            createplan.CntA = 1;

                            DateTime date3 = DateTime.Now;
                            string CurrentMonth = String.Format("{0:MMMM}", date3);
                            createplan.A = "A";
                            if (CurrentMonth == "January")
                                createplan.JAN = "A";

                            if (CurrentMonth == "February")
                                createplan.FEB = "A";

                            if (CurrentMonth == "March")
                                createplan.MAR = "A";

                            if (CurrentMonth == "April")
                                createplan.APR = "A";

                            if (CurrentMonth == "May")
                                createplan.MAY = "A";

                            if (CurrentMonth == "June")
                                createplan.JUN = "A";

                            if (CurrentMonth == "July")
                                createplan.JUL = "A";

                            if (CurrentMonth == "August")
                                createplan.AUG = "A";

                            if (CurrentMonth == "September")
                                createplan.SEP = "A";

                            if (CurrentMonth == "October")
                                createplan.OCT = "A";

                            if (CurrentMonth == "November")
                                createplan.NOV = "A";

                            if (CurrentMonth == "December")
                                createplan.DEC = "A";

                            taskreq.freq = "4";
                            createplan.TLM_A = gettasklistcode(taskreq);
                            createplan.Hours = gettasklisthours(taskreq);


                            break;
                    }
                }


                if (Convert.ToInt32(id) > 0)
                {
                    createplan.Total = createplan.CntA + createplan.CntM + createplan.CntQ + createplan.CntS;
                    for (int t = 0; t < frqnames.Length; t++)
                    {
                        DateTime date1 = DateTime.Now;
                        if (frqnames[t] == "Monthly")
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                DateTime addeddate = date1.AddMonths(1);

                                    CreatePmgroupplanchild(createplan, 1, Convert.ToInt32(id), item.FromDate, item.Todate, addeddate);

                            }
                            break;
                        }
                        else if (frqnames[t] == "Quarterly")
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                DateTime addeddate = date1.AddMonths(3);

                                    CreatePmgroupplanchild(createplan, 1, Convert.ToInt32(id), item.FromDate, item.Todate, addeddate);

                            }
                            break;
                        }
                        else if (frqnames[t] == "SemiAnnually")
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                DateTime addeddate = date1.AddMonths(2);

                                    CreatePmgroupplanchild(createplan, 1, Convert.ToInt32(id), item.FromDate, item.Todate, addeddate);

                            }
                            break;
                        }
                        else if (frqnames[t] == "Annually")
                        {
                            for (int i = 0; i <= 1; i++)
                            {
                                DateTime addeddate = date1.AddMonths(1);

                                    CreatePmgroupplanchild(createplan, 1, Convert.ToInt32(id), item.FromDate, item.Todate, addeddate);

                            }
                            break;
                        }

                    }
                    //CreatePmsysplanchild(createplan, 1, Convert.ToInt32(id), item.FromDate, item.Todate);
                    Updateplanid(Convert.ToInt32(id));
                    updateAssetcapitaltocreateplan(Convert.ToInt32(item.Id));
                    baseModel = "Created";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        return baseModel;
    }

        public Hd_Responce getcreatedetailsforchange(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  8),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",req.fromdate),
                  new SqlParamDefinition("@todate", req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {



                    if (req.id != null)
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
                                                      tlcode = Convert.ToString(rw["TLCode"]),
                                                      thours = Convert.ToString(rw["TLHours"]),
                                                      Assetslotid = Convert.ToString(rw["Assetslotid"]),
                                                      createddate = Convert.ToString(rw["CreatedDate"]),
                                                      formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                      Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                                  }).ToList();
                        req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                        if (req.frequency != "" && req.frequency != null)
                        {

                            string[] freqlist = req.frequency.Split(',');
                            string indexes = "";
                            for (int j = 0; j < convertedchildList.Count(); j++)
                            {
                                int count = 0;

                                string frequencysub = convertedchildList[j].Frequency;
                                if (frequencysub == "")
                                {
                                    indexes += j + ",";
                                    // convertedList.RemoveAt(j);

                                }
                                else
                                {
                                    frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                    string[] freqlistsp = frequencysub.Split(',');
                                    for (int k = 0; k < freqlistsp.Count(); k++)
                                    {
                                        for (int i = 0; i < freqlist.Count(); i++)
                                        {
                                            if (freqlist[i] != freqlistsp[k])
                                            {
                                                count++;
                                            }
                                        }
                                    }
                                    int mutiple = freqlistsp.Count() * freqlist.Count();
                                    if (mutiple == count)
                                    {
                                        indexes += j + ",";
                                        //convertedList.RemoveAt(j);
                                    }
                                }

                            }

                            indexes = indexes == "" ? null : indexes.TrimEnd(',');
                            if (indexes != null)
                            {
                                string[] indexeslist = indexes.Split(',');
                                //for (int i = 0; i < indexeslist.Count(); i++)
                                //{
                                //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                                //}

                                foreach (string indice in indexeslist.OrderByDescending(v => v))
                                {
                                    convertedchildList.RemoveAt(Convert.ToInt32(indice));
                                }

                            }


                        }
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
                                                 //childid = Convert.ToString(rw["childid"]),

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
                                                 Assetslotid = Convert.ToString(rw["Assetslotid"]),

                                             }).Distinct().ToList();

                        req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                        if (req.frequency != "" && req.frequency != null)
                        {

                            string[] freqlist = req.frequency.Split(',');
                            string indexes = "";
                            for (int j = 0; j < convertedList.Count(); j++)
                            {
                                int count = 0;

                                string frequencysub = convertedList[j].Frequency;
                                if (frequencysub == "")
                                {
                                    indexes += j + ",";
                                    // convertedList.RemoveAt(j);

                                }
                                else
                                {
                                    frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                    string[] freqlistsp = frequencysub.Split(',');
                                    for (int k = 0; k < freqlistsp.Count(); k++)
                                    {
                                        for (int i = 0; i < freqlist.Count(); i++)
                                        {
                                            if (freqlist[i] != freqlistsp[k])
                                            {
                                                count++;
                                            }
                                        }
                                    }
                                    int mutiple = freqlistsp.Count() * freqlist.Count();
                                    if (mutiple == count)
                                    {
                                        indexes += j + ",";
                                        //convertedList.RemoveAt(j);
                                    }
                                }

                            }

                            indexes = indexes == "" ? null : indexes.TrimEnd(',');
                            if (indexes != null)
                            {
                                string[] indexeslist = indexes.Split(',');
                                //for (int i = 0; i < indexeslist.Count(); i++)
                                //{
                                //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                                //}

                                foreach (string indice in indexeslist.OrderByDescending(v => v))
                                {
                                    convertedList.RemoveAt(Convert.ToInt32(indice));
                                }

                            }


                        }
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

        public Hd_Responce Changeplan(List<planreq> req)
        {
            Hd_Responce responce = new Hd_Responce();
            try
            {
                string result = "";
                foreach (var item in req)
                {

                    var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  9),
                  new SqlParamDefinition("@Id",  item.Id),
                  new SqlParamDefinition("@fromdate",  item.FromDate),
                  new SqlParamDefinition("@todate",  item.Todate),
                   };
                    // SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        result = dt.Rows[0][0].ToString();
                    }
                }
                if (result == "Updated")
                {
                    responce.Status = "200";
                    responce.Message = "Updated";
                    responce.Result = null;
                }
                else
                {
                    responce.Status = "-100";
                    responce.Message = "error ";
                    responce.Result = null;
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

        public Hd_Responce getlistforapprove(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  12),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {



                    if (req.id != null)
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
                                                      system = Convert.ToString(rw["System"]),
                                                      createddate = Convert.ToString(rw["CreatedDate"]),
                                                      formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                      Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                                  }).ToList();
                        req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                        if (req.frequency != "" && req.frequency != null)
                        {

                            string[] freqlist = req.frequency.Split(',');
                            string indexes = "";
                            for (int j = 0; j < convertedchildList.Count(); j++)
                            {
                                int count = 0;

                                string frequencysub = convertedchildList[j].Frequency;
                                if (frequencysub == "")
                                {
                                    indexes += j + ",";
                                    // convertedList.RemoveAt(j);

                                }
                                else
                                {
                                    frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                    string[] freqlistsp = frequencysub.Split(',');
                                    for (int k = 0; k < freqlistsp.Count(); k++)
                                    {
                                        for (int i = 0; i < freqlist.Count(); i++)
                                        {
                                            if (freqlist[i] != freqlistsp[k])
                                            {
                                                count++;
                                            }
                                        }
                                    }
                                    int mutiple = freqlistsp.Count() * freqlist.Count();
                                    if (mutiple == count)
                                    {
                                        indexes += j + ",";
                                        //convertedList.RemoveAt(j);
                                    }
                                }

                            }

                            indexes = indexes == "" ? null : indexes.TrimEnd(',');
                            if (indexes != null)
                            {
                                string[] indexeslist = indexes.Split(',');
                                //for (int i = 0; i < indexeslist.Count(); i++)
                                //{
                                //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                                //}

                                foreach (string indice in indexeslist.OrderByDescending(v => v))
                                {
                                    convertedchildList.RemoveAt(Convert.ToInt32(indice));
                                }

                            }


                        }
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
                                                 //startdate = Convert.ToString(rw["startdate"]),
                                                 // enddate = Convert.ToString(rw["enddate"]),
                                                 businessunit = Convert.ToString(rw["Description"]),
                                                 service = Convert.ToString(rw["ServiceDescription"]),
                                                 system = Convert.ToString(rw["System"]),
                                                 // createddate = Convert.ToString(rw["CreatedDate"]),
                                                 formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                                 Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                             }).Distinct().ToList();

                        req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                        if (req.frequency != "" && req.frequency != null)
                        {

                            string[] freqlist = req.frequency.Split(',');
                            string indexes = "";
                            for (int j = 0; j < convertedList.Count(); j++)
                            {
                                int count = 0;

                                string frequencysub = convertedList[j].Frequency;
                                if (frequencysub == "")
                                {
                                    indexes += j + ",";
                                    // convertedList.RemoveAt(j);

                                }
                                else
                                {
                                    frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                    string[] freqlistsp = frequencysub.Split(',');
                                    for (int k = 0; k < freqlistsp.Count(); k++)
                                    {
                                        for (int i = 0; i < freqlist.Count(); i++)
                                        {
                                            if (freqlist[i] != freqlistsp[k])
                                            {
                                                count++;
                                            }
                                        }
                                    }
                                    int mutiple = freqlistsp.Count() * freqlist.Count();
                                    if (mutiple == count)
                                    {
                                        indexes += j + ",";
                                        //convertedList.RemoveAt(j);
                                    }
                                }

                            }

                            indexes = indexes == "" ? null : indexes.TrimEnd(',');
                            if (indexes != null)
                            {
                                string[] indexeslist = indexes.Split(',');
                                //for (int i = 0; i < indexeslist.Count(); i++)
                                //{
                                //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                                //}

                                foreach (string indice in indexeslist.OrderByDescending(v => v))
                                {
                                    convertedList.RemoveAt(Convert.ToInt32(indice));
                                }

                            }


                        }
                        responce.Status = "200";
                        responce.Message = "Success";
                        responce.Result = convertedList;

                        return responce;
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

        public Hd_Responce ApprovePlanWo(List<apprvid> request)
        {
            Hd_Responce responce = new Hd_Responce();
            try
            {
                foreach (var data in request)
                {
                    var parameters = new SqlParamDefinition[] { };
                    if (data.Status == "Approve")
                    {
                        parameters = new SqlParamDefinition[]
                      {
                  new SqlParamDefinition("@Fcase", 14),
                  new SqlParamDefinition("@Id", data.Id),
                  new SqlParamDefinition("@CompanyId", data.Companyid),
                  new SqlParamDefinition("@AssetRouteDesc", data.Remarks),
                      };
                    }
                    else
                    {
                        parameters = new SqlParamDefinition[]
                    {
                  new SqlParamDefinition("@Fcase", 15),
                  new SqlParamDefinition("@Id", data.Id),
                  new SqlParamDefinition("@CompanyId", data.Companyid),
                  new SqlParamDefinition("@AssetRouteDesc", data.Remarks),
                    };
                    }

                    DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                    DataTable dt = ds.Tables[0];

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

        public Hd_Responce GetprintWOaftrapprv(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  17),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                             Id = Convert.ToString(rw["id"]),
                                             pmplanId = Convert.ToString(rw["id"]),
                                             Assetcount = Convert.ToString(rw["Assetcount"]),
                                             Group = Convert.ToString(rw["Routename"]),
                                             //status = Convert.ToString(rw["Status"]),
                                             //remarks = Convert.ToString(rw["remarks"]),
                                             site = Convert.ToString(rw["sitename"]),
                                             zone = Convert.ToString(rw["zonename"]),
                                             building = Convert.ToString(rw["buildingname"]),
                                             floor = Convert.ToString(rw["floorname"]),
                                             room = Convert.ToString(rw["roomname"]),
                                             //startdate = Convert.ToString(rw["startdate"]),
                                             //enddate = Convert.ToString(rw["enddate"]),
                                             businessunit = Convert.ToString(rw["Description"]),
                                             service = Convert.ToString(rw["ServiceDescription"]),
                                             system = Convert.ToString(rw["System"]),
                                             //createddate = Convert.ToString(rw["CreatedDate"]),
                                             formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                             Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                         }).Distinct().ToList();

                    req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                    if (req.frequency != "" && req.frequency != null)
                    {

                        string[] freqlist = req.frequency.Split(',');
                        string indexes = "";
                        for (int j = 0; j < convertedList.Count(); j++)
                        {
                            int count = 0;

                            string frequencysub = convertedList[j].Frequency;
                            if (frequencysub == "")
                            {
                                indexes += j + ",";
                                // convertedList.RemoveAt(j);

                            }
                            else
                            {
                                frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                string[] freqlistsp = frequencysub.Split(',');
                                for (int k = 0; k < freqlistsp.Count(); k++)
                                {
                                    for (int i = 0; i < freqlist.Count(); i++)
                                    {
                                        if (freqlist[i] != freqlistsp[k])
                                        {
                                            count++;
                                        }
                                    }
                                }
                                int mutiple = freqlistsp.Count() * freqlist.Count();
                                if (mutiple == count)
                                {
                                    indexes += j + ",";
                                    //convertedList.RemoveAt(j);
                                }
                            }

                        }

                        indexes = indexes == "" ? null : indexes.TrimEnd(',');
                        if (indexes != null)
                        {
                            string[] indexeslist = indexes.Split(',');
                            //for (int i = 0; i < indexeslist.Count(); i++)
                            //{
                            //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                            //}

                            foreach (string indice in indexeslist.OrderByDescending(v => v))
                            {
                                convertedList.RemoveAt(Convert.ToInt32(indice));
                            }

                        }
                    }
                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = convertedList;

                    return responce;
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
        public Hd_Responce GetDetailsbycomplete(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  1),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_sp_Pmbysys_Complete]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                             Id = Convert.ToString(rw["id"]),
                                             pmplanId = Convert.ToString(rw["id"]),
                                             Assetcount = Convert.ToString(rw["Assetcount"]),
                                             Group = Convert.ToString(rw["Routename"]),
                                             status = Convert.ToString(rw["Status"]),
                                             remarks = Convert.ToString(rw["remarks"]),
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
                                             createddate = Convert.ToString(rw["CreatedDate"]),
                                             formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                             Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                         }).Distinct().ToList();

                    req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                    if (req.frequency != "" && req.frequency != null)
                    {

                        string[] freqlist = req.frequency.Split(',');
                        string indexes = "";
                        for (int j = 0; j < convertedList.Count(); j++)
                        {
                            int count = 0;

                            string frequencysub = convertedList[j].Frequency;
                            if (frequencysub == "")
                            {
                                indexes += j + ",";
                                // convertedList.RemoveAt(j);

                            }
                            else
                            {
                                frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                string[] freqlistsp = frequencysub.Split(',');
                                for (int k = 0; k < freqlistsp.Count(); k++)
                                {
                                    for (int i = 0; i < freqlist.Count(); i++)
                                    {
                                        if (freqlist[i] != freqlistsp[k])
                                        {
                                            count++;
                                        }
                                    }
                                }
                                int mutiple = freqlistsp.Count() * freqlist.Count();
                                if (mutiple == count)
                                {
                                    indexes += j + ",";
                                    //convertedList.RemoveAt(j);
                                }
                            }

                        }

                        indexes = indexes == "" ? null : indexes.TrimEnd(',');
                        if (indexes != null)
                        {
                            string[] indexeslist = indexes.Split(',');
                            //for (int i = 0; i < indexeslist.Count(); i++)
                            //{
                            //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                            //}

                            foreach (string indice in indexeslist.OrderByDescending(v => v))
                            {
                                convertedList.RemoveAt(Convert.ToInt32(indice));
                            }

                        }
                    }
                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = convertedList;

                    return responce;
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
        public Hd_Responce GetpmbygrpWoCloselist(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  17),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                             Id = Convert.ToString(rw["id"]),
                                             pmplanId = Convert.ToString(rw["id"]),
                                             // ChildId = Convert.ToString(rw["childid"]),
                                             Assetcount = Convert.ToString(rw["Assetcount"]),
                                             Group = Convert.ToString(rw["Routename"]),
                                             //status = Convert.ToString(rw["Status"]),
                                             //remarks = Convert.ToString(rw["remarks"]),
                                             site = Convert.ToString(rw["sitename"]),
                                             zone = Convert.ToString(rw["zonename"]),
                                             building = Convert.ToString(rw["buildingname"]),
                                             floor = Convert.ToString(rw["floorname"]),
                                             room = Convert.ToString(rw["roomname"]),
                                             //startdate = Convert.ToString(rw["startdate"]),
                                             //enddate = Convert.ToString(rw["enddate"]),
                                             businessunit = Convert.ToString(rw["Description"]),
                                             service = Convert.ToString(rw["ServiceDescription"]),
                                             system = Convert.ToString(rw["System"]),
                                             //createddate = Convert.ToString(rw["CreatedDate"]),
                                             formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                             Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                         }).Distinct().ToList();

                    req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                    if (req.frequency != "" && req.frequency != null)
                    {

                        string[] freqlist = req.frequency.Split(',');
                        string indexes = "";
                        for (int j = 0; j < convertedList.Count(); j++)
                        {
                            int count = 0;

                            string frequencysub = convertedList[j].Frequency;
                            if (frequencysub == "")
                            {
                                indexes += j + ",";
                                // convertedList.RemoveAt(j);

                            }
                            else
                            {
                                frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                string[] freqlistsp = frequencysub.Split(',');
                                for (int k = 0; k < freqlistsp.Count(); k++)
                                {
                                    for (int i = 0; i < freqlist.Count(); i++)
                                    {
                                        if (freqlist[i] != freqlistsp[k])
                                        {
                                            count++;
                                        }
                                    }
                                }
                                int mutiple = freqlistsp.Count() * freqlist.Count();
                                if (mutiple == count)
                                {
                                    indexes += j + ",";
                                    //convertedList.RemoveAt(j);
                                }
                            }

                        }

                        indexes = indexes == "" ? null : indexes.TrimEnd(',');
                        if (indexes != null)
                        {
                            string[] indexeslist = indexes.Split(',');
                            //for (int i = 0; i < indexeslist.Count(); i++)
                            //{
                            //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                            //}

                            foreach (string indice in indexeslist.OrderByDescending(v => v))
                            {
                                convertedList.RemoveAt(Convert.ToInt32(indice));
                            }

                        }
                    }
                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = convertedList;

                    return responce;
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

        public Hd_Responce GetpmbygrpWoreshedulelist(allassetsreq req)
        {
            RaiseServiceDAL format = new RaiseServiceDAL();
            Hd_Responce responce = new Hd_Responce();
            try
            {
                req.Locations = req.Locations == null ? null : req.Locations.TrimEnd(',');
                req.Zone = req.Zone == null ? null : req.Zone.TrimEnd(',');
                req.Building = req.Building == null ? null : req.Building.TrimEnd(',');
                req.Floor = req.Floor == null ? null : req.Floor.TrimEnd(',');
                req.Businessunit = req.Businessunit == null ? null : req.Businessunit.TrimEnd(',');
                req.service = req.service == null ? null : req.service.TrimEnd(',');
                req.system = req.system == null ? null : req.system.TrimEnd(',');
                req.subsystem = req.subsystem == null ? null : req.subsystem.TrimEnd(',');
                req.Employeelist = req.Employeelist == null ? null : req.Employeelist.TrimEnd(',');


                var parameters = new SqlParamDefinition[]
                {
                  new SqlParamDefinition("@Fcase",  20),
                  new SqlParamDefinition("@location",  req.Locations),
                  new SqlParamDefinition("@CPID",  req.id),
                  new SqlParamDefinition("@Companyid",  req.Companyid),
                  new SqlParamDefinition("@zone",  req.Zone),
                  new SqlParamDefinition("@building",  req.Building),
                  new SqlParamDefinition("@Business",  req.Businessunit),
                  new SqlParamDefinition("@service1",  req.service),
                  new SqlParamDefinition("@Systemreq",  req.system),
                  new SqlParamDefinition("@Floorreq",   req.Floor),
                  new SqlParamDefinition("@Subsystemreq",  req.subsystem),
                  new SqlParamDefinition("@uniqueAssetId",  req.uniqueAssetId),
                  new SqlParamDefinition("@pageno",  req.Pageno),
                  new SqlParamDefinition("@pagesize",  req.pagesize),
                  new SqlParamDefinition("@fromdate",  req.fromdate),
                  new SqlParamDefinition("@todate",  req.todate),
                   };
                // SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    var convertedList = (from rw in dt.AsEnumerable()
                                         select new
                                         {
                                             Id = Convert.ToString(rw["id"]),
                                             pmplanId = Convert.ToString(rw["id"]),
                                             // ChildId = Convert.ToString(rw["childid"]),
                                             Assetcount = Convert.ToString(rw["Assetcount"]),
                                             Group = Convert.ToString(rw["Routename"]),
                                             //status = Convert.ToString(rw["Status"]),
                                             //remarks = Convert.ToString(rw["remarks"]),
                                             site = Convert.ToString(rw["sitename"]),
                                             zone = Convert.ToString(rw["zonename"]),
                                             building = Convert.ToString(rw["buildingname"]),
                                             floor = Convert.ToString(rw["floorname"]),
                                             room = Convert.ToString(rw["roomname"]),
                                             //startdate = Convert.ToString(rw["startdate"]),
                                             //enddate = Convert.ToString(rw["enddate"]),
                                             businessunit = Convert.ToString(rw["Description"]),
                                             service = Convert.ToString(rw["ServiceDescription"]),
                                             system = Convert.ToString(rw["System"]),
                                             //createddate = Convert.ToString(rw["CreatedDate"]),
                                             formatexpressiom = Convert.ToString(rw["formantname"]) + Convert.ToString(rw["date"]),
                                             Frequency = (rw["M"].Equals(DBNull.Value) ? "" : "Monthly,") + (rw["Q"].Equals(DBNull.Value) ? "" : "Quarterly,") + (rw["S"].Equals(DBNull.Value) ? "" : "SemiAnnually,") + (rw["A"].Equals(DBNull.Value) ? "" : "Annually,"),


                                         }).Distinct().ToList();

                    req.frequency = req.frequency == null ? null : req.frequency.TrimEnd(',');

                    if (req.frequency != "" && req.frequency != null)
                    {

                        string[] freqlist = req.frequency.Split(',');
                        string indexes = "";
                        for (int j = 0; j < convertedList.Count(); j++)
                        {
                            int count = 0;

                            string frequencysub = convertedList[j].Frequency;
                            if (frequencysub == "")
                            {
                                indexes += j + ",";
                                // convertedList.RemoveAt(j);

                            }
                            else
                            {
                                frequencysub = frequencysub == null ? null : frequencysub.TrimEnd(',');

                                string[] freqlistsp = frequencysub.Split(',');
                                for (int k = 0; k < freqlistsp.Count(); k++)
                                {
                                    for (int i = 0; i < freqlist.Count(); i++)
                                    {
                                        if (freqlist[i] != freqlistsp[k])
                                        {
                                            count++;
                                        }
                                    }
                                }
                                int mutiple = freqlistsp.Count() * freqlist.Count();
                                if (mutiple == count)
                                {
                                    indexes += j + ",";
                                    //convertedList.RemoveAt(j);
                                }
                            }

                        }

                        indexes = indexes == "" ? null : indexes.TrimEnd(',');
                        if (indexes != null)
                        {
                            string[] indexeslist = indexes.Split(',');
                            //for (int i = 0; i < indexeslist.Count(); i++)
                            //{
                            //    convertedList.RemoveAll(Convert.ToInt32( indexeslist[i]));

                            //}

                            foreach (string indice in indexeslist.OrderByDescending(v => v))
                            {
                                convertedList.RemoveAt(Convert.ToInt32(indice));
                            }

                        }
                    }
                    responce.Status = "200";
                    responce.Message = "Success";
                    responce.Result = convertedList;

                    return responce;
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

        public string CreatePmsysplan(int companyid)
        {
            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Companyid", companyid);
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

        private DataTable getassetdetailsbyid(int Id)
        {
            List<object> baseModel = new List<object>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        //cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return dt;

        }

        public string gettasklistcode(tasklistreq req)
        {
            List<object> baseModel = new List<object>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@tasktype", req.tasktype);
                        cmd.Parameters.AddWithValue("@frq", req.freq);
                        cmd.Parameters.AddWithValue("@Business", req.businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.sys);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsys);
                        //cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new
                                                 {
                                                     code = Convert.ToString(rw["TLCode"]),
                                                     hours = Convert.ToString(rw["Hours"]),
                                                 }).FirstOrDefault();

                            return convertedList.code;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return "";

        }

        public string gettasklisthours(tasklistreq req)
        {
            List<object> baseModel = new List<object>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@tasktype", req.tasktype);
                        cmd.Parameters.AddWithValue("@frq", req.freq);
                        cmd.Parameters.AddWithValue("@Business", req.businessunit);
                        cmd.Parameters.AddWithValue("@service1", req.service);
                        cmd.Parameters.AddWithValue("@Systemreq", req.sys);
                        cmd.Parameters.AddWithValue("@Subsystemreq", req.subsys);
                        //cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            var convertedList = (from rw in dt.AsEnumerable()
                                                 select new
                                                 {
                                                     code = Convert.ToString(rw["TLCode"]),
                                                     hours = Convert.ToString(rw["Hours"]),
                                                 }).FirstOrDefault();

                            return convertedList.hours;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return "";

        }

        public string CreatePmgroupplanchild(plan req, int companyid, int id, string fromdate, string todate, DateTime addeddate)
        {

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        //cmd.Parameters.AddWithValue("@Companyid", companyid);

                        cmd.Parameters.AddWithValue("@CPID", id);
                        cmd.Parameters.AddWithValue("@AssetRoute", req.AssetRouteID);
                        cmd.Parameters.AddWithValue("@AssetRouteDesc", req.AssetRouteDesc);
                        cmd.Parameters.AddWithValue("@LCID          ", req.LCID);
                        cmd.Parameters.AddWithValue("@ZN            ", req.ZN);
                        cmd.Parameters.AddWithValue("@BuildingID    ", req.BuildingID);
                        cmd.Parameters.AddWithValue("@FLRID         ", req.FLRID);
                        cmd.Parameters.AddWithValue("@RMID          ", req.RMID);
                        cmd.Parameters.AddWithValue("@LocationClass ", req.LocationClass);
                        cmd.Parameters.AddWithValue("@BUId          ", req.BUId);
                        cmd.Parameters.AddWithValue("@SERVICEId     ", req.SERVICEId);
                        cmd.Parameters.AddWithValue("@SYSID         ", req.SYSID);
                        cmd.Parameters.AddWithValue("@SUBSYSID      ", req.SUBSYSID);
                        cmd.Parameters.AddWithValue("@SYSINVNUM     ", req.SYSINVNUM);
                        cmd.Parameters.AddWithValue("@SUBSYSINVNUM  ", req.SUBSYSINVNUM);
                        cmd.Parameters.AddWithValue("@SYSDESC       ", req.SYSDESC);
                        cmd.Parameters.AddWithValue("@SUBSYSDESC    ", req.SUBSYSDESC);
                        cmd.Parameters.AddWithValue("@AssetType     ", req.AssetType);
                        cmd.Parameters.AddWithValue("@AssetClass    ", req.AssetClass);
                        cmd.Parameters.AddWithValue("@Sqty          ", req.Sqty);
                        cmd.Parameters.AddWithValue("@SSQty         ", req.SSQty);
                        cmd.Parameters.AddWithValue("@M             ", req.M);
                        cmd.Parameters.AddWithValue("@Q             ", req.Q);
                        cmd.Parameters.AddWithValue("@S             ", req.S);
                        cmd.Parameters.AddWithValue("@A             ", req.A);
                        cmd.Parameters.AddWithValue("@MH            ", req.MH);
                        cmd.Parameters.AddWithValue("@QH            ", req.QH);
                        cmd.Parameters.AddWithValue("@SH            ", req.SH);
                        cmd.Parameters.AddWithValue("@AH            ", req.AH);
                        cmd.Parameters.AddWithValue("@TLM_m         ", req.TLM_M);
                        cmd.Parameters.AddWithValue("@TLM_Q         ", req.TLM_Q);
                        cmd.Parameters.AddWithValue("@TLM_S         ", req.TLM_S);
                        cmd.Parameters.AddWithValue("@TLM_A         ", req.TLM_A);
                        cmd.Parameters.AddWithValue("@JAN           ", req.JAN);
                        cmd.Parameters.AddWithValue("@FEB           ", req.FEB);
                        cmd.Parameters.AddWithValue("@MAR           ", req.MAR);
                        cmd.Parameters.AddWithValue("@APR           ", req.APR);
                        cmd.Parameters.AddWithValue("@MAY           ", req.MAY);
                        cmd.Parameters.AddWithValue("@JUN           ", req.JUN);
                        cmd.Parameters.AddWithValue("@JUL           ", req.JUL);
                        cmd.Parameters.AddWithValue("@AUG           ", req.AUG);
                        cmd.Parameters.AddWithValue("@SEP           ", req.SEP);
                        cmd.Parameters.AddWithValue("@OCT           ", req.OCT);
                        cmd.Parameters.AddWithValue("@NOV           ", req.NOV);
                        cmd.Parameters.AddWithValue("@DEC           ", req.DEC);
                        cmd.Parameters.AddWithValue("@CntM          ", req.CntM);
                        cmd.Parameters.AddWithValue("@CntQ          ", req.CntQ);
                        cmd.Parameters.AddWithValue("@CntS          ", req.CntS);
                        cmd.Parameters.AddWithValue("@CntA          ", req.CntA);
                        cmd.Parameters.AddWithValue("@Total         ", req.Total);
                        cmd.Parameters.AddWithValue("@Companyid     ", companyid);
                        cmd.Parameters.AddWithValue("@Site          ", req.Site);
                        cmd.Parameters.AddWithValue("@Area          ", req.Area);
                        cmd.Parameters.AddWithValue("@AssertId      ", req.AssertId);
                        cmd.Parameters.AddWithValue("@AssetName     ", req.AssetName);
                        cmd.Parameters.AddWithValue("@fromdate     ", Convert.ToDateTime(fromdate));
                        cmd.Parameters.AddWithValue("@todate     ", Convert.ToDateTime(todate));
                        cmd.Parameters.AddWithValue("@createddate ", Convert.ToDateTime(addeddate));
                        cmd.Parameters.AddWithValue("@TLHours    ", req.Hours);

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

        public string Updateplanid(int id)
        {
            DateTime date = DateTime.Now;
            //"PMID/S/02-20/2"
            string format = "PMID/S/" + date.Month + "-" + date.Year + "/" + id;

            string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("Hd_Sp_Pmbygroup", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@name", format);
                        cmd.Parameters.AddWithValue("@Id", id);
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

        private string updateAssetcapitaltocreateplan(int Id)
        {
            var parameters = new SqlParamDefinition[]
               {
                  new SqlParamDefinition("@Fcase",  7),
                  new SqlParamDefinition("@Id",  Id)
               };
            DataSet ds = spexc.ExecuteSelectProcedure("[Hd_Sp_Pmbygroup]", parameters);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }


            return "";
        }

    }
    public class plan
    {
        public string Id { get; set; }
        public string CPID { get; set; }
        public string AssetRouteID { get; set; }
        public string AssetRouteDesc { get; set; }
        public string LCID { get; set; }
        public string ZN { get; set; }
        public string BuildingID { get; set; }
        public string FLRID { get; set; }
        public string RMID { get; set; }
        public string LocationClass { get; set; }
        public string BUId { get; set; }
        public string SERVICEId { get; set; }
        public string SYSID { get; set; }
        public string SUBSYSID { get; set; }
        public string SYSINVNUM { get; set; }
        public string SUBSYSINVNUM { get; set; }
        public string SYSDESC { get; set; }
        public string SUBSYSDESC { get; set; }
        public string AssetType { get; set; }
        public string AssetClass { get; set; }
        public string Sqty { get; set; }
        public string SSQty { get; set; }
        public string M { get; set; }
        public string Q { get; set; }
        public string S { get; set; }
        public string A { get; set; }
        public string MH { get; set; }
        public string QH { get; set; }
        public string SH { get; set; }
        public string AH { get; set; }
        public string TLM_M { get; set; }
        public string TLM_Q { get; set; }
        public string TLM_S { get; set; }
        public string TLM_A { get; set; }
        public string JAN { get; set; }
        public string FEB { get; set; }
        public string MAR { get; set; }
        public string APR { get; set; }
        public string MAY { get; set; }
        public string JUN { get; set; }
        public string JUL { get; set; }
        public string AUG { get; set; }
        public string SEP { get; set; }
        public string OCT { get; set; }
        public string NOV { get; set; }
        public string DEC { get; set; }
        public string Hours { get; set; }
        public int CntM { get; set; }
        public int CntQ { get; set; }
        public int CntS { get; set; }
        public int CntA { get; set; }
        public int Total { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string IsActive { get; set; }
        public string Site { get; set; }
        public string Area { get; set; }
        public string AssertId { get; set; }
        public string AssetName { get; set; }

    }

    public class tasklistreq
    {
        public string tasktype { get; set; }
        public string freq { get; set; }
        public string businessunit { get; set; }
        public string service { get; set; }
        public string sys { get; set; }
        public string subsys { get; set; }
    }





}