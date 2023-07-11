using HelpDeskServices.DataAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer
{
    public class ShiftMasterBAL
    {
        ShiftMasterDAL DAL = new ShiftMasterDAL();
        public string SaveShiftMaster(ShiftMaster request)
        {
            return DAL.SaveShiftMaster(request);
        }

        public string UpdateShiftMaster(ShiftMaster request)
        {
            return DAL.UpdateShiftMaster(request);
        }

        public List<ShiftMaster> Getshiftdetsils(int Id)
        {
            return DAL.Getshiftdetsils(Id);
        }

        public string DeleteShiftMaster(DeleteObj request)
        {
            return DAL.DeleteShiftMaster(request);
        }

        public Task<Hd_Responce> getShiftbylocation(int Companyid,int Id)
        {
            return Task.FromResult(DAL.getShiftbylocation(Companyid,Id));
        }

    }
}