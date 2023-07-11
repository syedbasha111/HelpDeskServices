using System;

namespace HelpDeskServices.DataModels.Transactions
{
    public class WOHistory
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int WOId { get; set; }
        public string RequesterName { get; set; }
        public string RequestReceivedby { get; set; }
        public int RequestForm { get; set; }
        public string UniqueAssetId { get; set; }
        public string UserName { get; set; }
        public string WorKorderStatus { get; set; }
        public string RequestfromName { get; set; }
        public string AssignTo { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string WoIdFormat{ get; set; }
        public string ServiceIdFormat { get; set; }


    }
}