using HelpDeskServices.DataAccessLayer.AssetMaster;
using HelpDeskServices.DataModels;
using HelpDeskServices.DataModels.AssetMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.AssetMaster
{
    public class TaskListBAL
    {
        TaskListDAL DAL = new TaskListDAL();

        public List<SubSytem> GetSubSystemdata(SubSytem request)
        {
            return DAL.GetSubSystemdata(request);
        }
        public string SaveTaskList(TaskListMaster request)
        {
            return DAL.SaveTaskList(request);
        }

        public string UpdateTaskList(TaskListMaster request)
        {
            return DAL.UpdateTaskList(request);
        }

        public List<TaskTypeMaster> DropdownTaskType(int CompanyId)
        {
            return DAL.DropdownTaskType(CompanyId);
        }
        public List<FrequencyMaster> DropdownFrequency(int CompanyId)
        {
            return DAL.DropdownFrequency(CompanyId);
        }

        public string SaveTaskListItems(List<TaskListAddItemModel> request,int Id)
        {
            return DAL.SaveTaskListItems(request,Id);
        }


        public List<TaskListMaster> TaskListDetails(int CompanyId)
        {
            return DAL.TaskListDetails(CompanyId);
        }
        public List<TaskListAddItemModel> TaskLisItemDetails(int CompanyId,int Id)
        {
            return DAL.TaskLisItemDetails(CompanyId, Id);
        }

        public string DeleteTLAddItem( int Id)
        {
            return DAL.DeleteTLAddItem(Id);
        }
        public string DeleteTaskList(int Id)
        {
            return DAL.DeleteTaskList(Id);
        }


        //public string SavePlanDetailsItems(List<PlanListAddItemModel>)
        //{
        //    return DAL.SavePlanListItems();
        //}
        
    }
}