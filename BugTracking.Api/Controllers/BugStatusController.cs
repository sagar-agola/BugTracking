using BugTracking.Business.Contracts.Services.BugStatus;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.BugStatus;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/bug/status")]
    public class BugStatusController : ApiController
    {
        #region Properties
        private readonly IBugStatusService bugStatusService;
        #endregion

        #region Constructor
        public BugStatusController()
        {
            bugStatusService = new BugStatusService();
        }
        #endregion

        [Route("create")]
        [HttpPost]
        public object CreateStatus(Bug_StatusViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugStatusService.Create(model);
                responseDetails = Helper.SetResponseDetails("Status inserted successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }
            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllStatus()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<Bug_StatusViewModel> bugStatusList = bugStatusService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, bugStatusList, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("update")]
        [HttpPut]
        public object UpdateStatus(Bug_StatusViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugStatusService.Update(model);
                responseDetails = Helper.SetResponseDetails("Bug status updated successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteStatus(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugStatusService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Bug Status removed successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }
            return responseDetails;
        }
    }
}
