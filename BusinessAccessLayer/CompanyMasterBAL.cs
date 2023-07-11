using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class CompanyMasterBAL
    {
        CompanyMasterDAL DAL = new CompanyMasterDAL();
        /// <summary>
        /// Getting data for DropDowns CompanyName,currency,timezone
        /// </summary>
        /// <returns></returns>
        public MVCompanyData GetBindingdata()
        {
            return DAL.GetBindingdata();

        }


        public List<CompanyMaster> GetCompanyBasedUser(string Username)
        {
            return DAL.GetCompanyBasedUser(Username);

        }

        public List<CurrencyCode> GetCurrencyName(int Id)
        {
            return DAL.GetCurrencyName(Id);
        }
        public List<CompanyMaster> GetCompanyName()
        {
            return DAL.GetCompanyName();
        }

        public string CompanyMaster(CompanyMaster obj)
        {
            return DAL.CompanyMaster(obj);
        }
        public string UpdateCompanyMaster(CompanyMaster obj)
        {
            return DAL.UpdateCompanyMaster(obj);
        }

        public string savelogoFile(CompanyMaster obj)
        {
            return DAL.savelogoFile(obj);

        }

        public string savedocsFile(CompanyMaster obj)
        {
            return DAL.savedocsFile(obj);

        }

        public string SaveCompanyGrid(int Id,List<CompanyAdressDetails> obj)
        {
            return DAL.SaveCompanyGrid(Id,obj);
        }

        public List<CompanyAdressDetails> GetCompanyAdress(int CompanyId)
        {
            return DAL.GetCompanyAdress(CompanyId);
        }

        public List<OfficeTypeModel> GetCompanyType(int CompanyId)
        {
            return DAL.GetCompanyType(CompanyId);
        }
    }
}