using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class SystemName
    {
        public int Id { get; set; }
        public string System { get; set; }
        public int CompayId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime MOdifiedOn { get; set; }
    }
}