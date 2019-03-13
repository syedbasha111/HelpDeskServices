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
        public string InsertServiceEscalationById(ServiceEscalationModel escalationmodel)
        {
            ServiceEscalationDAL servicedalMethod = new ServiceEscalationDAL();
            return servicedalMethod.insertServiceEscaltion(escalationmodel);

        }

        public string UpdateServiceEscalationById(ServiceEscalationModel escalationmodel)
        {
            ServiceEscalationDAL servicedalMethod = new ServiceEscalationDAL();
            return servicedalMethod.UpdateServiceEscaltion(escalationmodel);

        }
        public List<ServiceEscalationModel> GetServiceEscalationById(int companyId)
        {
            ServiceEscalationDAL servicedalMethod = new ServiceEscalationDAL();
            return servicedalMethod.GetServiceEscalation(companyId);

        }

        public string DeleteServiceEscalationById(int recordId)
        {

            ServiceEscalationDAL servicedalMethod = new ServiceEscalationDAL();
            return servicedalMethod.DeleteServiceEscalation(recordId);
        }
    }
}