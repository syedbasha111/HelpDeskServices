﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class AddassetStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}