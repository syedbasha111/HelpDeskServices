using HelpDeskServices.Controllers.Reports;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace HelpDeskServices.DataAccessLayer.Reports
{
    public class MultidropdownDAL
    {
        string ConString = ConfigurationManager.AppSettings["connectionString"].ToString();

        public List<ZoneModel> GetZoneNameBySiteid(int companyId, string Location)
        {
            List<ZoneModel> baseModel = new List<ZoneModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = Location.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 1);
                        cmd.Parameters.AddWithValue("@location", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ZoneModel data = new ZoneModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.ZoneCode = dr["ZoneCode"].ToString();
                                data.ZoneName = dr["ZoneName"].ToString();
                                data.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                data.Remarks = dr["Remarks"].ToString();
                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }


        public List<BuildingModel> GetbuildingList(int companyId, string zone)
        {
            List<BuildingModel> baseModel = new List<BuildingModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = zone.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 2);
                        cmd.Parameters.AddWithValue("@zone", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                BuildingModel data = new BuildingModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.BuildingCode = dr["BuildingCode"].ToString();
                                data.BuildingName = dr["BuildingName"].ToString();
                                data.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                data.Remarks = dr["Remarks"].ToString();

                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }


        public List<FloorMasterModel> GetfloorList(int companyId, string building)
        {
            List<FloorMasterModel> baseModel = new List<FloorMasterModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = building.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 3);
                        cmd.Parameters.AddWithValue("@building", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                FloorMasterModel data = new FloorMasterModel();

                                data.ID = int.Parse(dr["ID"].ToString());
                                data.FloorCode = dr["FloorCode"].ToString();
                                data.FloorName = dr["FloorName"].ToString();
                                data.IsActive = Convert.ToBoolean(dr["IsActive"]);
                                data.Remarks = dr["Remarks"].ToString();

                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }

        public List<Service> GetServiceList(int companyId, string businessunit)
        {
            List<Service> baseModel = new List<Service>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = businessunit.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 4);
                        cmd.Parameters.AddWithValue("@Business", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                Service data = new Service();

                                data.ServiceCode = dr["ServiceCode"].ToString();
                                data.ServiceDescription = dr["ServiceDescription"].ToString();
                                data.ServiceID = int.Parse(dr["ID"].ToString());


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }


        public List<SystemMaster> GetSystemList(int companyId, string service)
        {
            List<SystemMaster> baseModel = new List<SystemMaster>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = service.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 5);
                        cmd.Parameters.AddWithValue("@service1", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SystemMaster data = new SystemMaster();

                                data.Id = Convert.ToInt32(dr["Id"].ToString());
                                data.System = dr["System"].ToString();
                                data.SystemCode = dr["SystemCode"].ToString();


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }


        public List<SubSytem> GetSubSystemList(int companyId, string system)
        {
            List<SubSytem> baseModel = new List<SubSytem>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 6);
                        cmd.Parameters.AddWithValue("@Systemreq", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
                        cmd.CommandType = CommandType.StoredProcedure;



                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                SubSytem data = new SubSytem();

                                data.Id = Convert.ToInt32(dr["Id"].ToString());
                                data.SubSystem = dr["SubSystem"].ToString();
                                data.SubSystemCode = dr["SubSystemCode"].ToString();


                                baseModel.Add(data);
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }

        public IEnumerable<object> GetareaList(int companyId, string floor)
        {
            List<object> baseModel = new List<object>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = floor.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 10);
                        cmd.Parameters.AddWithValue("@Floorreq", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
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
                                                     ID = Convert.ToString(rw["ID"]),
                                                     Area = Convert.ToString(rw["AreaCode"]) + " " + Convert.ToString(rw["AreaName"]),
                                                 }).ToList().Distinct();

                            return convertedList;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }


        public IEnumerable<object> GetRoomList(int companyId, string area)
        {
            List<object> baseModel = new List<object>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    var a = area.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                        // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 11);
                        cmd.Parameters.AddWithValue("@area", a);
                        cmd.Parameters.AddWithValue("@Companyid", companyId);
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
                                                     ID = Convert.ToString(rw["ID"]),
                                                     Room = Convert.ToString(rw["RoomCode"]) + " " + Convert.ToString(rw["RoomName"]),
                                                 }).ToList().Distinct();

                            return convertedList;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }



        //get all assets details

        public IEnumerable<allassetsresponce> Getallassetdetails(allassetsreq req)
        {
            List<allassetsresponce> baseModel = new List<allassetsresponce>();

            try
            {
                req.Locations =  req.Locations==null ? null: req.Locations.TrimEnd(',');
                req.Zone =  req.Zone==null ? null: req.Zone.TrimEnd(',');
                req.Building =  req.Building == null ? null: req.Building.TrimEnd(',');
                req.Floor =  req.Floor == null ? null: req.Floor.TrimEnd(',');
                req.Businessunit =  req.Businessunit == null ? null: req.Businessunit.TrimEnd(',');
                req.service =  req.service == null ? null: req.service.TrimEnd(',');
                req.system =  req.system == null ? null: req.system.TrimEnd(',');
                req.subsystem =  req.subsystem == null ? null: req.subsystem.TrimEnd(',');

                using (SqlConnection conn = new SqlConnection(ConString))
                {

                   
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    //var a = system.TrimEnd(',');
                    using (SqlCommand cmd = new SqlCommand("Hd_sp_Multidropdowns", conn))
                    {
                       // SqlDataAdapter da = new SqlDataAdapter();
                        cmd.Parameters.AddWithValue("@Fcase", 7);
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

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
                        }
                        //conn.Open();
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //conn.Close();

                        //da.SelectCommand = cmd;
                        //da.Fill(dt);
                        //da.Fill(ds);
                        //ExportDataSetToExcel(dt);



                        if (dt.Rows.Count > 0)
                        {

                            IEnumerable<allassetsresponce> convertedList = (from rw in dt.AsEnumerable()
                                                 select new allassetsresponce()
                                                 {
                            Id = rw["id"].ToString(),
                            AsserRoute = rw["AssertId"].ToString(),
                            Assetname = rw["AssertId"].ToString(),
                            Assetdesc = rw["AssetName"].ToString(),
                            Sitecode = rw["sitecode"].ToString(),
                            Site = rw["sitename"].ToString(),
                            ZoneCode = rw["ZoneCode"].ToString(),
                            Zone = rw["ZoneName"].ToString(),
                            BusinessCode = rw["buisnesscode"].ToString(),
                            Businessunit = rw["businessname"].ToString(),
                            FloorCode = rw["FloorCode"].ToString(),
                            Floor = rw["FloorName"].ToString(),
                            ServiceCode = rw["ServiceCode"].ToString(),
                            Service = rw["ServiceDescription"].ToString(),
                            Systemcode = rw["SystemCode"].ToString(),
                            systemdesc = rw["System"].ToString(),
                            subSystemcode = rw["SubSystemCode"].ToString(),
                            subsystemdesc = rw["SubSystem"].ToString(),
                            systemquantity = rw["SystemQty"].ToString(),
                            subsystemquantity = rw["SubSystemQty"].ToString(),
                            Totalrecords = rw["TotalCount"].ToString(),
                                                 }).ToList().Distinct();

                            return convertedList;

                    }

                }
            }

            }
            catch (Exception ex)
            {

            }

            return baseModel;

        }

       private void ExportDataSetToExcel(DataTable table)
{
    //Creae an Excel application instance
    Excel.Application excelApp = new Excel.Application();

    //Create an Excel workbook instance and open it from the predefined location
    Excel.Workbook excelWorkBook = null;


    //Add a new worksheet to workbook with the Datatable name
    Excel.Worksheet excelWorkSheet = null;

    excelApp.Visible = true;

    excelWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


    // excelWorkSheet.Name = "All Assets";


    excelWorkSheet = excelWorkBook.Worksheets[1];


    for (int i = 1; i < table.Columns.Count + 1; i++)
    {
        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
    }

    for (int j = 0; j < table.Rows.Count; j++)
    {
        for (int k = 0; k < table.Columns.Count; k++)
        {
            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
        }
    }

    //for (int r = 1; r < 101; r++) //r stands for ExcelRow and c for ExcelColumn
    //{
    //    // Excel row and column start positions for writing Row=1 and Col=1
    //    for (int c = 1; c < 11; c++)
    //        excelWorkSheet.Cells[r, c] = "R" + r + "C" + c;
    //}


    // excelWorkBook.Save();
    excelWorkBook.Worksheets[1].Name = "MySheet";
    excelWorkBook.SaveAs("d:\\Testing.xlsx");
    excelWorkBook.Save();
    excelWorkBook.Close();
    excelApp.Quit();

    Marshal.ReleaseComObject(excelWorkSheet);
    Marshal.ReleaseComObject(excelWorkBook);
    Marshal.ReleaseComObject(excelApp);
}

       

        
    }
}