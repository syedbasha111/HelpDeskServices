using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class SystemMaster
    {

        public int Id { get; set; }
        public string SystemCode { get; set; }
        public string System { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnit { get; set; }
        public string BusinessUnitname { get; set; }
        public int Service { get; set; }
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}