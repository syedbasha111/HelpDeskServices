using HelpDeskServices.DataAccessLayer.Masters;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static HelpDeskServices.DataAccessLayer.Masters.UserRightsDAL;

namespace HelpDeskServices.BusinessAccessLayer.Masters
{
    public class UserRightsBAL
    {
        UserRightsDAL DAL = new UserRightsDAL();

        public string CreatUserRights(List<UserRights> obj)
        {
            return DAL.CreatUserRights(obj);
        }

        public UserRights GetScreenUserRights(UserRights req)
        {
            return DAL.GetScreenUserRights(req);
        }

        public ScreenDetaisl GetUserdetails(string url)
        {
            return DAL.GetUserdetails(url);
        }
    }
}