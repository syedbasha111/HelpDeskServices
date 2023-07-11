using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class NewUser
    {

        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string EmpId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int Country { get; set; }
        public string TimeZone { get; set; }
        public int City { get; set; }
        public int Location { get; set; }
        public string Address { get; set; }
        public string MobileNO { get; set; }
        public int Grade { get; set; }
        public int CompanyId { get; set; }
        public int Department { get; set; }
        public int Designation { get; set; }
        public int ReportingManager { get; set; }
        public int Vertical { get; set; }
        public int CostCenter { get; set; }
        public string Password { get; set; }
        public decimal ChargePerHour { get; set; }
        public decimal OTChargeperHour { get; set; }
        public decimal HolidatOTperHr { get; set; }
        public int EmployeeType { get; set; }
        public int Shift { get; set; }
        public int Skills { get; set; }
        public int ServiceMapping { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int Isdeleted { get; set; }

    }

    public class Grade
    {
        public int Id { get; set; }
        public string gradedetail { get; set; }
        public int CompanyId { get; set; }
    }
    public class ReportingManager
    {
        public int Id { get; set; }
        public string ReportingManagerName { get; set; }
        public int CompanyId { get; set; }
        public int EmpId { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedON { get; set; }
        public string ModifiedOn { get; set; }
        public DateTime ModifiedBy { get; set; }

    }
    public class Vertical
    {
        public int Id { get; set; }
        public string Vertiacal { get; set; }
        public int CompanyId { get; set; }
    }
    public class CostCenter
    {
        public int Id { get; set; }
        public string CostCenterdetails { get; set; }
        public string CompanyId { get; set; }
    }
    public class Skills
    {
        public int Id { get; set; }
        public string Skillsdetails { get; set; }
        public int CompanyId { get; set; }

    }
}