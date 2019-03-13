using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class SlaTimeDefinationBAL
    {
        public string InsertSLATimeDefination(SlaTimeDefinationModel obj)
        {
            SlaTimeDefinationDAL slaservicedalMethod = new SlaTimeDefinationDAL();
            return slaservicedalMethod.insertSLATimeDefination(obj);

        }

        public string UpdateSLATimeDefination(SlaTimeDefinationModel obj)
        {
            SlaTimeDefinationDAL slaservicedalMethod = new SlaTimeDefinationDAL();
            return slaservicedalMethod.UpdateSLATimeDefination(obj);

        }
        public List<SlaTimeDefinationModel> GetSLATimeDefination(int companyId)
        {
            SlaTimeDefinationDAL slaservicedalMethod = new SlaTimeDefinationDAL();
            return slaservicedalMethod.GetSLATimeDefination(companyId);

        }

        public string DeleteSLATimeDefination(int recordId)
        {

            SlaTimeDefinationDAL slaservicedalMethod = new SlaTimeDefinationDAL();
            return slaservicedalMethod.DeleteSLATimeDefination(recordId);
        }
    }
}