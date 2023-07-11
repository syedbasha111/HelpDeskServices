using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class AssertLabelModel
    {
        public int Id { get; set; }
        public int AssertId { get; set; }
        public string Asserts { get; set; }
        public bool IsChecked { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }



    }
}