using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class TaskListAddItemModel
    {
        public int Id { get; set; }
        public string TaskHead { get; set; }
        public string TaskDesc { get; set; }
        public string SubTaskId { get; set; }
        public string Subtaskname { get; set; }
        public int TaskListId { get; set; }
        public int CompanyId { get; set; }
        public int Insestdata { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Isdeleted { get; set; }




    }
}