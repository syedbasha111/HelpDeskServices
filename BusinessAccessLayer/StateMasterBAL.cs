using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class StateMasterBAL
    {
        public string InsertStateMaster(StateModel obj)
        {
            StateMasterDAL StatecallMethod = new StateMasterDAL();
            return StatecallMethod.insertStateMaster(obj);

        }
        public string updateStateMaster(StateModel obj)
        {
            StateMasterDAL StatecallMethod = new StateMasterDAL();
            return StatecallMethod.updateStateMaster(obj);

        }

        public List<StateModel> GetStateMaster(int companyId)
        {
            StateMasterDAL StatecallMethod = new StateMasterDAL();
            return StatecallMethod.GetStateMaster(companyId);

        }
        public List<CountryModel> GetCountries(int companyId)
        {
            StateMasterDAL StatecallMethod = new StateMasterDAL();
            return StatecallMethod.GetCountries(companyId);

        }

        public string deleteStateMaster(DeleteObj obj)
        {
            StateMasterDAL StatecallMethod = new StateMasterDAL();
            return StatecallMethod.DeleteStateMaster(obj);

        }
    }
}