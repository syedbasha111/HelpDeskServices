using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class AddCapitalAssetBAL
    {
        AddCapitalAssetDAL DAL = new AddCapitalAssetDAL();

        public string SaveAddCapitalAsset(AddCapitalAsset request)
        {
            return DAL.SaveAddCapitalAsset(request);
        }

        public string UpdateAddCapitalAsset(AddCapitalAsset request)
        {
            return DAL.UpdateAddCapitalAsset(request);
        }

        public List<AddCapitalAsset> GetCapitalAsset(int Id,int CompanyId)
        {
            return DAL.GetCapitalAsset(Id, CompanyId);
        }

        public string SaveAssetImage(AddCapitalAsset request)
        {
            return DAL.SaveAssetImage(request);
        }

        public string SaveAssetDocument(AddCapitalAsset request)
        {
            return DAL.SaveAssetDocument(request);
        }
        public string SaveInsuranceDocument(AddCapitalAsset request)
        {
            return DAL.SaveInsuranceDocument(request);
        }

        public List<Vendor> GetVendordata(int CompanyId)
        {
            return DAL.GetVendordata(CompanyId);
        }
        public List<Department> GetDepartmentdata(int CompanyId)
        {
            return DAL.GetDepartmentdata(CompanyId);
        }
        public List<AddassetStatus> GetStatus(int CompanyId)
        {
            return DAL.GetStatus(CompanyId);

        }
        public List<AssetFormodel> GetAssetfordata(int CompanyId)
        {
            return DAL.GetAssetfordata(CompanyId);
        }
        public List<PriorityModel> GetPrioritydata(int CompanyId)
        {
            return DAL.GetPrioritydata(CompanyId);
        }
        public List<AssetPrioritymodel> GetAssetPrioritydata(int CompanyId)
        {
            return DAL.GetAssetPrioritydata(CompanyId);
        }

        public List<Locationclass> GetLocationclass(int CompanyId)
        {
            return DAL.GetLocationclass(CompanyId);
        }

        public List<Locationclass> GetAssetClass(int CompanyId)
        {
            return DAL.GetAssetClass(CompanyId);
        }
    }
}