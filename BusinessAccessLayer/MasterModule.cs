using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class MasterModule
    {
        MasterModeulDAL MasterDAL = new MasterModeulDAL();

        public List<menuObject> GetSideNavigation(string UserType, string CompanyCode)
        {
            List<menuObject> menumaster = MasterDAL.GetSideNavigation(UserType, CompanyCode);
            return menumaster;
        }

        public List<BusinessObject> GetBussinessUnit()
        {
           return MasterDAL.GetBussinessUnit();
        }

        public string insertBusinessUnit(BussinessParametersObj bunit)
        {
           return MasterDAL.insertBusinessUnit(bunit);
        }

        public string updateBusinessUnit(BussinessParametersObj businessObj)
        {
           return MasterDAL.updateBusinessUnit(businessObj);
        }

        public BusinessObject GetBussinessUnitById( int BusinessId)
        {
           return  MasterDAL.GetBussinessUnitById(BusinessId);
        }

        public string DeleteBussinessUnit(int BusinessId)
        {
            return MasterDAL.DeleteBussinessUnit(BusinessId);
        }
    }


    }