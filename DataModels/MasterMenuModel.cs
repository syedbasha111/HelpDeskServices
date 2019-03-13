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
        public string ActionType { get; set; }
    }


    public class ServiceObject
    {
        public int ServiceID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessName { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
    }

    public class SubServiceObject
    {
        public int SubServiceID { get; set; }
        public string SubServiceCode { get; set; }
        public string SubServiceDescription { get; set; }
        public int ServiceID { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessName { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int IsActive { get; set; }
        public string serviceCode { get; set; }
        public string BusinessCode { get; set; }
    }

    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessName { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int IsActive { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
    }

    public class SubService
    {

        public int SubServiceID { get; set; }
        public string SubServiceCode { get; set; }
        public string SubServiceDescription { get; set; }
        public int ServiceID { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessName { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int IsActive { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
    }

    public class Problem
    {
        public int ProblemId { set; get; }
        public int SubServiceId { set; get; }
        public string SubServiceCode { set; get; }
        public int ServiceId { set; get; }
        public string ServiceCode { set; get; }
        public int BusinessUnitId { set; get; }
        public string BusinessUnitCode { set; get; }
        public string ProblemCode { set; get; }
        public string ProblemDescription { set; get; }
        public string Remark { set; get; }
        public int CompanyId { set; get; }
        public string CompanyName { get; set; }
        public int CreatedBy { set; get; }
        public int UpdatedBy { set; get; }
        public int IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string UpdateOn { get; set; }
    }


    //AssetLocation
    public class AssetLocation
    {
        public int AssetLocationId { get; set; }
        public string AssetLocationCode { get; set; }
        public string AssetLocationName { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string Remark { get; set; }
        public string CompanyName { get; set; }
    }

    public class CountriesModel
    {
        public int CountryId { get; set; }
        public string CmpCode { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string Status { get; set; }
        public int Active { get; set; }
    }

    public class CitiesModel
    {
        public int CitiesId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Status { get; set; }
        public int Active { get; set; }
    }

    public class CompaniesModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class ServiceEscalationModel
    {
        public int ServiceEscalationId { get; set; }
        public string CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int SubServiceID { get; set; }
        public string SubServiceName { get; set; }
        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public int CompanyId { set; get; }
        public string CompanyName { get; set; }
        public int CreatedBy { set; get; }
        public int UpdatedBy { set; get; }
        public int IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string UpdateOn { get; set; }
    }

    public class SlaTimeDefinationModel
    {
        public int SlaTimeDefinationId { get; set; }
        public string CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int SubServiceID { get; set; }
        public string SubServiceName { get; set; }
        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public int CompanyId { set; get; }
        public string CompanyName { get; set; }
        public int CreatedBy { set; get; }
        public int UpdatedBy { set; get; }
        public int IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string UpdateOn { get; set; }
    }

    public class RepeatCallMasterModel
    {
        public int RepeatCallMasterId { get; set; }
        public string RepeatCallCode { get; set; }
        public string RepeatCallName { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }

    public class ImpactCallMasterModel
    {
        public int ImpactCallMasterId { get; set; }
        public string ImpactCallCode { get; set; }
        public string ImpactCallName { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }


    public class UrgencyCallMasterModel
    {
        public int UrgencyCallMasterId { get; set; }
        public string UrgencyCallCode { get; set; }
        public string UrgencyCallName { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }

    public class FeedbackCallMasterModel
    {
        public int FeedbackCallMasterId { get; set; }
        public string FeedbackCallCode { get; set; }
        public string FeedbackCallName { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }

    public class FacilityCallMasterModel
    {
        public int FacilityCallMasterId { get; set; }
        public string FacilityCallCode { get; set; }
        public string FacilityCallName { get; set; }
        public string FacilityCost { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }

    public class HolidayCallMasterModel
    {
        public int HolidayCallMasterId { get; set; }
        public string HolidayCallName { get; set; }
        public string HolidayDate { get; set; }
        public string Remark { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanyId { get; set; }
    }





}