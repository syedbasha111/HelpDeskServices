using HelpDeskServices.BusinessAccessLayer.AssetMaster;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using HelpDeskServices.DataModels;

namespace HelpDeskServices.Controllers.AssetMaster
{
    [RoutePrefix("api/TaskList")]
    public class TaskListMasterController : ApiController
    {
        TaskListBAL BAL = new TaskListBAL();
        [HttpPost]
        [Route("TaskList")]
        public HttpResponseMessage SaveTaskList( TaskListMaster request)
        {
            string Responce = "";
            if (request.Id > 0)
            {
                Responce = BAL.UpdateTaskList(request);
            }
            else {
                Responce = BAL.SaveTaskList(request);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Responce);
        }

        [HttpPost]
        [Route("SubSystemDropDown")]
        public HttpResponseMessage DropdownSubSystemdata([FromBody] SubSytem request)
        {
            List<SubSytem> List = new List<SubSytem>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.GetSubSystemdata(request));
        }
        [HttpGet]
        [Route("TaskTypeDropDown")]
        public HttpResponseMessage DropdownTaskType(int CompanyId)
        {
            List<TaskTypeMaster> List = new List<TaskTypeMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.DropdownTaskType(CompanyId));
        }
        [HttpGet]
        [Route("FrequencyDropDown")]
        public HttpResponseMessage DropdownFrequency(int CompanyId)
        {
            List<FrequencyMaster> List = new List<FrequencyMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.DropdownFrequency(CompanyId));
        }
        [HttpPost]
        [Route("TaskListAdditem")]
        public HttpResponseMessage SaveTaskListItems(List<TaskListAddItemModel> request,int Id)
        {
            string Responce = "";
            return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.SaveTaskListItems(request, Id));
        }
        
        [HttpGet]
        [Route("Tasklist")]
        public HttpResponseMessage TaskListDetails(int CompanyId)
        {
            List<TaskListMaster> List = new List<TaskListMaster>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.TaskListDetails(CompanyId));
        }
        [HttpGet]
        [Route("TasklistAddItems")]
        public HttpResponseMessage TaskLisItemDetails(int CompanyId,int Id)
        {
            List<TaskListAddItemModel> List = new List<TaskListAddItemModel>();
            return Request.CreateResponse(HttpStatusCode.OK, List = BAL.TaskLisItemDetails(CompanyId,Id));
        }
        [HttpDelete]
        [Route("TasklistAddItems")]
        public HttpResponseMessage DeleteTLAddItem(int Id)
        {
            string responce = "";
            return Request.CreateResponse(HttpStatusCode.OK, responce = BAL.DeleteTLAddItem(Id));
        }

        [HttpDelete]
        [Route("Tasklist")]
        public HttpResponseMessage DeleteTaskList(int Id)
        {
            string responce = "";
            return Request.CreateResponse(HttpStatusCode.OK, responce = BAL.DeleteTaskList(Id));
        }

        //[HttpPost]
        //[Route("plandetails")]
        //public HttpResponseMessage Saveplandetails(List<PlanListAddItemModel>)
        //{
        //    string Responce = "";
        //    return Request.CreateResponse(HttpStatusCode.OK, Responce = BAL.SavePlanDetailsItems());
        //}
       
    }
}
