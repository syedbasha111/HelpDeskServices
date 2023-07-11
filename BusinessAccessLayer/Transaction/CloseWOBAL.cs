using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Transaction
{
    public class CloseWOBAL
    {
        CloseWoDAL DAL = new CloseWoDAL();
        public string CreateCloseWOStatus(CloseWOStatus obj)
        {
            return DAL.CreateCloseWOStatus(obj);
        }

        public string RejectCloseWOStatus(CloseWOStatus obj)
        {
            return DAL.RejectCloseWOStatus(obj);
        }
    }
}