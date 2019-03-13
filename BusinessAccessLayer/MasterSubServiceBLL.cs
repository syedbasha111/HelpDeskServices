using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MasterSubServiceBLL
    {
        MasterSubServiceDAL MasterDAL = new MasterSubServiceDAL();

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

        public string DeleteSubService(int SubServiceId)
        {
            return MasterDAL.DeleteSubService(SubServiceId);
        }
    }
}