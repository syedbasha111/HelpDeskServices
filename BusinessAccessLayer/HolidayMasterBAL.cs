using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class HolidayMasterBAL
    {
        public string InsertHolidayCallMaster(HolidayCallMasterModel obj)
        {
            HolidayMasterDAL HolidaycallMethod = new HolidayMasterDAL();
            return HolidaycallMethod.insertHolidayCallMaster(obj);

        }

        public string UpdateHolidayCallMaster(HolidayCallMasterModel obj)
        {
            HolidayMasterDAL HolidaycallMethod = new HolidayMasterDAL();
            return HolidaycallMethod.UpdateHolidayMaster(obj);

        }
        public List<HolidayCallMasterModel> GetHolidayCallMaster(int companyId)
        {
            HolidayMasterDAL HolidaycallMethod = new HolidayMasterDAL();
            return HolidaycallMethod.GetHolidayMaster(companyId);

        }

        public string DeleteHolidayCallMaster(int recordId)
        {

            HolidayMasterDAL HolidaycallMethod = new HolidayMasterDAL();
            return HolidaycallMethod.DeleteHolidayMaster(recordId);
        }
    }
}