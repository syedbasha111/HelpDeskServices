using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Resources
    {
        public int Id { get; set; }
        public string resourceId { get; set; }
        public string TimeTaken { get; set; }
        public int WorkOrderId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Service { get; set; }
        public string ServiceDescription { get; set; }
        public string TotalTime { get; set; }
        public string Remarks { get; set; }
        public bool Visible { get; set; }
        public bool IsDone { get; set; }
        public int Companyid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public class ToolsSpresConsumables
        {
            public int Id { get; set; }
            public int WorkOrderId { get; set; }
            public string ItemId { get; set; }
            public string code { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string InventoryType { get; set; }
            public decimal ReqQuantity { get; set; }
            public decimal TotalQuantity { get; set; }
            public decimal ConsumeQty { get; set; }
            public string Service { get; set; }
            public string ServiceDescription { get; set; }
            public int CompanyId { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public int ModifiedBy { get; set; }
            public bool IsDone { get; set; }
            public string Remarks { get; set; }
            public DateTime ModifiedOn { get; set; }

        }

        public class Selectedassets
        {
            public int WoId { get; set; }
            public int childid { get; set; }
            public int slotid { get; set; }
            public string startdate { get; set; }
            public string enddate { get; set; }
            public bool bypassstatus { get; set; }

            public int status { get; set; }
            public string executstartdate { get; set; }
            public string executendadate { get; set; }
            public string remarks { get; set; }
            public int signature1 { get; set; }
            public int signature2 { get; set; }
            public int signature3 { get; set; }


        }
        public class listofresourcesandspares
        {
            public int WOId { get; set; }
            public int reqid { get; set; }
            public int CompanyId { get; set; }
            public int Createdby { get; set; }
            
            public List<Resources> ResourcesList { get; set; }
            public List<ToolsSpresConsumables> ToolsList { get; set; }
            public List<ToolsSpresConsumables> SparesList { get; set; }
            public List<ToolsSpresConsumables> ConsumabelsList { get; set; }
            public List<Selectedassets> slectedassetslist { get; set; }

        }
    }
}