using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class Hd_Responce
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public string type { get; set; }
        public object Result { get; set; }

    }
}