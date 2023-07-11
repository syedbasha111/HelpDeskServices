using System;
namespace HelpDeskServices.DataModels.Transactions
{
    public class RequestForm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FormName { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime MOdifiedOn { get; set; }

    }
}