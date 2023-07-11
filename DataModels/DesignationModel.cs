using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class DesignationModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; }
        public int CompanyId { get; set; }
    }
}