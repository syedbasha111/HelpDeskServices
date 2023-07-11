using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static HelpDeskServices.DataModels.Resources;

namespace HelpDeskServices.BusinessAccessLayer.Transaction
{
    public class WorkOrderBAL
    {
        WorkOrderDAL DAL = new WorkOrderDAL();
        public string CreateWorkOrder(Workorder obj)
        {
            return DAL.CreateWorkOrder(obj);
        }


        public string updateWorkOrder(Workorder obj)
        {
            return DAL.updateWorkOrder(obj);
        }

        public string SaveWorkOrderdocuments(RaiseService obj)
        {

            return DAL.SaveWorkOrderdocuments(obj);

        }

        public string UpdateWorkOrderFile(RaiseService obj)
        {

            return DAL.UpdateWorkOrderFile(obj);

        }

        public List<Workorder> GetWorkOrderDetails(RaiseService obj)
        {
            return DAL.GetWorkOrderDetails(obj);
        }

        public List<Workorder> GetCompleteWorkOrder(RaiseService obj)
        {
            return DAL.GetCompleteWorkOrder(obj);
        }

        public List<Workorder> GetWorkOrderDetailsForUpdate(RaiseService obj)
        {
            return DAL.GetWorkOrderDetailsForUpdate(obj);
        }

        public List<Workorder> getWorkOrderByid(int Id)
        {
            return DAL.getWorkOrderByid(Id);
        }

        public listofimages GetWorkOrderImages(int Id,int RaiseId)
        {
            return DAL.GetWorkOrderImages(Id, RaiseId);
        }

        public string RejectWorkOrder(List<Workorder> obj)
        {
            return DAL.RejectWorkOrder(obj);
        }

        public string DeleteWOIMage(Workorder obj)
        {
            return DAL.DeleteWOIMage(obj);
        }

        public List<WorkOrderStatus> GetWOStatusMaster(int Id)
        {
            return DAL.GetWOStatusMaster(Id);
        }


       
        

        public listofresourcesandspares GetWOchilddetsils(int Id)
        {
            return DAL.GetWOchilddetsils(Id);
        }
       

        public string DeleteWoresourse(WoResource obj)
        {
            return DAL.DeleteWoresourse(obj);
        }
        public string DeleteWoSpares(WoResource obj)
        {
            return DAL.DeleteWoSpares(obj);
        }
        public string DeleteWoTools(WoResource obj)
        {
            return DAL.DeleteWoTools(obj);
        }
        public string DeleteWoConsumabels(WoResource obj)
        {
            return DAL.DeleteWoConsumabels(obj);
        }

        public string DeleteWOAddItems(WoAddItems obj)
        {
            return DAL.DeleteWOAddItems(obj);
        }

        public string CreateWorkOrderHistory(WOHistory obj)
        {
            return DAL.CreateWorkOrderHistory(obj);
        }


        public List<WOHistory> GetWorkOrderHistoryDetails(int Id, int companyId)
        {
            return DAL.GetWorkOrderHistoryDetails(Id, companyId);
        }


        public listofresourcesandspares getResourcesdata(int Id, int companyId)
        {
            return DAL.getResourcesdata(Id, companyId);
        }

        public string AddWOChilddata(listofresourcesandspares obj)
        {
            return DAL.AddWOChilddata(obj);
        }

    }
}