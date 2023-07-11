using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ServiceEscalationBAL
    {
        ServiceEscalationDAL DAL = new ServiceEscalationDAL();

        public string InsertServiceEscalationById(ServiceEscalationModel escalationmodel)
        {
            return DAL.insertServiceEscaltion(escalationmodel);

        }
        public string SaveusersCheckList(List<ServiceEscalationSubItems> request)
        {
            return DAL.SaveusersCheckList(request);

        }

        public string UpdateServiceEscalationById(ServiceEscalationModel escalationmodel)
        {
            return DAL.UpdateServiceEscaltion(escalationmodel);

        }
        public List<ServiceEscalationModel> GetServiceEscalationById(int companyId)
        {
            return DAL.GetServiceEscalation(companyId);
        }

        public string DeleteServiceEscalationById(int recordId)
        {

            return DAL.DeleteServiceEscalation(recordId);
        }
        public RoleTreeView role(int CompanyId)
        {
            return DAL.role(CompanyId);
        }
    }
}