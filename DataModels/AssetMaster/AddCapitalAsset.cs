using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.DataModels.AssetMaster
{
    public class AddCapitalAsset
    {

        public int Id { get; set; }
        public int BuisnessUnit { get; set; }
        public int Service { get; set; }
        public int System { get; set; }
        public int SubSystem { get; set; }
        public int Site { get; set; }
        public int Zone { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public int Area { get; set; }
        public int Room { get; set; }
        public int LocationId { get; set; }
        public string AssertId { get; set; }
        public string AssetName { get; set; }
        public string RateContract { get; set; }
        public string Frequency { get; set; }

        public string LocationClass { get; set; }
        public string AssestClass { get; set; }

        public int vendor { get; set; }
        public decimal AssetPrice { get; set; }
        public string AssetSerialNo { get; set; }
        public string LifeSpan { get; set; }
        public string PONumber { get; set; }
        public DateTime WarrntydateUpto { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime Mfgdate { get; set; }
        public decimal AnnualDepreciation { get; set; }
        public int Department { get; set; }
        public int status { get; set; }
        public string statusmsg { get; set; }
        public int AssetFor { get; set; }
        public int Priority { get; set; }
        public DateTime AssetInstallatiodate { get; set; }
        public DateTime AssetCommissioningdate { get; set; }
        public string AssetCostValue { get; set; }
        public string AssetScrapValue { get; set; }
        public string UploadAssetImage { get; set; }
        public string AMCIncluded { get; set; }
        public DateTime AmcDateUpto { get; set; }
        public string UploadAssetDocument { get; set; }
        public string InsuranceIncluded { get; set; }
        public DateTime InsuranceDate { get; set; }
        public string UploadInsuranceDocument { get; set; }
        public string Count { get; set; }
        public int AssetPriority { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public int SystemQty { get; set; }
        public int SubSystemQty { get; set; }
        public string uniqueassertref { get; set; }


    }
}