using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels
{


    public class Child
    {
        public string id { get; set; }
        public string title { get; set; }
        public string translate { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public List<Child> children { get; set; }
    }

    public class ParentChild
    {
        public string id { get; set; }
        public string title { get; set; }
        public string translate { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public List<Child> children { get; set; }
    }

    public class menuObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public List<ParentChild> children { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
    }
    
   public class BusinessObject
    {
       public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; } 
        public int IsActive { get; set; }
    }

    public class BussinessParametersObj
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public int CompanyId { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
        public int IsActive { get; set; }
        public int BusinessId { get; set; }
    }
}