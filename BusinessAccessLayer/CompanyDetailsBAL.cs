using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class CompanyDetailsBAL
    {
        public List<CompaniesModel> GetCompanyByID(int companyId)
        {
            CompanyListDAL companydal = new CompanyListDAL();
            return companydal.GetCompanyById(companyId);
        }
    }
}