using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.Transactions
{
    public class Workorder
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string RefWOId { get; set; }
        public string RequesterName { get; set; }
        public string name { get; set; }
        public string WorKorderStatus { get; set; }
        public string RequestReceivedby { get; set; }
        public DateTime ReceivedDateTime { get; set; }
        public DateTime ReportingDateTime { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
        public int RequestForm { get; set; }
        public int Site { get; set; }
        public int Zone { get; set; }
        public string ZoneName { get; set; }
        public string Expression { get; set; }
        public string ServiceIdFormat { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public string FloorName { get; set; }
        public int Area { get; set; }
        public string AreaName { get; set; }
        public string AssignTo { get; set; }
        public int Room { get; set; }
        public string RoomName { get; set; }
        public int BussinessUnit { get; set; }
        public int Service { get; set; }
        public int SubService { get; set; }
        public int Problem { get; set; }
        public int System { get; set; }
        public int SubSystem { get; set; }
        public int Locationpriority { get; set; }
        public int ServicePriority { get; set; }
        public string Remarks { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public string SLA { get; set; }
        public string UniqueAssetId { get; set; }
        public string Assignto { get; set; }
        public string AssignId { get; set; }
        public string AssignCOde { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int Modifiedby { get; set; }

        public string Sitename { get; set; }
        public string LocationName { get; set; }
        public string Problemdesc { get; set; }
        public string Systemaname { get; set; }
        public string SubSystemName { get; set; }
        public int Status { get; set; }
        public string RejectRemarks { get; set; }
        public string Businessname { get; set; }
        public string servicename { get; set; }
        public string RequestfromName { get; set; }
        public string Subservicename { get; set; }
        public string ServiceReqId { get; set; }
        public string CloseStatus { get; set; }
        public string ApproveStatus { get; set; }
        public string ApprvRemarks { get; set; }
        public bool Isdownload { get; set; }


    }
    public class listofimages
    {
        public List<imageslist> Raiseimageslist { get; set; }
        public List<WoImages> Woimageslist { get; set; }
    }
    public class WoImages
    {
        public string ImagesPath { get; set; }
        public string Type { get; set; }
    }

}