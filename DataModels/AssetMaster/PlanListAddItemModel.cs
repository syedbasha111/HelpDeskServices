using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class PlanListAddItemModel
    {
        public int Id { get; set; }
        public int Toyear { get; set; }
        public int PlanId { get; set; }
        public string UniqueAssetid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Isdelete{ get; set; }
        public string IsActive { get; set; }
    }
}