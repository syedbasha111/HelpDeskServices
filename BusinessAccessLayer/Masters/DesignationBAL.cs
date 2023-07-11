using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class DesignationBAL
    {
        DesignationDAL DAL = new DesignationDAL();
        public HD_BaseModel DesignationMaster(DesignationModel request)
        {
            return DAL.DesignationMaster(request);
        }

        public HD_BaseModel UpdateDesignationMaster(DesignationModel request)
        {
            return DAL.UpdateDesignationMaster(request);
        }

        public List<DesignationModel> GetDesignation(int companyId)
        {
            return DAL.GetDesignation(companyId);

        }
        public string deletedesignation(DeleteObj request)
        {
            return DAL.deletedesignation(request);
        }


    }
}