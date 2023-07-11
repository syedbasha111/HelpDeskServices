using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{
    public class SrAssignmaster
    {
        public int Id { get; set; }
        public int Site { get; set; }
        public int EmployeeId { get; set; }
        public int companyId { get; set; }
        public int CreatedBy { get; set; }
        public List<Servicedata> ServiceList { get; set; }
    }
    public class Servicedata {
        public int ServiceID { get; set; }
    }
}