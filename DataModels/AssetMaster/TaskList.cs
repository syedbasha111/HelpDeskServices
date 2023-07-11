using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class TaskListMaster
    {
        public int Id { get; set; }
        public string TLCode { get; set; }
        public string TLName { get; set; }
        public int TaskType { get; set; }
        public int Frequency { get; set; }
        public string Hours { get; set; }
        public int BusinessUnit { get; set; }
        public int Service { get; set; }
        public int System { get; set; }
        public int SubSystem { get; set; }
        public string TLDescription { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string SystemName   {get;set;}
        public string  BusinessUnitName {get;set;}
        public string  ServiceName  {get;set;}
        public string Isdeleted { get; set; }

    }
}