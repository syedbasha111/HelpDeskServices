using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MaintananceBusinessModule
    {
        MaintananceBusinessDAL MasterDAL = new MaintananceBusinessDAL();



        public List<BusinessObject> GetBussinessUnit(int companyId)
        {
            return MasterDAL.GetBussinessUnit(companyId);
        }

        public string insertBusinessUnit(BussinessParametersObj bunit)
        {
            return MasterDAL.insertBusinessUnit(bunit);
        }

        public string updateBusinessUnit(BussinessParametersObj businessObj)
        {
            return MasterDAL.updateBusinessUnit(businessObj);
        }

        public BusinessObject GetBussinessUnitById(int BusinessId)
        {
            return MasterDAL.GetBussinessUnitById(BusinessId);
        }

        public string DeleteBussinessUnit(int BusinessId, int CompanyId)
        {
            return MasterDAL.DeleteBussinessUnit(BusinessId, CompanyId);
        }
    }


}