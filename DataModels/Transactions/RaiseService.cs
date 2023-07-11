using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class RaiseService
    {
        public int Id { get; set; }
        public string RequesterName { get; set; }
        public string RequestReceivedby { get; set; }
        public DateTime ReceivedDateTime { get; set; }
        public DateTime ReportingDateTime { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
        public int RequestForm { get; set; }
        public string RequestFormName { get; set; }
        public int Site { get; set; }
        public int Zone { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public int Area { get; set; }
        public int Room { get; set; }
        public int BussinessUnit { get; set; }
        public int Service { get; set; }
        public int SubService { get; set; }
        public int Problem { get; set; }
        public string Problemdesc { get; set; }
        public int System { get; set; }
        public string SystemName { get; set; }
        public int SubSystem { get; set; }
        public string SubSystemName { get; set; }
        public int Locationpriority { get; set; }
        public int ServicePriority { get; set; }
        public string Remarks { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public string Expression { get; set; }
        public string SLA { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int Modifiedby { get; set; }
        public string RefWOId { get; set; }
        public string AssignTo { get; set; }
        public int Status { get; set; }
        public string Status1 { get; set; }
        public string Sitename { get; set; }
        public string Businessname { get; set; }
        public string servicename { get; set; }
        public string Subservicename { get; set; }
        public string UniqueAssetId { get; set; }
        public bool WorkOrderStatus { get; set; }
        public List<NewUser> EmployeeList { get; set; }
        public List<imageslist> Images { get; set; }


    }
    public class imageslist
    {
        public string ImagesPath { get; set; }
        public string Type { get; set; }


    }

    

}