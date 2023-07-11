using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class HD_BaseModel
    {
        public string status { get; set; }
        public string Names { get; set; }
        public int Id { get; set; }
        public string ServiceId { get; set; }
        public string WoIdExp { get; set; }

    }
}