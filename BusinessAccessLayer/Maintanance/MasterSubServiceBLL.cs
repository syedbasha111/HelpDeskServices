using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MaintananceSubServiceBLL
    {
        MaintainanceSubServiceDAL MasterDAL = new MaintainanceSubServiceDAL();

        public List<SubServiceObject> Getsubservicebyserviceid(int campanyId,int Id)
        {

            return MasterDAL.Getsubservicebyserviceid(campanyId,Id);
        }

        public List<SubServiceObject> GetSubServiceUnit(int campanyId)
        {

            return MasterDAL.GetSubServiceUnit(campanyId);
        }

        public string InsertSubService(SubService SubServiceObj)
        {
            return MasterDAL.InsertSubService(SubServiceObj);
        }

        public string updateSubService(SubService SubServiceObj)
        {
            return MasterDAL.updateSubService(SubServiceObj);
        }

        public SubServiceObject GetSubServiceById(int SubServiceId)
        {
            return MasterDAL.GetSubServiceById(SubServiceId);
        }

        public string DeleteSubService(int SubServiceId,int CompanyId)
        {
            return MasterDAL.DeleteSubService(SubServiceId, CompanyId);
        }

        public List<ServiceByBusinessUnit> GetServiceByBusinessUnit(int bunit,int CompanyId)
        {
            return MasterDAL.GetServiceByBusinessUnit(bunit, CompanyId);
        }

        public SiteMasterDropdownlist GetdetailsbysubserviceId(int companyId, int Id)
        {
            return MasterDAL.GetdetailsbysubserviceId(companyId, Id);

        }
    }
}