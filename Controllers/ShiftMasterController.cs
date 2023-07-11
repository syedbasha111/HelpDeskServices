using HelpDeskServices.BusinessAccessLayer;
using HelpDeskServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskServices.Controllers
{
    [RoutePrefix("api/ShiftMaster")]
    public class ShiftMasterController : ApiController
    {
        ShiftMasterBAL BAL = new ShiftMasterBAL();
        [HttpPost]
        [Route("ShiftMaster")] //Matches POST api/products
        public IHttpActionResult ShiftMaster(ShiftMaster request)
        {
            if (request.Id == 0)
            {
                return Ok(BAL.SaveShiftMaster(request));
            }
            else
            {
                return Ok(BAL.UpdateShiftMaster(request));
            }
        }


        [HttpGet]
        [Route("ShiftMaster")]
        public IHttpActionResult GetShiftmaster(int Id)
        {
            return Ok(BAL.Getshiftdetsils(Id));
        }
        [HttpPost]
        [Route("DeleteShiftMaster")]
        public IHttpActionResult DeleteShiftMaster(DeleteObj request)
        {
            return Ok(BAL.DeleteShiftMaster(request));
        }

        #region  
        /// <summary>
        /// get Shift details by locationid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Shiftbylocation")]
        public async Task<Hd_Responce> getShiftbylocation(int Companyid, int Id=0)
        {
            return await BAL.getShiftbylocation(Companyid,Id);
        }
        #endregion

    }
}
