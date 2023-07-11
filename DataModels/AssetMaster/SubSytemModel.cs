using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class SubSytem
    {
        public int Id { get; set; }
        public string SubSystem { get; set; }
        public string SubSystemCode { get; set; }
        public string SystemName { get; set; }
        public string BusinessUnitName { get; set; }
        public string ServiceName { get; set; }
        public int BusinessUnit { get; set; }
        public int Service { get; set; }
        public int System { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public string Isdeleted { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}