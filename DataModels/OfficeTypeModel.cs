using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class OfficeTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        

    }
}