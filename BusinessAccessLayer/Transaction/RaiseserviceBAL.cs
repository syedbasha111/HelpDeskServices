using HelpDeskServices.DataAccessLayer.Transaction;
using HelpDeskServices.DataModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskServices.BusinessAccessLayer.Transaction
{
    public class RaiseserviceBAL
    {
        public string CreateRaiseService(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.CreateRaiseService(obj);
        }

        public string updateRaiseService(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.updateRaiseService(obj);
        }
        public string UpdateAssignList(List<RaiseService> obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.UpdateAssignList(obj);
        }

        public string SaveRaisedocumentPath(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.SaveRaisedocumentPath(obj);

        }

        public List<RaiseService> getserviceRequestDetails(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getserviceRequestDetails(obj);
        }

        public List<RaiseService> getAssignData(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getAssignData(obj);
        }
        public List<RaiseService> getserviceRequestDetailsforWO(RaiseService obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getserviceRequestDetailsforWO(obj);
        }

        public List<RaiseService> getserviceRequestByid(int Id)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getserviceRequestByid(Id);
        }

        public List<RequestForm> getRequestFormMaster()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getRequestFormMaster();
        }

        public List<SystemName> getSystemMaster()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getSystemMaster();
        }

        public List<SubSystem> getSubSystemMaster()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.getSubSystemMaster();
        }

        public List<Locationpriority> GetLocationPriority()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.GetLocationPriority();
        }

        public List<Servicepriority> GetServicePriority()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.GetServicePriority();
        }
        public string SaveAssertlabelId(List<AssertLabelModel> obj)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.SaveAssertlabelId(obj);
        }

        public List<AssertLabelModel> GetassertLabelMaster()
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.GetassertLabelMaster();
        }

        public List<AssertLabelModel> GetassertLabelMasterId(int Id)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.GetassertLabelMasterId(Id);
        }
        public List<AssignRequest> GetassignList(int Id)
        {
            RaiseServiceDAL DAL = new RaiseServiceDAL();
            return DAL.GetassignList(Id);
        }

    }
}